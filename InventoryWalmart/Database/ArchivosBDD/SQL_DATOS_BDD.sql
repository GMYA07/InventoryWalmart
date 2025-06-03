USE inventoryWalmart;
go
/*Agregado Roles*/
EXEC insert_Roles 'Administrador','Este rol es para la persona que administrara el programa';
EXEC insert_Roles 'Cajero', 'Este rol es para el usuario cajero que le ayudara con sus labores';

/*Agregando Usuarios y Cuentas*/

/*Administradores*/

EXEC insert_User 'Yael Adonay','Matamoros Guzman','2004-04-01','2022-10-3','7988-2404','11111111-0',2,23,1;
EXEC insert_User 'Karla Lisseth','Carranza Villanueva','2004-02-16','2022-10-4','7240-5056','22222222-0',2,23,1;
EXEC insert_User 'Brian Josue','Chavez Recinos','2002-03-11','2022-10-5','7502-2137','33333333-0',2,23,1;
EXEC insert_User 'Carlos Javier','Menjivar Ramos','2005-05-10','2022-10-6','7502-2137','44444444-0',2,23,1;
EXEC insert_User 'Daniel Vinicio','Castillo Bonilla','2004-6-21','2022-10-6','7231-8361','55555555-0',2,23,1;

/*Cuentas Admins*/
EXEC insert_account 1,'YAMG_7','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',1;
EXEC insert_account 2,'CarranzaV','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',1;
EXEC insert_account 3,'SapoRadix','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',1;
EXEC insert_account 4,'JaviXD','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',1;
EXEC insert_account 5,'Vini','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',1;

/*Cajeros*/
EXEC insert_User 'Edinson','Cavani','1987-2-14','2005-10-6','7231-8361','66666666-0',2,24,2;
EXEC insert_User 'Luca','Doncic','1999-2-28','2005-10-6','7211-8361','77777777-0',2,25,2;
EXEC insert_User 'Kevin','Durant','1988-9-29','2007-10-6','7211-8361','32323232-0',2,25,2;

/*Cuentas Users*/
EXEC insert_account 6,'Cava7','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',1;
EXEC insert_account 7,'Doncic77','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',1;
EXEC insert_account 8,'KD35','03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',1;


/*Agregando Clientes*/

EXEC insertCustomer 'Lionel', 'Messi', 'lmessi@example.com', '7012-3456', '08342178-5', '1987-06-24';
EXEC insertCustomer 'Cristiano', 'Ronaldo', 'cr7@example.com', '7845-1122', '12345678-9', '1985-02-05';
EXEC insertCustomer 'Kylian', 'Mbappe', 'mbappe@example.com', '7788-6633', '98765432-1', '1998-12-20';
EXEC insertCustomer 'Erling', 'Haaland', 'haaland@example.com', NULL, '11223344-6', '2000-07-21';
EXEC insertCustomer 'Vinicius', 'Junior', 'vini@example.com', '7123-8765', '76543210-4', '2000-07-12';

EXEC insertCustomer 'Jude', 'Bellingham', 'bellingham@example.com', NULL, '45678912-0', '2003-06-29';
EXEC insertCustomer 'Kevin', 'De Bruyne', 'kdb@example.com', '7090-1234', '33445566-7', '1991-06-28';
EXEC insertCustomer 'Robert', 'Lewandowski', 'lewa@example.com', '7001-8765', '77665544-3', '1988-08-21';
EXEC insertCustomer 'Neymar', 'Junior', 'neymarjr@example.com', NULL, '22334455-6', '1992-02-05';
EXEC insertCustomer 'Mohamed', 'Salah', 'msalah@example.com', '7564-8900', '66778899-2', '1992-06-15';

EXEC insertCustomer 'Harry', 'Kane', 'hkane@example.com', '7654-3321', '88990011-0', '1993-07-28';
EXEC insertCustomer 'Sadio', 'Mané', 'smane@example.com', NULL, '99887766-5', '1992-04-10';
EXEC insertCustomer 'Luka', 'Modric', 'modric@example.com', '7200-1200', '55667788-4', '1985-09-09';
EXEC insertCustomer 'Karim', 'Benzema', 'benzema@example.com', NULL, '10293847-6', '1987-12-19';
EXEC insertCustomer 'Marcus', 'Rashford', 'rashford@example.com', '7700-9900', '67890123-8', '1997-10-31';

