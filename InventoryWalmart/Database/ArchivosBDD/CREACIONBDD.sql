USE master;
GO

CREATE DATABASE InventoryWalmart ON
(NAME = InventoryWalmartdata,
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\InventoryWalmartdata.mdf',
    SIZE = 10,
    MAXSIZE = 50,
    FILEGROWTH = 5)
LOG ON
(NAME = InventoryWalmartlog,
    FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\InventoryWalmart.ldf',
    SIZE = 5 MB,
    MAXSIZE = 25 MB,
    FILEGROWTH = 5 MB);
GO

USE inventoryWalmart;
GO

CREATE TABLE PRODUCTS (
    id_product INT IDENTITY(1,1) PRIMARY KEY,
    name_product VARCHAR(100) NOT NULL,
    price DECIMAL(10, 2) NOT NULL,
	priceSup decimal(10,2) not null,
    stock INT NOT NULL,
    id_category INT,
    id_supplier INT,
    image_product TEXT
);

CREATE TABLE PAYMENT_METHOD (
    id_payment_method INT IDENTITY(1,1) PRIMARY KEY,
    method_name VARCHAR(50) NOT NULL,
    description VARCHAR(100)
);

CREATE TABLE SUPPLIERS (
    id_supplier INT IDENTITY(1,1) PRIMARY KEY,
    manager_name VARCHAR(50) NOT NULL,
    company_name VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE,
    phone CHAR(9) NOT NULL,
    id_department INT
);

CREATE TABLE DEPARTMENT (
    id_department INT IDENTITY(1,1) PRIMARY KEY,
    department_name VARCHAR(50) NOT NULL
);

CREATE TABLE DISTRICT (
    id_district INT IDENTITY(1,1) PRIMARY KEY,
    district_name VARCHAR(50) NOT NULL,
    id_department INT
);

CREATE TABLE CATEGORY (
    id_category INT IDENTITY(1,1) PRIMARY KEY,
    category_name VARCHAR(50) NOT NULL,
    description VARCHAR(250),
    image_category TEXT
);

CREATE TABLE USERS (
    id_user INT IDENTITY(1,1) PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    date_of_birth DATE,
    hire_date DATE,
    cellphone VARCHAR(9),
    dui VARCHAR(10) UNIQUE,
    id_department INT,
    id_district INT,
    id_role INT
);

CREATE TABLE ROLES (
    id_role INT IDENTITY(1,1) PRIMARY KEY,
    role_name VARCHAR(50) NOT NULL,
    description VARCHAR(100)
);

CREATE TABLE CUSTOMERS (
    id_customer INT IDENTITY(1,1) PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    email VARCHAR(100) UNIQUE,
    phone VARCHAR(15),
    dui VARCHAR(10) UNIQUE,
    date_of_birth DATE
);

CREATE TABLE SALES (
    id_sale INT IDENTITY(1,1) PRIMARY KEY,
    id_customer INT,
    sale_date DATE NOT NULL,
    total_amount DECIMAL(10, 2) NOT NULL,
    id_payment_method INT,
    id_discount INT,
	id_card INT,
    points_used INT DEFAULT 0,  -- Puntos usados en la venta
    points_earned INT DEFAULT 0  -- Puntos ganados en la venta
);

CREATE TABLE SALE_DETAILS (
    id_sale_detail INT IDENTITY(1,1) PRIMARY KEY,
    id_sale INT,
    id_product INT,
    quantity INT NOT NULL,
    price DECIMAL(10, 2) NOT NULL
);

CREATE TABLE DISCOUNT (
    id_discount INT IDENTITY(1,1) PRIMARY KEY,
    discount_code VARCHAR(10) UNIQUE,
    discount_amount DECIMAL(10, 2),
    description VARCHAR(100),
    discount_type VARCHAR(50),
    status VARCHAR(25)
);

CREATE TABLE RETURNS (
    id_return INT IDENTITY(1,1) PRIMARY KEY,
    id_customer INT,
    id_sale INT,
    return_date DATE NOT NULL,
    description VARCHAR(150),
    status VARCHAR(25)
);

CREATE TABLE CUSTOMER_CARD (
    id_card INT IDENTITY(1,1) PRIMARY KEY,
    id_customer INT UNIQUE,  -- Relaci�n uno a uno con el cliente
    card_number VARCHAR(20) UNIQUE NOT NULL,  
    issue_date DATE NOT NULL,  -- Fecha de emisi�n
    expiration_date DATE NOT NULL,  -- Fecha de expiraci�n
    points_balance INT DEFAULT 0,  
    status VARCHAR(10) DEFAULT 'active' CHECK (status IN ('active', 'inactive', 'expired'))
);

CREATE TABLE BENEFITS (
    id_benefit INT IDENTITY(1,1) PRIMARY KEY,
    benefit_name VARCHAR(100) NOT NULL,  -- Nombre del beneficio
    description TEXT,  -- Descripci�n del beneficio
    points_required INT,  -- Puntos necesarios para obtener el beneficio
    discount_percentage DECIMAL(5, 2),  -- Porcentaje de descuento (si aplica)
    start_date DATE,  -- Fecha de inicio del beneficio
    end_date DATE  -- Fecha de fin del beneficio
);

CREATE TABLE CARD_BENEFITS (
    id_card_benefit INT IDENTITY(1,1)PRIMARY KEY,
    id_card INT,
    id_benefit INT,
    date_acquired DATE  -- Fecha en que el cliente adquiri� el beneficio
);

