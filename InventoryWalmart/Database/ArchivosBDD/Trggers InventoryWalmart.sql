
--1. Realizar un triggers que permita actualizar el inventario tras una venta, debe
--disminuir el stoks tras registrar un mensaje, adem�s debe enviar un mensaje si
--en dado caso la cantidad de producto a comprar es mayor a la existente.
CREATE TRIGGER trg_updateInventory2
ON dbo.SALE_DETAILS
INSTEAD OF INSERT
AS
BEGIN
	 IF EXISTS (
        SELECT 1 FROM inserted i
        INNER JOIN PRODUCTS p ON i.id_product = p.id_product
        WHERE i.quantity > p.stock
    )
    BEGIN
        RAISERROR ('No hay suficiente stock disponible.', 16, 1);
        RETURN;
    END

	UPDATE dbo.PRODUCTS
	SET stock = stock - i.quantity
	FROM dbo.PRODUCTS as p
	INNER JOIN inserted i on p.id_product = i.id_product
	print 'Stock Actualizado Correctamente';
	
END;
GO

/*2- Crear una tabla que permita registrar las ganancias y reinversi�n, esta se debe
llenar por medio de un triggers despu�s de realizar una venta */
CREATE TRIGGER trg_proftisReinvestment
ON dbo.SALE_DETAILS
after INSERT
AS
BEGIN
	IF EXISTS(SELECT 1 FROM  profitsReinvestment as pr INNER JOIN inserted as i on pr.idProduct = i.id_product)
	BEGIN
		UPDATE pr
		SET 
			pr.profits = pr.profits + (p.price - p.priceSup),
			pr.reinvestment = pr.reinvestment + p.priceSup
		FROM dbo.profitsReinvestment AS pr
		INNER JOIN dbo.PRODUCTS AS p ON pr.idProduct = p.id_product
		INNER JOIN inserted AS i ON p.id_product = i.id_product;
	END
	ELSE
	BEGIN
		INSERT INTO profitsReinvestment(idProduct, profits, reinvestment)
		SELECT 
			i.id_product,                      -- idProduct
			(p.price - p.priceSup),             -- profits
			p.priceSup                          -- reinvestment
		FROM dbo.PRODUCTS AS p
		INNER JOIN inserted AS i ON p.id_product = i.id_product;
	END
END;
GO

/*
	3- Crear una tabla la cual permita almacenar reportes de ventas semanales, esta
	se debe llenar a trav�s de una triggers
*/
CREATE TRIGGER trg_reportSaleWeek
ON dbo.SALE_DETAILS
AFTER INSERT
AS
BEGIN
	 DECLARE @startDayWeek DATETIME;
	 DECLARE @lastDayWeek DATETIME;
	 DECLARE @quantitySales int;

	 -- Calcula el lunes de la semana actual
	SET @startDayWeek = DATEADD(DAY, 1 - DATEPART(WEEKDAY, GETDATE()), GETDATE());
	-- Calcula el domingo sumando 6 d�as al lunes
	SET @lastDayWeek = DATEADD(DAY, 6, @startDayWeek);
	--Calcular la cantidad de ventas
	SET @quantitySales = (SELECT COUNT(sale_date) FROM SALES WHERE  GETDATE() < @lastDayWeek);

	IF (GETDATE() = @startDayWeek)
	BEGIN
		IF EXISTS(SELECT 1 FROM REPORT_SALES WHERE startDayWeek = @startDayWeek )
		BEGIN
			DECLARE @cantidad int;
			SET @cantidad = (SELECT COUNT(sale_date) FROM SALES WHERE sale_date > @startDayWeek and sale_date < @lastDayWeek);

			UPDATE REPORT_SALES SET quantitySales=@cantidad,
			priceTotal = priceTotal + (
						 SELECT i.price
						 FROM SALE_DETAILS AS rs
						 INNER JOIN inserted AS i ON rs.id_sale = i.id_sale
						 INNER JOIN SALES AS s ON rs.id_sale = s.id_sale
			)
			WHERE GETDATE() >= startDayWeek AND GETDATE() < lastDayWeek
		END

		INSERT INTO REPORT_SALES(startDayWeek,lastDayWeek,quantitySales,priceTotal)
		SELECT
			@startDayWeek,
			@lastDayWeek,
			1,
			i.price
		FROM SALE_DETAILS as sd
		INNER JOIN inserted as i on sd.id_sale = i.id_sale
	END
	ELSE
	BEGIN
		DECLARE @cantidad2 int;
			SET @cantidad2 = (SELECT COUNT(sale_date) FROM SALES WHERE sale_date > @startDayWeek and sale_date < @lastDayWeek);

			UPDATE REPORT_SALES SET quantitySales=@cantidad2,
			priceTotal = priceTotal + (
						 SELECT i.price
						 FROM SALE_DETAILS AS rs
						 INNER JOIN inserted AS i ON rs.id_sale = i.id_sale
						 INNER JOIN SALES AS s ON rs.id_sale = s.id_sale
			)
			WHERE GETDATE() >= startDayWeek AND GETDATE() < lastDayWeek
	END;