EXEC insertCustomer 'João', 'Félix', 'joao@example.com', '7234-5678', '98712345-6', '1999-11-10';
EXEC insertCustomer 'Phil', 'Foden', 'pfoden@example.com', '7156-2847', '23456789-1', '2000-05-28';
EXEC insertCustomer 'Pedri', 'Gonzalez', 'pedri@example.com', NULL, '19283746-3', '2002-11-25';
EXEC insertCustomer 'Gavi', 'Paez', 'gavi@example.com', '7030-3040', '54637281-0', '2004-08-05';
EXEC insertCustomer 'Riyad', 'Mahrez', 'mahrez@example.com', '7766-4433', '74839201-9', '1991-02-21';

EXEC insertCustomer 'Bruno', 'Fernandes', 'bfernandes@example.com', '7201-1231', '84930218-4', '1994-09-08';
EXEC insertCustomer 'Son', 'Heung-min', 'sonny@example.com', NULL, '63820194-7', '1992-07-08';
EXEC insertCustomer 'Declan', 'Rice', 'drice@example.com', '7890-4567', '12398475-3', '1999-01-14';
EXEC insertCustomer 'Joshua', 'Kimmich', 'kimmich@example.com', NULL, '32019485-1', '1995-02-08';
EXEC insertCustomer 'Achraf', 'Hakimi', 'hakimi@example.com', '7345-8692', '90318274-2', '1998-11-04';

/*Agregandole targeta a 15 clientes*/
EXEC insert_CustomerCard 1, 'CARD000000000001', '2023-06-01', '2026-06-01';
EXEC insert_CustomerCard 2, 'CARD000000000002', '2023-07-15', '2026-07-15';
EXEC insert_CustomerCard 3, 'CARD000000000003', '2024-01-20', '2027-01-20';
EXEC insert_CustomerCard 4, 'CARD000000000004', '2024-03-05', '2028-03-05';
EXEC insert_CustomerCard 5, 'CARD000000000005', '2022-11-30', '2026-11-30';

EXEC insert_CustomerCard 6, 'CARD000000000006', '2023-09-12', '2027-09-12';
EXEC insert_CustomerCard 7, 'CARD000000000007', '2022-05-01', '2026-05-01';
EXEC insert_CustomerCard 8, 'CARD000000000008', '2024-02-10', '2028-02-10';
EXEC insert_CustomerCard 9, 'CARD000000000009', '2023-04-25', '2027-04-25';
EXEC insert_CustomerCard 10, 'CARD000000000010', '2022-12-18', '2026-12-18';

EXEC insert_CustomerCard 11, 'CARD000000000011', '2023-01-01', '2027-01-01';
EXEC insert_CustomerCard 12, 'CARD000000000012', '2024-05-26', '2028-05-26';
EXEC insert_CustomerCard 13, 'CARD000000000013', '2023-06-15', '2027-06-15';
EXEC insert_CustomerCard 14, 'CARD000000000014', '2023-09-30', '2027-09-30';
EXEC insert_CustomerCard 15, 'CARD000000000015', '2022-08-20', '2026-08-20';


/*Agregando Beneficios*/
EXEC insertBenefits 'Día de la Madre', 'Promoción especial por el Día de la Madre', 60, 15.00, '2025-06-10', '2025-06-15';
EXEC insertBenefits 'Día del Padre', 'Descuento aplicado a todas las compras por el Día del Padre', 65, 15.00, '2025-06-17', '2025-06-21';
EXEC insertBenefits 'Regreso a Clases', 'Descuento en compras escolares', 70, 10.00, '2025-07-01', '2025-07-31';
EXEC insertBenefits 'Fiestas Agostinas', 'Descuento por celebración nacional', 80, 20.00, '2025-08-01', '2025-08-10';
EXEC insertBenefits 'Independencia', 'Promoción por las fiestas patrias', 60, 12.00, '2025-09-10', '2025-09-21';

