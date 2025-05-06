use InventoryWalmart;
GO

--MODULO PRODUCTOS
-- Funcion 1: Valorar el total de todos los productos
CREATE FUNCTION dbo.TotalInventoryValue()
RETURNS TABLE
AS
RETURN (
 SELECT
 p.id_product,
 p.name_product,
 p.price * p.stock AS ValorTotalInventario
 FROM
 PRODUCTS p
);
go

--select * from TotalInventoryValue();

-- Funcion 2: Obtener los productos de una categoría específica
Create Function fn_ProductsByCategory (@id_category INT)
Returns Table
as
Return (
Select name_product, price, stock
From PRODUCTS
Where id_category = @id_category );
go

-- SELECT * FROM fn_ProductsByCategory(2);


--MODULO CLIENTES
-- Funcion 1: Calcular el total gastado por un cliente
CREATE FUNCTION fn_SpendingCustomer
(@id_customer INT)
RETURNS DECIMAL(10,2)
AS BEGIN DECLARE @total DECIMAL(10,2);
SELECT @total = SUM(total_amount)
FROM SALES
WHERE id_customer = @id_customer;
RETURN ISNULL(@total, 0);
END;
go

--SELECT dbo.fn_SpendingCustomer(3) AS TotalGastado;

-- Funcion 2; Obtener el nombre completo de un cliente
Create Function fn_FullNameCustomer (@id_customer INT)
Returns Varchar(101)
As
Begin Declare @nombre_completo Varchar(101);
Select @nombre_completo = first_name + ' ' + last_name
From CUSTOMERS
Where id_customer = @id_customer;
Return ISNULL(@nombre_completo, 'Cliente no encontrado'); End;
go


--MODULO INVENTARIO
-- Funcion: Revisar los productos que estan por debajo o igual a la cantidad en stock que deben tener (5)

CREATE FUNCTION fn_CheckMinimunStock()
RETURNS TABLE AS RETURN(
SELECT
p.name_product as Producto,
p.stock as Stock
from PRODUCTS P WHERE stock <= 5);
GO

--SELECT * FROM fn_CheckMinimunStock();
-- Funcion: top 10 productos mas vendidos
CREATE FUNCTION fn_10SellingProducts()
RETURNS TABLE AS RETURN(
SELECT TOP 10
p.name_product AS Producto,
SUM(sd.quantity) as CantidadVendida
from SALE_DETAILS sd
JOIN PRODUCTS p on p.id_product = sd.id_product
GROUP BY p.name_product
ORDER BY CantidadVendida DESC);
GO

--SELECT * FROM fn_10SellingProducts();

--MODULO PROMOCIONES
-- Funcion Obtener los beneficios disponibles para una tarjeta de fidelización
Create Function fn_BenefitsAvailable (@id_card INT)
Returns Table as Return (
Select
b.benefit_name,
b.description,
b.points_required
From BENEFITS b
Where b.points_required <= (
Select points_balance
From CUSTOMER_CARD 
Where id_card = @id_card) );
go

SELECT * FROM fn_BenefitsAvailable(1);
go;
-- Función para Obtener el Descuento Aplicado a un Cliente
CREATE FUNCTION fn_GetCustomerDiscount(@id_customer INT)
RETURNS DECIMAL(5,2) AS BEGIN DECLARE @discount DECIMAL(5,2);
SELECT @discount = MAX(B.discount_percentage)
FROM CUSTOMER_CARD AS C
JOIN CARD_BENEFITS CB ON C.id_card = CB.id_card
JOIN BENEFITS B ON CB.id_benefit = B.id_benefit
WHERE C.id_customer = @id_customer
 AND B.start_date <= GETDATE()
 AND B.end_date >= GETDATE();
RETURN ISNULL(@discount, 0);
END;
go
SELECT dbo.fn_GetCustomerDiscount(3) AS Descuento;