END
GO

-- 4- Crear una tabla que se complemente autom�ticamente registrando todas las 
--operaciones hechas en ventas. 
CREATE TRIGGER trg_InsertSalesRecord
ON dbo.SALES
AFTER INSERT
AS
BEGIN
    INSERT INTO dbo.recordSales (id_customer, sale_Date, totalAmount)
    SELECT i.id_customer, i.sale_Date, i.total_amount
    FROM inserted i;

    PRINT 'Venta registrada en recordSales correctamente';
END
GO

-- 5.Crear un trigger que no me permita la eliminaci�n de productos con ventas de socios 
CREATE TRIGGER trg_PreventDeleteProductWithSales
ON dbo.PRODUCTS
INSTEAD OF DELETE
AS
BEGIN
    -- Verificar si el producto a eliminar tiene ventas de socios
    IF EXISTS (
        SELECT 1
        FROM deleted d
        INNER JOIN ventas v ON d.id_product = v.id_product
        INNER JOIN ventas_socios vs ON v.id_venta = vs.id_venta
    )
    BEGIN
        -- Evitar la eliminaci�n del producto y mostrar un mensaje de error
        RAISERROR ('No se puede eliminar el producto porque tiene ventas asociadas a socios.', 16, 1);
        RETURN;
    END

    -- Si el producto no tiene ventas de socios, permitir la eliminaci�n
    DELETE FROM productos WHERE id_product IN (SELECT id_product FROM deleted);
    
    PRINT 'Producto eliminado correctamente.';
END
GO

--6- Crear una tabla que me permita registrar los intentos fallidos de inicio de 
--sesi�n que se complete por medio de un trigger
CREATE TRIGGER trg_LoginFailed
ON dbo.ErrorsLogs
AFTER INSERT
AS
BEGIN
    INSERT INTO ErrorsLogs (nameuser, startDate, hourDate)
    SELECT i.nameuser, GETDATE(), CONVERT(TIME, GETDATE())
    FROM inserted i

    PRINT 'Intento de inicio de sesi�n fallido registrado en ErrorsLogs';
END
GO

/* 7- Crear una tabla que me permita registrar los cambios de los precios de
productos y se complemente a trav�s de un trigger */
Create trigger TRG_UPDATE_PRICE
On Products
After update
as
Begin
	If update(price) -- Se verifica si se actualizo la columna
	Begin
	Insert into PRICE_HISTORY (id_product, old_price, new_price, changed_by) -- Genera el cambio solo si el precio es diferente
	Select
		i.id_product,
		d.price as old_price,
		i.price as new_price,
		SYSTEM_USER
	From inserted i
	Inner Join deleted d On i.id_product = d.id_product
	Where i.price <> d.price; -- Ver si el precio cambio	
	End
End;
Go

/* 8- una funci�n que me permita obtener el total de ventas realizadas por
clientes */
Go;
Create function dbo.GetTotalSalesByCustomer
(
	@id_customer Int -- Id del cliente
)
Returns Decimal(10, 2)
as
Begin
	Declare @total_sales Decimal(10, 2) -- Para almacenar el total de ventas
	Select
		@total_sales = Sum(total_amount) -- Calcular todas las ventas para el cliente especifico
		From SALES
		Where id_customer = @id_customer;

		If @total_sales is Null
		Begin
			Set @total_sales = 0;
		End
	Return @total_sales; -- devuelve el total de ventas