EXEC insertBenefits 'Halloween', 'Descuento especial de terror', 55, 10.00, '2025-10-25', '2025-10-31';
EXEC insertBenefits 'Black Friday', 'Descuentos masivos por temporada', 100, 30.00, '2025-11-28', '2025-11-29';
EXEC insertBenefits 'Cyber Monday', 'Promoción en línea exclusiva', 85, 25.00, '2025-12-01', '2025-12-02';
EXEC insertBenefits 'Navidad', 'Descuento navideño en todas las compras', 90, 20.00, '2025-12-20', '2025-12-26';
EXEC insertBenefits 'Año Nuevo', 'Empieza el año con un descuento especial', 95, 25.00, '2025-12-31', '2026-01-03';

EXEC insertBenefits 'San Valentín', 'Descuento por el mes del amor y la amistad', 75, 15.00, '2026-02-10', '2026-02-15';
EXEC insertBenefits 'Semana Santa', 'Promoción válida durante Semana Santa', 60, 10.00, '2026-03-22', '2026-03-29';
EXEC insertBenefits 'Día del Niño', 'Descuento especial para los pequeños', 65, 12.00, '2025-10-01', '2025-10-05';
EXEC insertBenefits 'Día del Trabajo', 'Reconocimiento con descuentos especiales', 70, 15.00, '2026-04-30', '2026-05-02';
EXEC insertBenefits 'Aniversario Tienda', 'Celebramos contigo con descuentos', 80, 18.00, '2025-07-10', '2025-07-15';

EXEC insertBenefits 'Fin de Temporada', 'Liquidación por fin de temporada', 90, 25.00, '2025-09-01', '2025-09-10';
EXEC insertBenefits 'Back to Office', 'Descuento por regreso al trabajo presencial', 55, 10.00, '2025-07-20', '2025-08-05';
EXEC insertBenefits 'Día del Cliente', 'Agradecimiento a nuestros clientes', 75, 20.00, '2025-10-20', '2025-10-21';
EXEC insertBenefits 'Viernes Loco', 'Descuento en todo por un solo día', 50, 15.00, '2025-07-05', '2025-07-05';
EXEC insertBenefits 'Festival de Ofertas', 'Semana llena de descuentos especiales', 80, 20.00, '2025-08-15', '2025-08-22';

EXEC insertBenefits 'Día del Amor y la Amistad', 'Ofertas románticas y amistosas', 60, 10.00, '2026-02-12', '2026-02-15';
EXEC insertBenefits 'Temporada de Lluvias', 'Descuento en productos seleccionados', 55, 10.00, '2025-06-15', '2025-07-15';
EXEC insertBenefits 'Descuento Verano', 'Ofertas frescas por el verano', 70, 15.00, '2025-12-15', '2025-12-31';
EXEC insertBenefits 'Lanzamiento de Temporada', 'Descuentos por nueva colección', 65, 12.00, '2025-09-20', '2025-09-30';
EXEC insertBenefits 'Bonificación de Medio Año', 'Recompensa por fidelidad a mitad de año', 85, 25.00, '2025-07-01', '2025-07-10';

/*Vinculando Beneficios a targetas*/
-- Tarjeta 1
EXEC insert_CardBenefit 1, 2, '2025-05-15';
EXEC insert_CardBenefit 1, 5, '2025-05-15';

-- Tarjeta 2
EXEC insert_CardBenefit 2, 4, '2025-05-14';

-- Tarjeta 3
EXEC insert_CardBenefit 3, 1, '2025-05-13';
EXEC insert_CardBenefit 3, 7, '2025-05-13';

-- Tarjeta 4
EXEC insert_CardBenefit 4, 3, '2025-05-12';

-- Tarjeta 5
EXEC insert_CardBenefit 5, 6, '2025-05-15';
EXEC insert_CardBenefit 5, 8, '2025-05-15';

-- Tarjeta 6
EXEC insert_CardBenefit 6, 9, '2025-05-10';

-- Tarjeta 7
EXEC insert_CardBenefit 7, 10, '2025-05-10';
EXEC insert_CardBenefit 7, 12, '2025-05-10';

-- Tarjeta 8
EXEC insert_CardBenefit 8, 11, '2025-05-09';

-- Tarjeta 9
EXEC insert_CardBenefit 9, 13, '2025-05-08';
EXEC insert_CardBenefit 9, 14, '2025-05-08';

-- Tarjeta 10
EXEC insert_CardBenefit 10, 15, '2025-05-07';