CREATE TABLE POINTS_HISTORY (
    id_points_history INT IDENTITY(1,1) PRIMARY KEY,
    id_card INT,
    points_change INT NOT NULL,  -- Cambio en los puntos (puede ser positivo o negativo)
    change_date DATETIME DEFAULT CURRENT_TIMESTAMP,  -- Fecha del cambio
    description VARCHAR(150)  -- Descripci�n del cambio (ej: "Compra realizada", "Beneficio canjeado")  
);

CREATE TABLE profitsReinvestment
(
	idProfitReinvestment int PRIMARY KEY IDENTITY(1,1),
	idProduct int,
	profits decimal(10,2),
	reinvestment decimal(10,2)
	FOREIGN KEY (idProduct) REFERENCES PRODUCTS(id_product)
);
GO

CREATE TABLE REPORT_SALES(
	id_report_sale int PRIMARY KEY IDENTITY(1,1),
	startDayWeek date not null,
	lastDayWeek date not null,
	quantitySales int,
	priceTotal decimal(10,2)

);
GO

CREATE TABLE recordSales (
    id_recordSales INT PRIMARY KEY,
    id_customer INT,
    sale_Date DATE, 
    totalAmount DECIMAL(10,2)
);
GO

CREATE TABLE ErrorsLogs (
    id_errorLog INT IDENTITY(1,1) PRIMARY KEY,  -- ID autoincremental
    nameuser VARCHAR(15) NOT NULL,
    startDate DATE DEFAULT GETDATE(),  -- Fecha del intento
    hourDate TIME DEFAULT CONVERT(TIME, GETDATE())  -- Hora del intento
);
GO

Create table PRICE_HISTORY (
	id_price_history INT IDENTITY(1,1) PRIMARY KEY,  -- Identificador �nico
	id_product INT NOT NULL, -- Producto al que se realiza el cambio
	old_price DECIMAL(10, 2) NOT NULL, -- Precio anterios
	new_price DECIMAL(10, 2) NOT NULL, -- Nuevo precio
	change_date DATETIME DEFAULT GETDATE(), -- Fecha en que se realizo el cambio
	changed_by VARCHAR(100) -- Quien realizo el cambio
);

CREATE TABLE ACCOUNT (
    id_account INT IDENTITY(1,1) PRIMARY KEY,
    id_user INT NOT NULL,
    username varchar (30) NOT NULL,
    pass varchar (250)NOT NULL,
    status_account BIT
);


ALTER TABLE SALES
ADD FOREIGN KEY (id_card) REFERENCES CUSTOMER_CARD(id_card);
go
--Relation
--products
ALTER TABLE Products add constraint category_product
FOREIGN KEY (id_category) REFERENCES CATEGORY(id_category);
ALTER TABLE Products add constraint supliers_product
FOREIGN KEY (id_supplier) REFERENCES SUPPLIERS(id_supplier);
-- SUPPLIERS
ALTER TABLE Suppliers add constraint supliersDeparment
FOREIGN KEY (id_department) REFERENCES DEPARTMENT(id_department);
--district 
ALTER TABLE District add constraint deparment_district
FOREIGN KEY (id_department) REFERENCES DEPARTMENT(id_department);
ALTER TABLE Users add constraint district_user
FOREIGN KEY (id_district) REFERENCES DISTRICT(id_district);

--users
ALTER TABLE Users add constraint rol_user
FOREIGN KEY (id_role) REFERENCES ROLES(id_role);

--Sales
Alter table Sales add constraint FK_SalesCustomer
FOREIGN KEY (id_customer) REFERENCES CUSTOMERS(id_customer);
Alter table Sales add constraint FK_SalesPaymentmethod
FOREIGN KEY (id_payment_method) REFERENCES PAYMENT_METHOD(id_payment_method);
Alter table Sales add constraint FK_SalesDiscount
FOREIGN KEY (id_discount) REFERENCES DISCOUNT(id_discount);
Alter table Sales add constraint FK_SalesCustomerCard
FOREIGN KEY (id_card) REFERENCES CUSTOMER_CARD(id_card);

--SalesDetails
Alter table Sale_Details add constraint FK_SaleDetailsSales
FOREIGN KEY (id_sale) REFERENCES SALES(id_sale);
Alter table Sale_Details add constraint FK_SaleDetailsProducts
FOREIGN KEY (id_product) REFERENCES PRODUCTS(id_product);

--Cardebenefits
Alter table Card_Benefits add constraint FK_CardBenefits_Benefits
FOREIGN KEY (id_benefit) REFERENCES BENEFITS(id_benefit);
Alter table Card_Benefits add constraint FK_CardBenefits_CustomerCard
FOREIGN KEY (id_card) REFERENCES CUSTOMER_CARD(id_card);


--RETURNS
ALTER TABLE Returns ADD CONSTRAINT FK_ReturnsCustomer
FOREIGN KEY (id_customer) REFERENCES CUSTOMERS(id_customer);
ALTER TABLE Returns ADD CONSTRAINT FK_ReturnsSale
FOREIGN KEY (id_sale) REFERENCES SALES(id_sale); 

--Points History
ALTER TABLE Points_History ADD CONSTRAINT KF_PointsHistoryCustomercard
FOREIGN KEY (id_card) REFERENCES CUSTOMER_CARD(id_card);

--RecordSales
ALTER TABLE recordSales
ADD CONSTRAINT FK_CUSTOMERS
FOREIGN KEY (id_customer) REFERENCES CUSTOMERS(id_customer);
GO

-- PRICE_HISTORY
ALTER TABLE PRICE_HISTORY
ADD CONSTRAINT FK_PRODUCTS
FOREIGN KEY (id_product) REFERENCES PRODUCTS(id_product);
Go

-- ACCOUNT
ALTER TABLE ACCOUNT
ADD CONSTRAINT FK_AccountUser
FOREIGN KEY (id_user) REFERENCES USERS(id_user);




	

