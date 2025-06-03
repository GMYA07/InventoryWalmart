use InventoryWalmart;
GO

CREATE PROCEDURE dbo.ApplyPercentageDiscountToSale
(
    @id_sale INT,          -- Parámetro de entrada: ID de la venta
    @discount_percentage DECIMAL(5, 2)  -- Parámetro de entrada: Porcentaje de descuento
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
END;

CREATE OR ALTER PROCEDURE obtenerAccount
(
    @userName varchar(30),
    @pass varchar(250)
)
AS
BEGIN
    IF EXISTS(SELECT id_account,id_user FROM ACCOUNT WHERE username = @userName and pass = @pass and status_account = 1)
        BEGIN
            SELECT id_account,id_user,username,pass,status_account FROM ACCOUNT WHERE username = @userName and pass = @pass; --Existe
        END;
END

-- Aplicar un descuento del 10% a la venta con id_sale = 1
EXEC dbo.ApplyPercentageDiscountToSale @id_sale = 1, @discount_percentage = 10.00;
go

CREATE PROCEDURE delete_Benefits @id_benefit int
AS
BEGIN
IF NOT EXISTS (SELECT 1 FROM BENEFITS WHERE id_benefit = @id_benefit)
BEGIN
RAISERROR('El id no esta registrado.', 16, 1);
END
ELSE
BEGIN
DELETE FROM BENEFITS WHERE id_benefit = @id_benefit;
END
END;
go

CREATE   PROCEDURE delete_CardBenefit
 @id_card_benefit INT
AS
BEGIN
 -- Validación: Existencia del registro
 IF NOT EXISTS (SELECT 1 FROM CARD_BENEFITS WHERE id_card_benefit =
@id_card_benefit)
 BEGIN
 RAISERROR('El id del registro no está registrado.', 16, 1);
 RETURN;
 END
 -- Eliminar registro
 DELETE FROM CARD_BENEFITS
 WHERE id_card_benefit = @id_card_benefit;
END;
go

CREATE PROCEDURE delete_Category
 @id_category INT
AS
BEGIN
 -- Validación: Existencia de la categoría
 IF NOT EXISTS (SELECT 1 FROM CATEGORY WHERE id_category = @id_category)
 BEGIN
 RAISERROR('El id no está registrado.', 16, 1);
 RETURN;
 END
 -- Eliminar registro
 DELETE FROM CATEGORY
 WHERE id_category = @id_category;
END;
go

CREATE PROCEDURE delete_Customer
 @id_customer INT
AS
BEGIN
 -- Validación: Existencia del cliente
 IF NOT EXISTS (SELECT 1 FROM CUSTOMERS WHERE id_customer = @id_customer)
 BEGIN
 RAISERROR('El id no está registrado.', 16, 1);
 RETURN;
 END
 -- Eliminar registro
 DELETE FROM CUSTOMERS
 WHERE id_customer = @id_customer;
END;
go

-- Procedimiento para deleite customer card
CREATE PROCEDURE delete_CustomerCard
 @id_card INT
AS
BEGIN
 -- Verificar que la tarjeta de cliente exista
 IF NOT EXISTS (SELECT 1 FROM CUSTOMER_CARD WHERE id_card = @id_card)
 BEGIN
 RAISERROR('La tarjeta de cliente con el ID especificado no existe.', 16, 1);
 RETURN;
 END
 -- Eliminar el registro
 DELETE FROM CUSTOMER_CARD WHERE id_card = @id_card;

END;
go


--delete
CREATE PROCEDURE delete_Department
@id_department int
AS
BEGIN
IF NOT EXISTS(SELECT * FROM DEPARTMENT WHERE id_department =
@id_department)
BEGIN
RAISERROR('El id no está registrado.', 16, 1);
 RETURN;
END
DELETE FROM DEPARTMENT WHERE id_department = @id_department;
END;

go

-- procedimiento para delete Discount
CREATE PROCEDURE delete_Discount
 @id_discount INT
AS
BEGIN
 -- Verificar que el descuento exista
 IF NOT EXISTS (SELECT 1 FROM DISCOUNT WHERE id_discount = @id_discount)
 BEGIN
 RAISERROR('El descuento con el ID especificado no existe.', 16, 1);
 RETURN;
 END
 -- Eliminar el descuento
 DELETE FROM DISCOUNT WHERE id_discount = @id_discount;

END;
go

--DELETE
CREATE PROCEDURE delete_District
 @id_district INT
AS
BEGIN
 -- Validar que el ID del distrito no esté vacío o sea inválido
 IF (@id_district IS NULL OR @id_district = 0)
 BEGIN
 RAISERROR('El ID del distrito no puede estar vacío o ser inválido.', 16, 1);
 RETURN;
 END
 -- Validar que el ID del distrito exista
 IF NOT EXISTS (SELECT 1 FROM DISTRICT WHERE id_district = @id_district)
 BEGIN
 RAISERROR('El ID del distrito no está registrado.', 16, 1);
 RETURN;
 END
 -- Validar que el distrito no esté siendo referenciado en otras tablas
 -- Por ejemplo, en la tabla USERS
 IF EXISTS (SELECT 1 FROM USERS WHERE id_district = @id_district)
 BEGIN
 RAISERROR('No se puede eliminar el distrito porque está siendo utilizado en la tabla
USERS.', 16, 1);
 RETURN;
 END
 -- Eliminar el distrito
 DELETE FROM DISTRICT
 WHERE id_district = @id_district;
 PRINT 'Distrito eliminado correctamente.';
END;
go

-- DELETE
CREATE   PROCEDURE delete_PaymentMethod
 @id_payment_method INT
AS
BEGIN
 -- Validar que el ID del método de pago no esté vacío o sea inválido
 IF (@id_payment_method IS NULL OR @id_payment_method = 0)
 BEGIN
 RAISERROR('El ID del método de pago no puede estar vacío o ser inválido.', 16, 1);
 RETURN;
 END
 -- Validar que el ID del método de pago exista
 IF NOT EXISTS (SELECT 1 FROM PAYMENT_METHOD WHERE id_payment_method =
@id_payment_method)
 BEGIN
 RAISERROR('El ID del método de pago no está registrado.', 16, 1);
 RETURN;
 END
 -- Validar que el método de pago no esté siendo referenciado en otras tablas
 -- Por ejemplo, en la tabla SALES
 IF EXISTS (SELECT 1 FROM SALES WHERE id_payment_method =
@id_payment_method)
 BEGIN
 RAISERROR('No se puede eliminar el método de pago porque está siendo utilizado en la
tabla SALES.', 16, 1);
 RETURN;
 END
 -- Eliminar el método de pago
 DELETE FROM PAYMENT_METHOD
 WHERE id_payment_method = @id_payment_method;
 PRINT 'Método de pago eliminado correctamente.';
END;
go

-- Procedimiento almacenados para eliminar POINTS_HISTORY
CREATE PROCEDURE delete_PointsHistory
 @id_points_history INT
AS
BEGIN
 IF NOT EXISTS (SELECT 1 FROM POINTS_HISTORY WHERE id_points_history =
@id_points_history)
 BEGIN
 RAISERROR('El ID de la historia de puntos no está registrado.', 16, 1);
 RETURN;
 END
 DELETE FROM POINTS_HISTORY WHERE id_points_history = @id_points_history;
END;
go

-- Procedimiento almacenado para delete un producto
CREATE PROCEDURE delete_Product
 @id_product INT
AS
BEGIN
 IF NOT EXISTS (SELECT 1 FROM PRODUCTS WHERE id_product = @id_product)
 BEGIN
 RAISERROR('El ID del producto no está registrado.', 16, 1);
 RETURN;
 END

 DELETE FROM PRODUCTS WHERE id_product = @id_product;
END;
go

CREATE PROCEDURE delete_Return
 @id_return INT
AS
BEGIN
 -- Validación: Existencia de la devolucion
 IF NOT EXISTS (SELECT 1 FROM RETURNS WHERE id_return = @id_return)
 BEGIN
 RAISERROR('El id no está registrado.', 16, 1);
 RETURN;
 END
 -- Eliminar registro
 DELETE FROM RETURNS
 WHERE id_return = @id_return;
END;
go

--DELETE
CREATE PROCEDURE delete_Roles
 @id_role INT
AS
BEGIN
 -- Validar que el ID del rol no esté vacío o sea inválido
 IF (@id_role IS NULL OR @id_role = 0)
 BEGIN
 RAISERROR('El ID del rol no puede estar vacío o ser inválido.', 16, 1);
 RETURN;
 END
 -- Validar que el ID del rol exista en la tabla
 IF NOT EXISTS (SELECT 1 FROM ROLES WHERE id_role = @id_role)
 BEGIN
 RAISERROR('El ID del rol no está registrado.', 16, 1);
 RETURN;
 END
 -- Validar que el rol no esté siendo referenciado en otras tablas
 -- Por ejemplo, en la tabla USERS
 IF EXISTS (SELECT 1 FROM USERS WHERE id_role = @id_role)
 BEGIN
 RAISERROR('No se puede eliminar el rol porque está siendo utilizado en la tabla
USERS.', 16, 1);
 RETURN;
 END
 -- Eliminar el rol
 DELETE FROM ROLES
 WHERE id_role = @id_role;
 PRINT 'Rol eliminado correctamente.';
END;
go

CREATE PROCEDURE delete_Sale
@id_sale INT
AS
BEGIN
-- Validación: Existencia de la venta
IF NOT EXISTS (SELECT 1 FROM SALES WHERE id_sale = @id_sale)
BEGIN
RAISERROR('El id de la venta no está registrado.', 16, 1);
RETURN;
END
-- Eliminar registro
DELETE FROM SALES
WHERE id_sale = @id_sale;
END;
go

--DELETE
CREATE   PROCEDURE delete_SaleDetail
 @id_sale_detail INT
AS
BEGIN
 -- Validar que el ID del detalle de venta no esté vacío o sea inválido
 IF (@id_sale_detail IS NULL OR @id_sale_detail = 0)
 BEGIN
 RAISERROR('El ID del detalle de venta no puede estar vacío o ser inválido.', 16, 1);
 RETURN;
 END
 -- Validar que el ID del detalle de venta exista
 IF NOT EXISTS (SELECT 1 FROM SALE_DETAILS WHERE id_sale_detail =
@id_sale_detail)
 BEGIN
 RAISERROR('El ID del detalle de venta no está registrado.', 16, 1);
 RETURN;
 END
 -- Eliminar el detalle de venta
 DELETE FROM SALE_DETAILS
 WHERE id_sale_detail = @id_sale_detail;
 PRINT 'Detalle de venta eliminado correctamente.';
END;
go

-- DELETE
CREATE PROCEDURE delete_Supplier
 @id_supplier INT
AS
BEGIN
 -- Validar que el ID del proveedor no esté vacío o sea inválido
 IF (@id_supplier IS NULL OR @id_supplier = 0)
 BEGIN
 RAISERROR('El ID del proveedor no puede estar vacío o ser inválido.', 16, 1);
 RETURN;
 END
 -- Validar que el ID del proveedor exista
 IF NOT EXISTS (SELECT 1 FROM SUPPLIERS WHERE id_supplier = @id_supplier)
 BEGIN
 RAISERROR('El ID del proveedor no está registrado.', 16, 1);
 RETURN;
 END
 -- Validar que el proveedor no esté siendo referenciado en otras tablas
 -- Por ejemplo, en la tabla PRODUCTS
 IF EXISTS (SELECT 1 FROM PRODUCTS WHERE id_supplier = @id_supplier)
 BEGIN
 RAISERROR('No se puede eliminar el proveedor porque está siendo utilizado en la tabla
PRODUCTS.', 16, 1);
 RETURN;
 END
 -- Eliminar el proveedor
 DELETE FROM SUPPLIERS
 WHERE id_supplier = @id_supplier;
 PRINT 'Proveedor eliminado correctamente.';
END;
go

-- DELETE
CREATE PROCEDURE delete_User
 @id_user INT
AS
BEGIN
 -- Validar que el ID del usuario no esté vacío o sea inválido
 IF (@id_user IS NULL OR @id_user = 0)
 BEGIN
 RAISERROR('El ID del usuario no puede estar vacío o ser inválido.', 16, 1);
 RETURN;
 END
 -- Validar que el ID del usuario exista
 IF NOT EXISTS (SELECT 1 FROM USERS WHERE id_user = @id_user)
 BEGIN
 RAISERROR('El ID del usuario no está registrado.', 16, 1);
 RETURN;
 END
 -- Eliminar el usuario
 DELETE FROM USERS
 WHERE id_user = @id_user;
 PRINT 'Usuario eliminado correctamente.';
END;
go

-- || BENEFITS ||
-- PROCEDURE BENEFITS
CREATE PROCEDURE insertBenefits
@benefit_name varchar(100),
@description text,
@points_percentage int,
@discount_percentage decimal(5,2),
@start_date date,
@end_date date
AS
BEGIN
IF (
(@benefit_name IS NULL OR LTRIM(RTRIM(@benefit_name)) = '')
OR
(@description IS NULL)
OR
(@points_percentage IS NULL OR @points_percentage = 0)
OR
(@discount_percentage IS NULL OR @discount_percentage = 0)
 )
BEGIN
RAISERROR('Alguno de los campos esta vacio.', 16, 1);
RETURN;
END
IF NOT(
(@start_date > GETDATE())
AND
(@end_date > GETDATE() AND @end_date > @start_date)
)
BEGIN
RAISERROR('El rango entre las fechas esta mal.', 16, 1);
RETURN;
END
INSERT INTO
BENEFITS(benefit_name,description,points_required,discount_percentage,start_date,end_date
)
VALUES(@benefit_name,@description,@points_percentage,@discount_percentage,@start_date,@end_date);
END;
go

-- || CUSTOMER ||
CREATE PROCEDURE insertCustomer
 @first_name VARCHAR(50),
 @last_name VARCHAR(50),
 @email VARCHAR(100),
 @phone VARCHAR(15) = NULL,
 @dui VARCHAR(10),
 @date_of_birth DATE
AS
BEGIN
 -- Validación 1: Campos obligatorios
 IF (
 @first_name IS NULL OR LTRIM(RTRIM(@first_name)) = ''
 OR @last_name IS NULL OR LTRIM(RTRIM(@last_name)) = ''
 OR @email IS NULL OR LTRIM(RTRIM(@email)) = ''
 OR @dui IS NULL OR LTRIM(RTRIM(@dui)) = ''
 OR @date_of_birth IS NULL
 )
 BEGIN
 RAISERROR('Todos los campos obligatorios deben estar completos.', 16, 1);
 RETURN;
 END
 -- Validación 2: Email único
 IF EXISTS (SELECT 1 FROM CUSTOMERS WHERE email = LTRIM(RTRIM(@email)))
 BEGIN
 RAISERROR('El email ya está registrado.', 16, 1);
 RETURN;
 END
 -- Validación 3: DUI único
 IF EXISTS (SELECT 1 FROM CUSTOMERS WHERE dui = LTRIM(RTRIM(@dui)))
 BEGIN
 RAISERROR('El DUI ya está registrado.', 16, 1);
 RETURN;
 END
 -- Validación 4: Fecha de nacimiento válida (no futura)
 IF @date_of_birth > GETDATE()
 BEGIN
 RAISERROR('La fecha de nacimiento no puede ser futura.', 16, 1);
 RETURN;
 END
 -- Insertar registro
 INSERT INTO CUSTOMERS (
 first_name,
 last_name,
 email,
 phone,
 dui,
 date_of_birth
 )
 VALUES (
 LTRIM(RTRIM(@first_name)),
 LTRIM(RTRIM(@last_name)),
 LTRIM(RTRIM(@email)),
 @phone,
 LTRIM(RTRIM(@dui)),
 @date_of_birth
 );
 -- Opcional: Retornar el ID generado
 SELECT SCOPE_IDENTITY() AS id_customer_insertado;
END;
go

-- || CARD_BENEFITS ||
-- PROCEDURE CARD_BENEFITS
CREATE PROCEDURE insert_CardBenefit
 @id_card INT,
 @id_benefit INT,
 @date_acquired DATE
AS
BEGIN
 -- Validación 1: Campos obligatorios
 IF (
 @id_card IS NULL
 OR @id_benefit IS NULL
 OR @date_acquired IS NULL
 )
 BEGIN
 RAISERROR('Todos los campos obligatorios deben estar completos.', 16, 1);
 RETURN;
 END
 -- Validación 2: Existencia de la tarjeta
 IF NOT EXISTS (SELECT 1 FROM CUSTOMER_CARD WHERE id_card = @id_card)
 BEGIN
 RAISERROR('La tarjeta no está registrada.', 16, 1);
 RETURN;
 END
 -- Validación 3: Existencia del beneficio
 IF NOT EXISTS (SELECT 1 FROM BENEFITS WHERE id_benefit = @id_benefit)
 BEGIN
 RAISERROR('El beneficio no está registrado.', 16, 1);
 RETURN;
 END
 -- Validación 4: Fecha de adquisición no futura
 IF @date_acquired > GETDATE()
 BEGIN
 RAISERROR('La fecha de adquisición no puede ser futura.', 16, 1);
 RETURN;
 END
 -- Insertar registro
 INSERT INTO CARD_BENEFITS (
 id_card,
 id_benefit,
 date_acquired,
 status_benefit
 )
 VALUES (
 @id_card,
 @id_benefit,
 @date_acquired,
 'activo'
 );
END;
go

-- ||CATEGORY||
CREATE PROCEDURE insert_Category
 @category_name VARCHAR(50),
 @description VARCHAR(250) = NULL,
 @image_category TEXT = NULL
AS
BEGIN
 -- Validación 1: Nombre de categoría obligatorio
 IF @category_name IS NULL OR LTRIM(RTRIM(@category_name)) = ''
 BEGIN
 RAISERROR('El nombre de la categoría no puede estar vacío.', 16, 1);
 RETURN;
 END
 -- Validación 2: Evitar duplicados
 IF EXISTS(SELECT * FROM CATEGORY WHERE LOWER(category_name) =
LOWER(LTRIM(RTRIM(@category_name))))
BEGIN
RAISERROR('Esta categoría ya existe en el sistema.', 16, 1);
 RETURN;
END
 -- Insertar con valores
 INSERT INTO CATEGORY (
 category_name,
 description,
 image_category
 )
 VALUES (
 LTRIM(RTRIM(@category_name)),
 @description,
 @image_category
 );
END;
go

CREATE PROCEDURE insert_Customer
 @first_name VARCHAR(50),
 @last_name VARCHAR(50),
 @email VARCHAR(100),
 @phone VARCHAR(15) = NULL,
 @dui VARCHAR(10),
 @date_of_birth DATE
AS
BEGIN
 -- Validación 1: Campos obligatorios
 IF (
 @first_name IS NULL OR LTRIM(RTRIM(@first_name)) = ''
 OR @last_name IS NULL OR LTRIM(RTRIM(@last_name)) = ''
 OR @email IS NULL OR LTRIM(RTRIM(@email)) = ''
 OR @dui IS NULL OR LTRIM(RTRIM(@dui)) = ''
 OR @date_of_birth IS NULL
 )
 BEGIN
 RAISERROR('Todos los campos obligatorios deben estar completos.', 16, 1);
 RETURN;
 END
 -- Validación 2: Email único
 IF EXISTS (SELECT 1 FROM CUSTOMERS WHERE email = LTRIM(RTRIM(@email)))
 BEGIN
 RAISERROR('El email ya está registrado.', 16, 1);
 RETURN;
 END
 -- Validación 3: DUI único
 IF EXISTS (SELECT 1 FROM CUSTOMERS WHERE dui = LTRIM(RTRIM(@dui)))
 BEGIN
 RAISERROR('El DUI ya está registrado.', 16, 1);
 RETURN;
 END
 -- Validación 4: Fecha de nacimiento válida (no futura)
 IF @date_of_birth > GETDATE()
 BEGIN
 RAISERROR('La fecha de nacimiento no puede ser futura.', 16, 1);
 RETURN;
 END
 -- Insertar registro
 INSERT INTO CUSTOMERS (
 first_name,
 last_name,
 email,
 phone,
 dui,
 date_of_birth
 )
 VALUES (
 LTRIM(RTRIM(@first_name)),
 LTRIM(RTRIM(@last_name)),
 LTRIM(RTRIM(@email)),
 @phone,
 LTRIM(RTRIM(@dui)),
 @date_of_birth
 );
 -- Opcional: Retornar el ID generado
 SELECT SCOPE_IDENTITY() AS id_customer_insertado;
END;
go

-- proceso almacenado de customer card
-- procedimiento almacenado para insert custumer card
CREATE PROCEDURE insert_CustomerCard
 @id_customer INT,
 @card_number VARCHAR(20),
 @issue_date DATE,
 @expiration_date DATE,
 @points_balance INT = 0,
 @status VARCHAR(10) = 'active'
AS
BEGIN
 -- Validar que el cliente exista en la tabla CUSTOMER
 IF NOT EXISTS (SELECT 1 FROM CUSTOMERS WHERE id_customer = @id_customer)
 BEGIN
 RAISERROR('El cliente con el ID especificado no existe.', 16, 1);
 RETURN;
 END
 -- Validar que el número de tarjeta sea único
 IF EXISTS (SELECT 1 FROM CUSTOMER_CARD WHERE card_number = @card_number)
 BEGIN
 RAISERROR('El número de tarjeta ya está registrado en el sistema.', 16, 1);
 RETURN;
 END
 -- Validar que la fecha de emisión no sea futura
 IF @issue_date > GETDATE()
 BEGIN
 RAISERROR('La fecha de emisión no puede ser una fecha futura.', 16, 1);
 RETURN;
 END
 -- Validar que la fecha de expiración no sea anterior a la fecha de emisión
 IF @expiration_date <= @issue_date
 BEGIN
 RAISERROR('La fecha de expiración debe ser posterior a la fecha de emisión.', 16, 1);
 RETURN;
 END
 -- Insertar el nuevo registro
 INSERT INTO CUSTOMER_CARD (id_customer, card_number, issue_date, expiration_date,
points_balance, status)
 VALUES (@id_customer, @card_number, @issue_date, @expiration_date,
@points_balance, @status);

END;
go

-- || DEPARTMENT ||
CREATE PROCEDURE insert_Department
@department_name varchar(50)
AS
BEGIN
IF(@department_name IS NULL)
BEGIN
RAISERROR('El nombre del departamento esta vacio.', 16, 1);
END
IF EXISTS(SELECT * FROM DEPARTMENT WHERE department_name =
@department_name)
BEGIN
RAISERROR('Ese nombre de departamento ya existe',16,1);
RETURN;
END
INSERT INTO DEPARTMENT(department_name) VALUES(@department_name);
END;
go

-- proceso almacenado de Discount
-- proecdimiento para insert Discount
CREATE PROCEDURE insert_Discount
 @discount_code VARCHAR(10),
 @discount_amount DECIMAL(10, 2),
 @description VARCHAR(100),
 @discount_type VARCHAR(50),
 @status VARCHAR(25) = 'active'
AS
BEGIN
 -- Validar que el código de descuento sea único
 IF EXISTS (SELECT 1 FROM DISCOUNT WHERE discount_code = @discount_code)
 BEGIN
 RAISERROR('El código de descuento ya está registrado en el sistema.', 16, 1);
 RETURN;
 END
 -- Validar que el monto de descuento sea positivo
 IF @discount_amount <= 0
 BEGIN
 RAISERROR('El monto de descuento debe ser un valor positivo.', 16, 1);
 RETURN;
 END
IF (@description IS NULL OR LTRIM(RTRIM(@description)) = '')
BEGIN
 RAISERROR('La descripcion es incorecta.', 16, 1);
RETURN;
END
 -- Insertar el nuevo descuento
 INSERT INTO DISCOUNT (discount_code, discount_amount, description, discount_type,
status)
 VALUES (@discount_code, @discount_amount, @description, @discount_type, @status);

END;
go

-- || DISTRICTS ||
-- INSERT
CREATE PROCEDURE insert_District
 @district_name VARCHAR(50),
 @id_department INT
AS
BEGIN
 -- Validar que los campos obligatorios no estén vacíos
 IF (
 @district_name IS NULL OR LTRIM(RTRIM(@district_name)) = '' OR
 @id_department IS NULL OR @id_department = 0
 )
 BEGIN
 RAISERROR('Los campos district_name y id_department son obligatorios.', 16, 1);
 RETURN;
 END
 -- Validar que el nombre del distrito no esté duplicado
 IF EXISTS (SELECT 1 FROM DISTRICT WHERE district_name = @district_name AND
id_department = @id_department)
 BEGIN
 RAISERROR('El nombre del distrito ya está registrado para este departamento.', 16, 1);
 RETURN;
 END
 -- Insertar el nuevo distrito
 INSERT INTO DISTRICT (district_name, id_department)
 VALUES (@district_name, @id_department);
 PRINT 'Distrito insertado correctamente.';
END;
go

-- ||PAYMENT_METHOD||
-- INSERT
CREATE PROCEDURE insert_PaymentMethod
 @method_name VARCHAR(50),
 @description VARCHAR(100)
AS
BEGIN
 -- Validar que los campos obligatorios no estén vacíos
 IF (
 @method_name IS NULL OR LTRIM(RTRIM(@method_name)) = '' OR
 @description IS NULL OR LTRIM(RTRIM(@description)) = ''
 )
 BEGIN
 RAISERROR('Los campos method_name y description son obligatorios.', 16, 1);
 RETURN;
 END
 -- Validar que el nombre del método de pago no esté duplicado
 IF EXISTS (SELECT 1 FROM PAYMENT_METHOD WHERE method_name =
@method_name)
 BEGIN
 RAISERROR('El nombre del método de pago ya está registrado.', 16, 1);
 RETURN;
 END
 -- Insertar el nuevo método de pago
 INSERT INTO PAYMENT_METHOD (method_name, description)
 VALUES (@method_name, @description);
 PRINT 'Método de pago insertado correctamente.';
END;
go


-- procedimiento almacenado para insertar POINTS HISTORY
CREATE PROCEDURE insert_PointsHistory
 @id_card INT,
 @points_change INT,
 @description VARCHAR(150) = NULL
AS
BEGIN
 -- Validación de los parámetros de entrada
 IF (@points_change IS NULL)
 BEGIN
 RAISERROR('El campo de cambio de puntos es obligatorio.', 16, 1);
 RETURN;
 END
 -- Validación de la existencia de la tarjeta de cliente
 IF (@id_card IS NOT NULL AND NOT EXISTS (SELECT 1 FROM CUSTOMER_CARD
WHERE id_card = @id_card))
 BEGIN
 RAISERROR('El ID de la tarjeta de cliente no existe en CUSTOMER_CARD.', 16, 1);
 RETURN;
 END
 -- Validación de la descripción (si es necesario)
 IF (@description IS NOT NULL AND LTRIM(RTRIM(@description)) = '')
 BEGIN
 RAISERROR('La descripción no puede estar vacía.', 16, 1);
 RETURN;
 END
 -- Insertar en POINTS_HISTORY
 INSERT INTO POINTS_HISTORY (id_card, points_change, description)
 VALUES (@id_card, @points_change, @description);
END;
go


-- Procedimiento almacenado para insertar un Product
CREATE OR ALTER PROCEDURE insert_Product
 @name_product VARCHAR(100),
 @price DECIMAL(10,2),
 @priceSup DECIMAL(10,2),
 @stock INT,
 @id_category INT = NULL,
 @id_supplier INT = NULL,
 @image_product TEXT = NULL
AS
BEGIN
 IF (
 (@name_product IS NULL OR LTRIM(RTRIM(@name_product)) = '')
 OR (@price IS NULL OR @price <= 0)
 OR (@stock IS NULL OR @stock < 0)
 )
 BEGIN
 RAISERROR('Alguno de los campos obligatorios está vacío o es inválido.', 16, 1);
 RETURN;
 END
 -- Validar si la categoría o los supplier existe antes de insertar
 IF @id_category IS NOT NULL AND NOT EXISTS (SELECT 1 FROM CATEGORY WHERE
id_category = @id_category)
 BEGIN
 RAISERROR('La categoría especificada no existe.', 16, 1);
 RETURN;
 END
IF @id_supplier IS NOT NULL AND NOT EXISTS (SELECT 1 FROM SUPPLIERS
WHERE id_supplier = @id_supplier)
 BEGIN
 RAISERROR('El supplier es especificada no existe.', 16, 1);
 RETURN;
 END

 INSERT INTO PRODUCTS (name_product, price,priceSup, stock, id_category, id_supplier,
image_product)
 VALUES (@name_product, @price,@priceSup, @stock, @id_category, @id_supplier, @image_product);
END;
go

-- || RETURNS ||
CREATE OR ALTER PROCEDURE insert_Return
 @id_customer INT = NULL,
 @id_sale INT,
 @return_date DATE,
 @description VARCHAR(250) = NULL,
 @status VARCHAR(25)
AS
BEGIN
 -- Validación 1: Campos obligatorios
 IF (
 @id_sale IS NULL
 OR @return_date IS NULL
 )
 BEGIN
 RAISERROR('Los campos obligatorios no pueden estar vacíos.', 16, 1);
 RETURN;
 END

 -- Validación 3: Existencia de la venta
 IF NOT EXISTS (SELECT 1 FROM SALES WHERE id_sale = @id_sale)
 BEGIN
 RAISERROR('La venta no está registrada.', 16, 1);
 RETURN;
 END
 -- Validación 4: Fecha de devolución no futura
 IF @return_date > GETDATE()
 BEGIN
 RAISERROR('La fecha de devolución no puede ser futura.', 16, 1);
 RETURN;
 END
 -- Insertar registro
 INSERT INTO RETURNS (
 id_customer,
 id_sale,
 return_date,
 description,
 status
 )
 VALUES (
 @id_customer,
 @id_sale,
 @return_date,
 @description,
 @status
 );
END;
go

--| PROCEDIMIENTOS ALMACENADOS Inventory Walmart |
-- |ROLES|
-- INSERT
CREATE PROCEDURE insert_Roles
 @role_name VARCHAR(50),
 @description VARCHAR(100)
AS
BEGIN
 -- Validar que el nombre del rol no esté vacío
 IF (@role_name IS NULL OR LTRIM(RTRIM(@role_name)) = '')
 BEGIN
 RAISERROR('El nombre del rol no puede estar vacío.', 16, 1);
 RETURN;
 END
 -- Validar que el rol no exista ya en la tabla
 IF EXISTS (SELECT 1 FROM ROLES WHERE role_name = @role_name)
 BEGIN
 RAISERROR('El rol ya existe en la base de datos.', 16, 1);
 RETURN;
 END
 -- Insertar el nuevo rol
 INSERT INTO ROLES (role_name, description)
 VALUES (@role_name, @description);
 PRINT 'Rol insertado correctamente.';
END;
go

-- || SALES ||
CREATE OR ALTER PROCEDURE insert_Sale
@id_customer INT = NULL,
@sale_date DATE,
@total_amount DECIMAL(10, 2),
@id_payment_method INT = NULL,
@id_discount INT = NULL,
@id_card INT = NULL,
@points_used INT = NULL,
@points_earned INT= NULL,
@id_user INT
AS
BEGIN
-- Validación 1: Campos obligatorios
IF (
@sale_date IS NULL
OR @total_amount IS NULL
OR @total_amount <= 0
)
BEGIN
RAISERROR('Los campos obligatorios no pueden estar vacíos y el monto total debe ser mayor a
0.', 16, 1);
RETURN;
END
-- Validación 2: Fecha de venta no futura
IF @sale_date > GETDATE()
BEGIN
RAISERROR('La fecha de venta no puede ser futura.', 16, 1);
RETURN;
END
IF @total_amount <= 0
BEGIN
RAISERROR('El total tiene q ser mayor a 0 ',16,1);
END
IF @id_payment_method IS NOT NULL AND NOT EXISTS (SELECT * FROM
PAYMENT_METHOD WHERE id_payment_method = @id_payment_method)
BEGIN
RAISERROR('El método de pago no está registrado.', 16, 1);
RETURN;
END
-- Validación 4: Existencia del descuento (si se proporciona)
IF @id_discount IS NOT NULL AND NOT EXISTS (SELECT 1 FROM DISCOUNT WHERE
id_discount = @id_discount)
BEGIN
RAISERROR('El descuento no está registrado.', 16, 1);
RETURN;
END
-- Insertar registro (la FK de id_customer se valida automáticamente)
INSERT INTO SALES (
id_customer,
sale_date,
total_amount,
id_payment_method,
id_discount,
id_card,
points_used,
points_earned,
id_user
)
VALUES (
@id_customer,
@sale_date,
@total_amount,
@id_payment_method,
@id_discount,
@id_card,
@points_used,
@points_earned,
@id_user
)

-- Devuelve el último ID insertado en esta sesión/ámbito
    SELECT SCOPE_IDENTITY();
END;
go

-- || SALE_DETAIL ||
CREATE PROCEDURE insert_SaleDetail
 @id_sale INT,
 @id_product INT,
 @quantity INT,
 @price DECIMAL(10, 2)
AS
BEGIN
 -- Validar que los campos obligatorios no estén vacíos
 IF (
 @id_sale IS NULL OR @id_sale = 0 OR
 @id_product IS NULL OR @id_product = 0 OR
 @quantity IS NULL OR @quantity <= 0 OR
 @price IS NULL OR @price <= 0
 )
 BEGIN
 RAISERROR('Todos los campos son obligatorios y deben tener valores válidos.', 16, 1);
 RETURN;
 END
 -- Validar que la venta exista
 IF NOT EXISTS (SELECT 1 FROM SALES WHERE id_sale = @id_sale)
 BEGIN
 RAISERROR('El ID de la venta no está registrado.', 16, 1);
 RETURN;
 END
 -- Validar que el producto exista
 IF NOT EXISTS (SELECT 1 FROM PRODUCTS WHERE id_product = @id_product)
 BEGIN
 RAISERROR('El ID del producto no está registrado.', 16, 1);
 RETURN;
 END
 -- Insertar el nuevo detalle de venta
 INSERT INTO SALE_DETAILS (id_sale, id_product, quantity, price)
 VALUES (@id_sale, @id_product, @quantity, @price);
 PRINT 'Detalle de venta insertado correctamente.';
END;
go

-- || SUPPLIERS ||
-- INSERT
CREATE PROCEDURE insert_Supplier
 @manager_name VARCHAR(50),
 @company_name VARCHAR(100),
 @email VARCHAR(100),
 @phone CHAR(9),
 @id_department INT
AS
BEGIN
 -- Validar que los campos obligatorios no estén vacíos
 IF (
 @manager_name IS NULL OR LTRIM(RTRIM(@manager_name)) = '' OR
 @company_name IS NULL OR LTRIM(RTRIM(@company_name)) = '' OR
 @email IS NULL OR LTRIM(RTRIM(@email)) = '' OR
 @phone IS NULL OR LTRIM(RTRIM(@phone)) = '' OR
 @id_department IS NULL OR @id_department = 0
 )
 BEGIN
 RAISERROR('Todos los campos son obligatorios.', 16, 1);
 RETURN;
 END
 -- Validar que el correo electrónico no esté duplicado
 IF EXISTS (SELECT 1 FROM SUPPLIERS WHERE email = @email)
 BEGIN
 RAISERROR('El correo electrónico ya está registrado.', 16, 1);
 RETURN;
 END
 -- Insertar el nuevo proveedor
 INSERT INTO SUPPLIERS (manager_name, company_name, email, phone, id_department)
 VALUES (@manager_name, @company_name, @email, @phone, @id_department);
 PRINT 'Proveedor insertado correctamente.';
END;
go

-- |USERS|
-- INSERT
CREATE PROCEDURE insert_User
 @first_name VARCHAR(50),
 @last_name VARCHAR(50),
 @date_of_birth DATE,
 @hire_date DATE,
 @cellphone VARCHAR(9),
 @dui VARCHAR(10),
 @id_department INT,
 @id_district INT,
 @id_role INT
AS
BEGIN
 -- Validar que los campos obligatorios no estén vacíos
 IF (
 @first_name IS NULL OR LTRIM(RTRIM(@first_name)) = '' OR
 @last_name IS NULL OR LTRIM(RTRIM(@last_name)) = '' OR
 @dui IS NULL OR LTRIM(RTRIM(@dui)) = ''
 )
 BEGIN
 RAISERROR('Los campos first_name, last_name y dui son obligatorios.', 16, 1);
 RETURN;
 END
 -- Validar que el DUI no esté duplicado
 IF EXISTS (SELECT 1 FROM USERS WHERE dui = @dui)
 BEGIN
 RAISERROR('El DUI ya está registrado.', 16, 1);
 RETURN;
 END
 -- Insertar el nuevo usuario
 INSERT INTO USERS (first_name, last_name, date_of_birth, hire_date, cellphone, dui,
id_department, id_district, id_role)
 VALUES (@first_name, @last_name, @date_of_birth, @hire_date, @cellphone, @dui,
@id_department, @id_district, @id_role);
 PRINT 'Usuario insertado correctamente.';
END;
go

CREATE OR ALTER PROCEDURE insert_account
    @id_user INT,
    @username VARCHAR(50),
    @pass VARCHAR(250),  
    @status_account BIT = 1        
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar campos obligatorios
    IF (
        @username IS NULL OR LTRIM(RTRIM(@username)) = '' OR
        @pass IS NULL OR LTRIM(RTRIM(@pass)) = ''
    )
    BEGIN
        RAISERROR('Los campos @username y @pass son obligatorios.', 16, 1);
        RETURN;
    END

    -- Validar unicidad del username
    IF EXISTS (SELECT 1 FROM ACCOUNT WHERE username = @username)
    BEGIN
        RAISERROR('El nombre de usuario ya existe.', 16, 1);
        RETURN;
    END
    INSERT INTO ACCOUNT (id_user, username, pass, status_account)
    VALUES (@id_user, @username,@pass, @status_account);

    SELECT SCOPE_IDENTITY() AS NewAccountId;
END;
GO

CREATE PROCEDURE update_Benefits
@id_benefit int,
@benefit_name varchar(100),
@description text,
@points_percentage int,
@discount_percentage decimal(5,2),
@start_date date,
@end_date date
AS
BEGIN
IF (
(@id_benefit IS NULL OR @id_benefit = 0)
OR
(@benefit_name IS NULL OR LTRIM(RTRIM(@benefit_name)) = '')
OR
(@description IS NULL)
OR
(@points_percentage IS NULL OR @points_percentage = 0)
OR
(@discount_percentage IS NULL OR @discount_percentage = 0)
 )
BEGIN
RAISERROR('Alguno de los campos esta vacio.', 16, 1);
RETURN;
END
IF NOT(
(@start_date > GETDATE())
AND
(@end_date > GETDATE() AND @end_date > @start_date)
)
BEGIN
RAISERROR('El rango entre las fechas esta mal.', 16, 1);
RETURN;
END
IF NOT EXISTS (SELECT 1 FROM BENEFITS WHERE id_benefit = @id_benefit)
BEGIN
RAISERROR('El id no esta registrado.', 16, 1);
END
ELSE
BEGIN
UPDATE BENEFITS SET benefit_name = @benefit_name, description =
@description, points_required = @points_percentage, discount_percentage =
@discount_percentage, start_date = @start_date, end_date = @end_date
WHERE id_benefit = @id_benefit;
END
END;
go

CREATE PROCEDURE update_CardBenefit
 @id_card_benefit INT,
 @id_card INT,
 @id_benefit INT,
 @date_acquired DATE
AS
BEGIN
 -- Validación 1: Campos obligatorios
 IF (
 @id_card_benefit IS NULL OR @id_card_benefit = 0
 OR @id_card IS NULL
 OR @id_benefit IS NULL
 OR @date_acquired IS NULL
 )
 BEGIN
 RAISERROR('Todos los campos obligatorios deben estar completos.', 16, 1);
 RETURN;
 END
 -- Validación 2: Existencia del registro en CARD_BENEFITS
 IF NOT EXISTS (SELECT 1 FROM CARD_BENEFITS WHERE id_card_benefit =
@id_card_benefit)
 BEGIN
 RAISERROR('El registro no está registrado.', 16, 1);
 RETURN;
 END
 -- Validación 3: Existencia de la tarjeta
 IF NOT EXISTS (SELECT 1 FROM CUSTOMER_CARD WHERE id_card = @id_card)
 BEGIN
 RAISERROR('La tarjeta no está registrada.', 16, 1);
 RETURN;
 END
 -- Validación 4: Existencia del beneficio
 IF NOT EXISTS (SELECT 1 FROM BENEFITS WHERE id_benefit = @id_benefit)
 BEGIN
 RAISERROR('El beneficio no está registrado.', 16, 1);
 RETURN;
 END
 -- Validación 5: Fecha de adquisición no futura
 IF @date_acquired > GETDATE()
 BEGIN
 RAISERROR('La fecha de adquisición no puede ser futura.', 16, 1);
 RETURN;
 END
 -- Actualizar registro
 UPDATE CARD_BENEFITS
 SET
 id_card = @id_card,
 id_benefit = @id_benefit,
 date_acquired = @date_acquired
 WHERE id_card_benefit = @id_card_benefit;
END;
go

CREATE PROCEDURE update_Category
 @id_category INT,
 @category_name VARCHAR(50),
 @description VARCHAR(250) = NULL,
 @image_category TEXT = NULL
AS
BEGIN
 -- Validación 1: Campos obligatorios
 IF (
 @id_category IS NULL
 OR LTRIM(RTRIM(@category_name)) = ''
 )
 BEGIN
 RAISERROR('El nombre de la categoría no puede estar vacío.', 16, 1);
 RETURN;
 END
 -- Validación 2: Existencia de la categoría
 IF NOT EXISTS (SELECT * FROM CATEGORY WHERE id_category = @id_category)
 BEGIN
 RAISERROR('El id de la categoría no está registrado.', 16, 1);
 RETURN;
 END
 -- Actualizar registro
 UPDATE CATEGORY
 SET
 category_name = LTRIM(RTRIM(@category_name)),
 description = @description,
 image_category = @image_category
 WHERE id_category = @id_category;
END;
go

CREATE PROCEDURE update_Customer
 @id_customer INT,
 @first_name VARCHAR(50),
 @last_name VARCHAR(50),
 @email VARCHAR(100),
 @phone VARCHAR(15) = NULL,
 @dui VARCHAR(10),
 @date_of_birth DATE
AS
BEGIN
 -- Validación 1: Campos obligatorios
 IF (
 @id_customer IS NULL OR @id_customer = 0
 OR @first_name IS NULL OR LTRIM(RTRIM(@first_name)) = ''
 OR @last_name IS NULL OR LTRIM(RTRIM(@last_name)) = ''
 OR @email IS NULL OR LTRIM(RTRIM(@email)) = ''
 OR @dui IS NULL OR LTRIM(RTRIM(@dui)) = ''
 OR @date_of_birth IS NULL
 )
 BEGIN
 RAISERROR('Alguno de los campos está vacío.', 16, 1);
 RETURN;
 END
 -- Validación 2: Existencia del cliente
 IF NOT EXISTS (SELECT 1 FROM CUSTOMERS WHERE id_customer = @id_customer)
 BEGIN
 RAISERROR('El id no está registrado.', 16, 1);
 RETURN;
 END
 -- Validación 3: Email único (excluyendo el registro actual)
 IF EXISTS (
 SELECT 1
 FROM CUSTOMERS
 WHERE email = LTRIM(RTRIM(@email))
 AND id_customer <> @id_customer
 )
 BEGIN
 RAISERROR('El email ya está registrado.', 16, 1);
 RETURN;
 END
 -- Validación 4: DUI único (excluyendo el registro actual)
 IF EXISTS (
 SELECT 1
 FROM CUSTOMERS
 WHERE dui = LTRIM(RTRIM(@dui))
 AND id_customer <> @id_customer
 )
 BEGIN
 RAISERROR('El DUI ya está registrado.', 16, 1);
 RETURN;
 END
 -- Validación 5: Fecha de nacimiento válida (no futura)
 IF @date_of_birth > GETDATE()
 BEGIN
 RAISERROR('La fecha de nacimiento no puede ser futura.', 16, 1);
 RETURN;
 END
 -- Actualizar registro
 UPDATE CUSTOMERS
 SET
 first_name = LTRIM(RTRIM(@first_name)),
 last_name = LTRIM(RTRIM(@last_name)),
 email = LTRIM(RTRIM(@email)),
 phone = @phone,
 dui = LTRIM(RTRIM(@dui)),
 date_of_birth = @date_of_birth
 WHERE id_customer = @id_customer;
END;
go

-- procedimiendo para update custumer card
CREATE PROCEDURE update_CustomerCard
 @id_card INT,
 @id_customer INT = NULL,
 @card_number VARCHAR(20) = NULL,
 @issue_date DATE = NULL,
 @expiration_date DATE = NULL,
 @points_balance INT = NULL,
 @status VARCHAR(10) = NULL
AS
BEGIN
 -- Verificar que la tarjeta de cliente exista
 IF NOT EXISTS (SELECT 1 FROM CUSTOMER_CARD WHERE id_card = @id_card)
 BEGIN
 RAISERROR('La tarjeta de cliente con el ID especificado no existe.', 16, 1);
 RETURN;
 END
 -- Validar que el cliente exista en la tabla CUSTOMER si se proporciona @id_customer
 IF (@id_customer IS NOT NULL AND NOT EXISTS (SELECT 1 FROM CUSTOMERS
WHERE id_customer = @id_customer))
 BEGIN
 RAISERROR('El cliente con el ID especificado no existe.', 16, 1);
 RETURN;
 END
 -- Validar que el número de tarjeta sea único si se proporciona un nuevo @card_number
 IF (@card_number IS NOT NULL AND EXISTS (SELECT 1 FROM CUSTOMER_CARD
WHERE card_number = @card_number AND id_card != @id_card))
 BEGIN
 RAISERROR('El número de tarjeta ya está registrado en el sistema.', 16, 1);
 RETURN;
 END
 -- Validar que la fecha de emisión no sea futura si se proporciona
 IF (@issue_date IS NOT NULL AND @issue_date > GETDATE())
 BEGIN
 RAISERROR('La fecha de emisión no puede ser una fecha futura.', 16, 1);
 RETURN;
 END
 -- Validar que la fecha de expiración no sea anterior a la fecha de emisión si se proporcionan
--ambas
 IF (@issue_date IS NOT NULL AND @expiration_date IS NOT NULL AND @expiration_date
<= @issue_date)
 BEGIN
 RAISERROR('La fecha de expiración debe ser posterior a la fecha de emisión.', 16, 1);
 RETURN;
 END
-- Actualizar los campos proporcionados
 UPDATE CUSTOMER_CARD
 SET
 id_customer = COALESCE(@id_customer, id_customer),
 card_number = COALESCE(@card_number, card_number),
 issue_date = COALESCE(@issue_date, issue_date),
 expiration_date = COALESCE(@expiration_date, expiration_date),
 points_balance = COALESCE(@points_balance, points_balance),
 status = COALESCE(@status, status)
 WHERE id_card = @id_card;

END;
go


-- UPADTE
CREATE PROCEDURE update_Department
@id_department int,
@department_name varchar(50)
AS
BEGIN
IF NOT EXISTS(SELECT * FROM DEPARTMENT WHERE id_department =
@id_department)
BEGIN
RAISERROR('El id no está registrado.', 16, 1);
 RETURN;
END;
IF(@department_name IS NULL)
BEGIN
RAISERROR('El nombre del departamento esta vacio.', 16, 1);
END
IF EXISTS( SELECT * FROM DEPARTMENT WHERE department_name =
@department_name)
BEGIN
RAISERROR('El nombre del departamento ya existe.', 16, 1);
END
UPDATE DEPARTMENT SET department_name = @department_name WHERE
id_department = @id_department;
END;
go

-- procedimiento para update Discount
CREATE PROCEDURE update_Discount
 @id_discount INT,
 @discount_code VARCHAR(10) = NULL,
 @discount_amount DECIMAL(10, 2) = NULL,
 @description VARCHAR(100) = NULL,
 @discount_type VARCHAR(50) = NULL,
 @status VARCHAR(25) = NULL
AS
BEGIN
 -- Verificar que el descuento exista
 IF NOT EXISTS (SELECT 1 FROM DISCOUNT WHERE id_discount = @id_discount)
 BEGIN
 RAISERROR('El descuento con el ID especificado no existe.', 16, 1);
 RETURN;
 END
 -- Validar que el código de descuento sea único si se proporciona uno nuevo
 IF (@discount_code IS NOT NULL AND EXISTS (SELECT 1 FROM DISCOUNT WHERE
discount_code = @discount_code AND id_discount != @id_discount))
 BEGIN
 RAISERROR('El código de descuento ya está registrado en el sistema.', 16, 1);
 RETURN;
 END
 -- Validar que el monto de descuento sea positivo si se proporciona
 IF (@discount_amount IS NOT NULL AND @discount_amount <= 0)
 BEGIN
 RAISERROR('El monto de descuento debe ser un valor positivo.', 16, 1);
 RETURN;
 END
 -- Actualizar los campos proporcionados
 UPDATE DISCOUNT
 SET
 discount_code = COALESCE(@discount_code, discount_code),
 discount_amount = COALESCE(@discount_amount, discount_amount),
 description = COALESCE(@description, description),
 discount_type = COALESCE(@discount_type, discount_type),
 status = COALESCE(@status, status)
 WHERE id_discount = @id_discount;

END;
go

--UPDATE
CREATE PROCEDURE update_District
 @id_district INT,
 @district_name VARCHAR(50),
 @id_department INT
AS
BEGIN
 -- Validar que el ID del distrito no esté vacío o sea inválido
 IF (@id_district IS NULL OR @id_district = 0)
 BEGIN
 RAISERROR('El ID del distrito no puede estar vacío o ser inválido.', 16, 1);
 RETURN;
 END
 -- Validar que los campos obligatorios no estén vacíos
 IF (
 @district_name IS NULL OR LTRIM(RTRIM(@district_name)) = '' OR
 @id_department IS NULL OR @id_department = 0
 )
 BEGIN
 RAISERROR('Los campos district_name y id_department son obligatorios.', 16, 1);
 RETURN;
 END
 -- Validar que el ID del distrito exista
 IF NOT EXISTS (SELECT 1 FROM DISTRICT WHERE id_district = @id_district)
 BEGIN
 RAISERROR('El ID del distrito no está registrado.', 16, 1);
 RETURN;
 END
 -- Validar que el nombre del distrito no esté duplicado (excepto para el mismo distrito)
 IF EXISTS (SELECT 1 FROM DISTRICT WHERE district_name = @district_name AND
id_department = @id_department AND id_district != @id_district)
 BEGIN
 RAISERROR('El nombre del distrito ya está registrado para este departamento.', 16, 1);
 RETURN;
 END
 -- Actualizar el distrito
 UPDATE DISTRICT
 SET district_name = @district_name,
 id_department = @id_department
 WHERE id_district = @id_district;
 PRINT 'Distrito actualizado correctamente.';
END;
go

-- UPDATE
CREATE   PROCEDURE update_PaymentMethod
 @id_payment_method INT,
 @method_name VARCHAR(50),
 @description VARCHAR(100)
AS
BEGIN
 -- Validar que el ID del método de pago no esté vacío o sea inválido
 IF (@id_payment_method IS NULL OR @id_payment_method = 0)
 BEGIN
 RAISERROR('El ID del método de pago no puede estar vacío o ser inválido.', 16, 1);
 RETURN;
 END
 -- Validar que los campos obligatorios no estén vacíos
 IF (
 @method_name IS NULL OR LTRIM(RTRIM(@method_name)) = '' OR
 @description IS NULL OR LTRIM(RTRIM(@description)) = ''
 )
 BEGIN
 RAISERROR('Los campos method_name y description son obligatorios.', 16, 1);
 RETURN;
 END
 -- Validar que el ID del método de pago exista
 IF NOT EXISTS (SELECT 1 FROM PAYMENT_METHOD WHERE id_payment_method =
@id_payment_method)
 BEGIN
 RAISERROR('El ID del método de pago no está registrado.', 16, 1);
 RETURN;
 END
 -- Validar que el nombre del método de pago no esté duplicado (excepto para el mismo
-- método de pago)
 IF EXISTS (SELECT 1 FROM PAYMENT_METHOD WHERE method_name =
@method_name AND id_payment_method != @id_payment_method)
 BEGIN
 RAISERROR('El nombre del método de pago ya está registrado para otro método.', 16, 1);
 RETURN;
 END
 -- Actualizar el método de pago
 UPDATE PAYMENT_METHOD
 SET method_name = @method_name,
 description = @description
 WHERE id_payment_method = @id_payment_method;
 PRINT 'Método de pago actualizado correctamente.';
END;
go

-- Procedimiento almacenado para actualizar los POINTS_HISTORY
CREATE PROCEDURE update_PointsHistory
 @id_points_history INT,
 @id_card INT = NULL,
 @points_change INT = NULL,
 @description VARCHAR(150) = NULL
AS
BEGIN
 -- Verificar que el registro a actualizar exista
 IF NOT EXISTS (SELECT 1 FROM POINTS_HISTORY WHERE id_points_history =
@id_points_history)
 BEGIN
 RAISERROR('El registro de PointsHistory con el ID especificado no existe.', 16, 1);
 RETURN;
 END
 -- Validación de la existencia de la tarjeta de cliente (si se proporciona @id_card)
 IF (@id_card IS NOT NULL AND NOT EXISTS (SELECT 1 FROM CUSTOMER_CARD
WHERE id_card = @id_card))
 BEGIN
 RAISERROR('El ID de la tarjeta de cliente no existe en CUSTOMER_CARD.', 16, 1);
 RETURN;
 END
 -- Validación del campo de puntos (si se proporciona @points_change)
 IF (@points_change IS NOT NULL AND @points_change = 0)
 BEGIN
 RAISERROR('El cambio de puntos no puede ser cero.', 16, 1);
 RETURN;
 END
 -- Validación de la descripción (si se proporciona @description)
 IF (@description IS NOT NULL AND LTRIM(RTRIM(@description)) = '')
 BEGIN
 RAISERROR('La descripción no puede estar vacía.', 16, 1);
 RETURN;
 END
 -- Actualizar los campos proporcionados
 UPDATE POINTS_HISTORY
 SET
 id_card = COALESCE(@id_card, id_card),
 points_change = COALESCE(@points_change, points_change),
 description = COALESCE(@description, description)
 WHERE id_points_history = @id_points_history;

END;
go

-- Procedimiento almacenado para update un producto
CREATE PROCEDURE update_Product
 @id_product INT,
 @name_product VARCHAR(100),
 @price DECIMAL(10,2),
 @stock INT,
 @id_category INT = NULL,
 @id_supplier INT = NULL,
 @image_product TEXT = NULL
AS
BEGIN
 IF (
 (@id_product IS NULL OR @id_product = 0)
 OR (@name_product IS NULL OR LTRIM(RTRIM(@name_product)) = '')
 OR (@price IS NULL OR @price <= 0)
 OR (@stock IS NULL OR @stock < 0)
 )
 BEGIN
 RAISERROR('Alguno de los campos obligatorios está vacío o es inválido.', 16, 1);
 RETURN;
 END
 -- Validar si la categoría o los supplier existe antes de insertar
 IF @id_category IS NOT NULL AND NOT EXISTS (SELECT 1 FROM CATEGORY WHERE
id_category = @id_category)
 BEGIN
 RAISERROR('La categoría especificada no existe.', 16, 1);
 RETURN;
 END
IF @id_supplier IS NOT NULL AND NOT EXISTS (SELECT 1 FROM SUPPLIERS
WHERE id_supplier = @id_supplier)
 BEGIN
 RAISERROR('El supplier es especificada no existe.', 16, 1);
 RETURN;
 END

 IF NOT EXISTS (SELECT 1 FROM PRODUCTS WHERE id_product = @id_product)
 BEGIN
 RAISERROR('El ID del producto no está registrado.', 16, 1);
 RETURN;
 END

 UPDATE PRODUCTS
 SET name_product = @name_product,
 price = @price,
 stock = @stock,
 id_category = @id_category,
 id_supplier = @id_supplier,
 image_product = @image_product
 WHERE id_product = @id_product;
END;
go

CREATE PROCEDURE update_Return
@id_return INT,
 @id_customer INT,
 @id_sale INT,
 @return_date DATE,
 @description VARCHAR(150) = NULL,
 @status VARCHAR(25)
AS
BEGIN
 -- Validación 1: Campos obligatorios
 IF (
 @id_customer IS NULL
 OR @id_sale IS NULL
 OR @return_date IS NULL
 OR @status IS NULL OR LTRIM(RTRIM(@status)) = ''
 )
 BEGIN
 RAISERROR('Los campos obligatorios no pueden estar vacíos.', 16, 1);
 RETURN;
 END
 -- Validación 2: Existencia del cliente
 IF NOT EXISTS (SELECT 1 FROM CUSTOMERS WHERE id_customer = @id_customer)
 BEGIN
 RAISERROR('El cliente no está registrado.', 16, 1);
 RETURN;
 END
 -- Validación 3: Existencia de la venta
 IF NOT EXISTS (SELECT 1 FROM SALES WHERE id_sale = @id_sale)
 BEGIN
 RAISERROR('La venta no está registrada.', 16, 1);
 RETURN;
 END
 -- Validación 4: Fecha de devolución no futura
 IF @return_date > GETDATE()
 BEGIN
 RAISERROR('La fecha de devolución no puede ser futura.', 16, 1);
 RETURN;
 END
-- Validacion 5: Existencia del retorno
IF NOT EXISTS(SELECT * FROM RETURNS WHERE id_return = @id_return)
BEGIN
RAISERROR('El id de la devolucion no existe.', 16, 1);
 RETURN;
END
 -- Actualizar registro
 UPDATE RETURNS
 SET
 id_customer = @id_customer,
 id_sale = @id_sale,
 return_date = @return_date,
 description= @description,
status = @status
 WHERE id_sale = @id_sale;
END;
go

-- UPDATE
CREATE PROCEDURE update_Roles
 @id_role INT,
 @role_name VARCHAR(50),
 @description VARCHAR(100)
AS
BEGIN
 -- Validar que el ID del rol no esté vacío o sea inválido
 IF (@id_role IS NULL OR @id_role = 0)
 BEGIN
 RAISERROR('El ID del rol no puede estar vacío o ser inválido.', 16, 1);
 RETURN;
 END
 -- Validar que el nombre del rol no esté vacío
 IF (@role_name IS NULL OR LTRIM(RTRIM(@role_name)) = '')
 BEGIN
 RAISERROR('El nombre del rol no puede estar vacío.', 16, 1);
 RETURN;
 END
 -- Validar que el ID del rol exista en la tabla
 IF NOT EXISTS (SELECT 1 FROM ROLES WHERE id_role = @id_role)
 BEGIN
 RAISERROR('El ID del rol no está registrado.', 16, 1);
 RETURN;
 END
 -- Validar que el nuevo nombre del rol no esté duplicado (excepto para el mismo rol)
 IF EXISTS (SELECT 1 FROM ROLES WHERE role_name = @role_name AND id_role !=
@id_role)
 BEGIN
 RAISERROR('El nombre del rol ya existe en la base de datos.', 16, 1);
 RETURN;
 END
 -- Actualizar el rol
 UPDATE ROLES
 SET role_name = @role_name,
 description = @description
 WHERE id_role = @id_role;
 PRINT 'Rol actualizado correctamente.';
END;
go

CREATE PROCEDURE update_Sale
@id_sale INT,
@id_customer INT,
@sale_date DATE,
@total_amount DECIMAL(10, 2),
@id_payment_method INT = NULL,
@id_discount INT = NULL
AS
BEGIN
-- Validación 1: Campos obligatorios
IF (
@id_sale IS NULL OR @id_sale = 0
OR @id_customer IS NULL
OR @sale_date IS NULL
OR @total_amount IS NULL OR @total_amount <= 0
)
BEGIN
RAISERROR('Alguno de los campos está vacío o el monto total es inválido.', 16, 1);
RETURN;
END
-- Validación 2: Existencia de la venta
IF NOT EXISTS (SELECT 1 FROM SALES WHERE id_sale = @id_sale)
BEGIN
RAISERROR('El id de la venta no está registrado.', 16, 1);
RETURN;
END
-- Validación 3: Existencia del cliente
IF NOT EXISTS (SELECT * FROM CUSTOMERS WHERE id_customer = @id_customer)
BEGIN
RAISERROR('El cliente no está registrado.', 16, 1);
RETURN;
END
-- Validación 4: Fecha de venta no futura
IF @sale_date > GETDATE()
BEGIN
RAISERROR('La fecha de venta no puede ser futura.', 16, 1);
RETURN;
END
-- Validación 5: Existencia del método de pago (si se proporciona)
IF @id_payment_method IS NOT NULL AND NOT EXISTS (SELECT 1 FROM PAYMENT_METHOD
WHERE id_payment_method = @id_payment_method)
BEGIN
RAISERROR('El método de pago no está registrado.', 16, 1);
RETURN;
END
-- Validación 6: Existencia del descuento (si se proporciona)
IF @id_discount IS NOT NULL AND NOT EXISTS (SELECT 1 FROM DISCOUNT WHERE
id_discount = @id_discount)
BEGIN
RAISERROR('El descuento no está registrado.', 16, 1);
RETURN;
END
-- Actualizar registro
UPDATE SALES
SET
id_customer = @id_customer,
sale_date = @sale_date,
total_amount = @total_amount,
id_payment_method = @id_payment_method,
id_discount = @id_discount
WHERE id_sale = @id_sale;
END;
go

--UPDATE
CREATE   PROCEDURE update_SaleDetail
 @id_sale_detail INT,
 @id_sale INT,
 @id_product INT,
 @quantity INT,
 @price DECIMAL(10, 2)
AS
BEGIN
 -- Validar que el ID del detalle de venta no esté vacío o sea inválido
 IF (@id_sale_detail IS NULL OR @id_sale_detail = 0)
 BEGIN
 RAISERROR('El ID del detalle de venta no puede estar vacío o ser inválido.', 16, 1);
 RETURN;
 END
 -- Validar que los campos obligatorios no estén vacíos
 IF (
 @id_sale IS NULL OR @id_sale = 0 OR
 @id_product IS NULL OR @id_product = 0 OR
 @quantity IS NULL OR @quantity <= 0 OR
 @price IS NULL OR @price <= 0
 )
 BEGIN
 RAISERROR('Todos los campos son obligatorios y deben tener valores válidos.', 16, 1);
 RETURN;
 END
 -- Validar que el ID del detalle de venta exista
 IF NOT EXISTS (SELECT 1 FROM SALE_DETAILS WHERE id_sale_detail =
@id_sale_detail)
 BEGIN
 RAISERROR('El ID del detalle de venta no está registrado.', 16, 1);
 RETURN;
 END
 -- Validar que la venta exista
 IF NOT EXISTS (SELECT 1 FROM SALES WHERE id_sale = @id_sale)
 BEGIN
 RAISERROR('El ID de la venta no está registrado.', 16, 1);
 RETURN;
 END
 -- Validar que el producto exista
 IF NOT EXISTS (SELECT 1 FROM PRODUCTS WHERE id_product = @id_product)
 BEGIN
 RAISERROR('El ID del producto no está registrado.', 16, 1);
 RETURN;
 END
 -- Actualizar el detalle de venta
 UPDATE SALE_DETAILS
 SET id_sale = @id_sale,
 id_product = @id_product,
 quantity = @quantity,
 price = @price
 WHERE id_sale_detail = @id_sale_detail;
 PRINT 'Detalle de venta actualizado correctamente.';
END;
go

-- UPDATE
CREATE   PROCEDURE update_Supplier
 @id_supplier INT,
 @manager_name VARCHAR(50),
 @company_name VARCHAR(100),
 @email VARCHAR(100),
 @phone CHAR(9),
 @id_department INT
AS
BEGIN
 -- Validar que el ID del proveedor no esté vacío o sea inválido
 IF (@id_supplier IS NULL OR @id_supplier = 0)
 BEGIN
 RAISERROR('El ID del proveedor no puede estar vacío o ser inválido.', 16, 1);
 RETURN;
 END
 -- Validar que los campos obligatorios no estén vacíos
 IF (
 @manager_name IS NULL OR LTRIM(RTRIM(@manager_name)) = '' OR
 @company_name IS NULL OR LTRIM(RTRIM(@company_name)) = '' OR
 @email IS NULL OR LTRIM(RTRIM(@email)) = '' OR
 @phone IS NULL OR LTRIM(RTRIM(@phone)) = '' OR
 @id_department IS NULL OR @id_department = 0
 )
 BEGIN
 RAISERROR('Todos los campos son obligatorios.', 16, 1);
 RETURN;
 END
 -- Validar que el ID del proveedor exista
 IF NOT EXISTS (SELECT 1 FROM SUPPLIERS WHERE id_supplier = @id_supplier)
 BEGIN
 RAISERROR('El ID del proveedor no está registrado.', 16, 1);
 RETURN;
 END
 -- Validar que el correo electrónico no esté duplicado (excepto para el mismo proveedor)
 IF EXISTS (SELECT 1 FROM SUPPLIERS WHERE email = @email AND id_supplier !=
@id_supplier)
 BEGIN
 RAISERROR('El correo electrónico ya está registrado para otro proveedor.', 16, 1);
 RETURN;
 END
 -- Actualizar el proveedor
 UPDATE SUPPLIERS
 SET manager_name = @manager_name,
 company_name = @company_name,
 email = @email,
 phone = @phone,
 id_department = @id_department
 WHERE id_supplier = @id_supplier;
 PRINT 'Proveedor actualizado correctamente.';
END;
go

-- UPDATE
CREATE PROCEDURE update_User
 @id_user INT,
 @first_name VARCHAR(50),
 @last_name VARCHAR(50),
 @date_of_birth DATE,
 @hire_date DATE,
 @cellphone VARCHAR(9),
 @dui VARCHAR(10),
 @id_department INT,
 @id_district INT,
 @id_role INT
AS
BEGIN
 -- Validar que el ID del usuario no esté vacío o sea inválido
 IF (@id_user IS NULL OR @id_user = 0)
 BEGIN
 RAISERROR('El ID del usuario no puede estar vacío o ser inválido.', 16, 1);
 RETURN;
 END
 -- Validar que los campos obligatorios no estén vacíos
 IF (
 @first_name IS NULL OR LTRIM(RTRIM(@first_name)) = '' OR
 @last_name IS NULL OR LTRIM(RTRIM(@last_name)) = '' OR
 @dui IS NULL OR LTRIM(RTRIM(@dui)) = ''
 )
 BEGIN
 RAISERROR('Los campos first_name, last_name y dui son obligatorios.', 16, 1);
 RETURN;
 END
 -- Validar que el ID del usuario exista
 IF NOT EXISTS (SELECT 1 FROM USERS WHERE id_user = @id_user)
 BEGIN
 RAISERROR('El ID del usuario no está registrado.', 16, 1);
 RETURN;
 END
 -- Actualizar el usuario
 UPDATE USERS
 SET first_name = @first_name,
 last_name = @last_name,
 date_of_birth = @date_of_birth,
 hire_date = @hire_date,
 cellphone = @cellphone,
 dui = @dui,
 id_department = @id_department,
 id_district = @id_district,
 id_role = @id_role
 WHERE id_user = @id_user;
 PRINT 'Usuario actualizado correctamente.';
END;
go