-- Tarjeta 11
EXEC insert_CardBenefit 11, 16, '2025-05-06';
EXEC insert_CardBenefit 11, 18, '2025-05-06';

-- Tarjeta 12
EXEC insert_CardBenefit 12, 17, '2025-05-05';

-- Tarjeta 13
EXEC insert_CardBenefit 13, 19, '2025-05-04';
EXEC insert_CardBenefit 13, 21, '2025-05-04';

-- Tarjeta 14
EXEC insert_CardBenefit 14, 20, '2025-05-03';

-- Tarjeta 15
EXEC insert_CardBenefit 15, 22, '2025-05-02';
EXEC insert_CardBenefit 15, 24, '2025-05-02';


/*Agregando los descuentos*/

EXEC insert_Discount 'XJ582019AD', 5.00, 'Descuento de bienvenida para nuevos usuarios', 'Monto fijo';
EXEC insert_Discount 'KT920AB731', 10.00, 'Promoción por compras mayores a $50', 'Monto fijo';
EXEC insert_Discount 'YN504CP190', 15.00, 'Descuento exclusivo por referidos', 'Monto fijo';
EXEC insert_Discount 'WD8837ZQ10', 7.50, 'Descuento por encuestas completadas', 'Monto fijo';
EXEC insert_Discount 'BR71YU823K', 20.00, 'Campaña de fidelización anual', 'Monto fijo';

EXEC insert_Discount 'MK2918LOQ7', 8.00, 'Descuento por compras desde la app móvil', 'Monto fijo';
EXEC insert_Discount 'QP440SNM82', 12.00, 'Bonificación por compras continuas', 'Monto fijo';
EXEC insert_Discount 'VU930185DK', 9.00, 'Descuento aplicado por promoción especial', 'Monto fijo';
EXEC insert_Discount 'HZ830JTW09', 18.00, 'Descuento corporativo', 'Monto fijo';
EXEC insert_Discount 'SA18MN23RE', 6.00, 'Descuento exclusivo para empleados', 'Monto fijo';

EXEC insert_Discount 'LZ198FRXP4', 10.00, 'Descuento por participar en eventos', 'Monto fijo';
EXEC insert_Discount 'OKQ192835M', 14.00, 'Descuento de cumpleaños', 'Monto fijo';
EXEC insert_Discount 'RF76291VPL', 11.00, 'Descuento de media temporada', 'Monto fijo';
EXEC insert_Discount 'ZK5930AWX7', 5.50, 'Descuento en primera compra del mes', 'Monto fijo';
EXEC insert_Discount 'TU2193LCBF', 16.00, 'Descuento por redimir puntos', 'Monto fijo';

/*Llenando datos para insertar Productos*/

/*Suppliers*/
EXEC insert_Supplier 'Laura González', 'AgroSuministros El Salvador', 'laura.gonzalez@agrosv.com', '786543210', 1;
EXEC insert_Supplier 'Carlos Mejía', 'ElectroDistribuciones SA', 'carlos.mejia@electrosa.com', '745612389', 2;
EXEC insert_Supplier 'Marcela Torres', 'Textiles y Confecciones SA', 'marcela.torres@textcon.com', '712345678', 3;
EXEC insert_Supplier 'Jorge Ramírez', 'Insumos Médicos Centroamericanos', 'jorge.ramirez@insumed.com', '789456123', 2;
EXEC insert_Supplier 'Patricia López', 'Distribuidora López Hermanos', 'patricia.lopez@lopezhermanos.com', '765432189', 4;

EXEC insert_Supplier 'Andrés Martínez', 'Sistemas y Redes Globales', 'andres.martinez@sysnet.com', '798765432', 1;
EXEC insert_Supplier 'Diana Salinas', 'Delicias Gourmet SA', 'diana.salinas@deligourmet.com', '734567812', 5;
EXEC insert_Supplier 'Óscar Herrera', 'Herramientas Industriales SV', 'oscar.herrera@herrind.com', '723456789', 3;
EXEC insert_Supplier 'Silvia Arévalo', 'Papelería Central', 'silvia.arevalo@papelcentro.com', '790123456', 4;
EXEC insert_Supplier 'Mauricio Pineda', 'Soluciones Limpias', 'mauricio.pineda@solimpia.com', '776543210', 2;