End
GO


/* 9- Realizar una funci�n que me permita realizar descuentos en una venta */
Go;
CREATE PROCEDURE dbo.ApplyPercentageDiscountToSales
(
    @id_sale INT,          -- Par�metro de entrada: ID de la venta
    @discount_percentage DECIMAL(5, 2)  -- Par�metro de entrada: Porcentaje de descuento
)
AS
BEGIN
    DECLARE @new_total DECIMAL(10, 2);  -- Variable para almacenar el nuevo total
    DECLARE @current_total DECIMAL(10, 2);  -- Variable para almacenar el total actual

    -- Obtener el total actual de la venta
    SELECT @current_total = total_amount
    FROM SALES
    WHERE id_sale = @id_sale;

    -- Calcular el descuento y aplicarlo
    SET @new_total = @current_total - (@current_total * (@discount_percentage / 100));

    -- Actualizar el total de la venta en la tabla SALES
    UPDATE SALES
    SET total_amount = @new_total
    WHERE id_sale = @id_sale;

    -- Devolver el nuevo total de la venta
    SELECT @new_total AS NewTotal;
END
GO
-- 10.  Generar una funci�n que me permita verificar el stock disponible de un producto en espec�fico. 
CREATE FUNCTION check_product_stock(@id_product INT)
RETURNS INT
AS
BEGIN
    DECLARE @stock INT;
    SELECT @stock = stock
    FROM PRODUCTS
    WHERE id_product = @id_product;

RETURN ISNULL(@stock,0);
END
GO

-- 11. Realizar una funci�n que me permita generar un reporte de ventas hecha por categor�a 
CREATE FUNCTION sales_by_category(@start_date DATE, @end_date DATE)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        C.category_name,
        SUM(SD.quantity * SD.price) AS total_sales

    FROM 
        SALES S
    JOIN SALE_DETAILS SD ON S.id_sale = SD.id_sale
    JOIN PRODUCTS P ON SD.id_product = P.id_product
    JOIN CATEGORY C ON P.id_category = C.id_category
    WHERE @end_date >= @start_date AND
	S.sale_date BETWEEN @start_date AND @end_date
    GROUP BY C.category_name, S.sale_date
);
GO

-- 12. Realizar una funci�n que me permita verifica los permisos de usuario  
CREATE FUNCTION check_user_permissions(@id_user INT)
RETURNS TABLE
AS
RETURN
(
SELECT 
        R.role_name,
        R.description AS role_description
    FROM 
        USERS U
    JOIN ROLES R ON U.id_role = R.id_role
    WHERE U.id_user =@id_user
);
GO

-- 13. Crear una funci�n de los 10 productos mas vendidos  
CREATE FUNCTION fn_Top10ProductosMasVendidos()
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 10
        P.id_product,
        P.name_product AS Producto,
        SUM(SD.quantity) AS CantidadVendida
    FROM SALE_DETAILS SD
	INNER JOIN PRODUCTS P ON SD.id_product = P.id_product
    GROUP BY P.id_product, P.name_product
    ORDER BY SUM(SD.quantity) DESC
);
GO

-- 14. Crear una funci�n que me permita validad la existencia de un cliente asociado. 
CREATE FUNCTION fn_ValidarClienteAsociado(@id_customer INT)
RETURNS BIT
AS
BEGIN
    DECLARE @Existe BIT;

    IF EXISTS (SELECT 1 FROM CUSTOMER_CARD WHERE id_customer = @id_customer)
    BEGIN
        SET @Existe = 1;  -- El cliente est� asociado
    END
    ELSE
    BEGIN
        SET @Existe = 0;  -- El cliente no est� asociado
    END
    RETURN @Existe;
END;
GO


-- 15. Funci�n para obtener el total de devoluciones por cliente. 
CREATE FUNCTION fn_TotalDevolucionesPorCliente(@id_customer INT)
RETURNS INT
AS
BEGIN
    DECLARE @TotalDevoluciones INT;

    SELECT @TotalDevoluciones = COUNT(*)
    FROM RETURNS R
    WHERE R.id_customer = @id_customer;
    RETURN ISNULL(@TotalDevoluciones, 0);  -- Si no hay devoluciones, retorna 0
END;
GO