/*Categorias*/
EXEC insert_Category 'Comida y Bebidas', 'Productos alimenticios, bebidas y abarrotes', NULL;
EXEC insert_Category 'Hogar y Cocina', 'Productos para el hogar, cocina y limpieza', NULL;
EXEC insert_Category 'Deportes', 'Artículos y accesorios deportivos', NULL;
EXEC insert_Category 'Ropa y Accesorios', 'Ropa para todas las edades y accesorios de moda', NULL;
EXEC insert_Category 'Papelería', 'Útiles escolares y de oficina', NULL;

EXEC insert_Category 'Juguetería', 'Juguetes para niños y niñas de todas las edades', NULL;
EXEC insert_Category 'Salud y Cuidado Personal', 'Productos de higiene y salud', NULL;
EXEC insert_Category 'Herramientas', 'Herramientas manuales y de uso doméstico', NULL;
EXEC insert_Category 'Mascotas', 'Alimentos, juguetes y productos para mascotas', NULL;
EXEC insert_Category 'Limpieza General', 'Productos de aseo para el hogar y negocio', NULL;

/*Productos*/
EXEC insert_Product 'Arroz Integral', 5.99, 4.20, 150, 1, 1, NULL;
EXEC insert_Product 'Licuadora Profesional', 89.99, 65.00, 30, 2, 2, NULL;
EXEC insert_Product 'Balón de Fútbol', 24.50, 18.75, 80, 3, 8, NULL;
EXEC insert_Product 'Jeans Slim Fit', 45.00, 32.99, 60, 4, 3, NULL;
EXEC insert_Product 'Cuaderno Universitario', 3.75, 2.10, 200, 5, 9, NULL;
EXEC insert_Product 'Shampoo Anticaspa', 8.99, 6.50, 120, 7, 4, NULL;
EXEC insert_Product 'Juego de Llaves', 35.00, 25.80, 45, 8, 8, NULL;
EXEC insert_Product 'Alimento para Perros', 28.50, 22.00, 90, 9, 10, NULL;
EXEC insert_Product 'Desinfectante Multiusos', 6.25, 4.15, 300, 10, 10, NULL;
EXEC insert_Product 'Set de Cortinas', 42.99, 30.00, 25, 2, 5, NULL;
EXEC insert_Product 'Raqueta de Tenis', 75.00, 55.00, 15, 3, 8, NULL;
EXEC insert_Product 'Vestido de Verano', 39.95, 28.50, 40, 4, 3, NULL;
EXEC insert_Product 'Paquete de Papel Bond', 12.00, 8.90, 150, 5, 9, NULL;
EXEC insert_Product 'Café Premium', 9.99, 6.80, 200, 1, 7, NULL;
EXEC insert_Product 'Guantes de Boxeo', 32.50, 24.99, 30, 3, 8, NULL;
EXEC insert_Product 'Juego de Sábanas', 55.00, 40.00, 50, 2, 5, NULL;
EXEC insert_Product 'Termómetro Digital', 15.75, 11.25, 100, 7, 4, NULL;
EXEC insert_Product 'Taladro Inalámbrico', 120.00, 95.00, 20, 8, 8, NULL;
EXEC insert_Product 'Juguete Educativo', 19.99, 14.50, 75, 6, 6, NULL;
EXEC insert_Product 'Aceite de Oliva', 14.95, 10.00, 180, 1, 7, NULL;
EXEC insert_Product 'Mochila Escolar', 29.99, 20.00, 65, 5, 9, NULL;
EXEC insert_Product 'Crema Facial', 22.50, 16.75, 110, 7, 4, NULL;
EXEC insert_Product 'Pelota de Baloncesto', 29.00, 21.50, 45, 3, 8, NULL;
EXEC insert_Product 'Lámpara LED', 47.99, 35.00, 35, 2, 2, NULL;
EXEC insert_Product 'Collar para Mascotas', 8.50, 5.25, 200, 9, 10, NULL;

/*Insertando Metodo de pago*/
EXEC insert_PaymentMethod 'Targeta','Metodo de pago virtual';
EXEC insert_PaymentMethod 'Efectivo','Metodo de pago con dinero fisico';

