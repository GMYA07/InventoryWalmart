use inventoryWalmart;

--		ISERCION DE DATOS PARA LOS DEPARTAMENTOS

CREATE TYPE DepartmentTableType AS TABLE (
    department_name VARCHAR(50)
);


GO;
CREATE PROCEDURE register_departments
    @departments DepartmentTableType READONLY
AS
BEGIN
    INSERT INTO DEPARTMENT (department_name)
    SELECT department_name FROM @departments;
END

go;


-- Declarar la tabla con los valores
DECLARE @deptList AS DepartmentTableType;

-- Insertar los 14 departamentos
INSERT INTO @deptList (department_name)
VALUES 
    ('Sonsonate'),
    ('San Salvador'),
    ('Santa Ana'),
    ('La Libertad'),
    ('Chalatenango'),
    ('Usulután'),
    ('San Miguel'),
    ('Morazán'),
    ('La Unión'),
    ('Ahuachapán'),
    ('Cabañas'),
    ('Cuscatlán'),
    ('La Paz'),
    ('San Vicente');

-- Llamar al procedimiento pasando la tabla
EXEC register_departments @departments = @deptList;




-- INSERCION DE DATOS PARA LOS DISTRITOS

CREATE TYPE DistrictTableType AS TABLE (
    district_name VARCHAR(50)
);


GO;
CREATE PROCEDURE register_district
    @district DistrictTableType READONLY,
    @department INT
AS
BEGIN
    INSERT INTO DISTRICT (district_name, id_department)
    SELECT district_name, @department FROM @district;
END
GO;

-- ingresar distritos por departamentos
-- Sonsonate
DECLARE @districtList AS DistrictTableType;

INSERT INTO @districtList (district_name)
VALUES 
    ('Juayúa'),
    ('Nahuizalco'),
    ('Salcoatitán'),
	('Santa Catarina Masahuat'),
	('Sonsonate'),
    ('Sonzacate'),
    ('Nahulingo'),
	('San Antonio del Monte'),
	('Santo Domingo de Guzmán'),
    ('lzalco'),
    ('Armenia'),
	('Caluco'),
	('San Julián'),
    ('Cuisnahuat'),
    ('Santa Isabel lshuatán'),
	('Acajutla');

EXEC register_district @district = @districtList, @department = 1;


-- 2 San salvador

DECLARE @districtSansalvador AS DistrictTableType;

INSERT INTO @districtSansalvador (district_name)
VALUES 
    ('Aguilares'),
    ('El Paisnal'),
    ('Guazapa'),
	('Apopa'),
	('Nejapa'),
    ('llopango'),
    ('San Martín'),
	('Soyapango'),
	('Tonacatepeque'),
    ('Ayutuxtepeque'),
    ('Mejicanos'),
	('San Salvador'),
	('Cuscatancingo'),
    ('Ciudad Delgado'),
    ('Panchimalco'),
	('Rosario de Mora'),
	('San Marcos'),
	('Santo Tomás'),
	('Santiago Texacuangos');

EXEC register_district @district = @districtSansalvador, @department = 2;



-- 3 Santa Ana
-- EMPEZAR A REVISAR DE ACA PARA ABAJO

DECLARE @districtSantaAna AS DistrictTableType;

INSERT INTO @districtSantaAna (district_name)
VALUES 
	('Masahuat'),
	('Metapán'),
	('Santa Rosa Guachipilín'),
	('Texistepeque'),
	('Santa Ana'),
	('Coatepeque'),
	('El Congo'),
	('Candelaria de la Frontera'),
	('Chalchuapa'),
	('El Porvenir'),
	('San Antonio Pajonal'),
	('San Sebastián Salitrillo'),
	('Santiago de La Frontera');

EXEC register_district @district = @districtSantaAna, @department = 3;


-- 4 la libertad


DECLARE @districtlaLibertad AS DistrictTableType;

INSERT INTO @districtlaLibertad (district_name)
VALUES 
    ('Quezaltepeque'),
    ('San Matías'),
    ('San Pablo Tacachico'),
	('San Juan Opico'),
	('Ciudad Arce'),
    ('Colón'),
    ('Jayaque'),
	('Sacacoyo'),
	('Tepecoyo'),
    ('Talnique'),
    ('Antiguo Cuscatlán'),
	('Huizucar'),
	('Nuevo Cuscatlán'),
    ('San José Villanueva'),
    ('Zaragoza'),
	('Chiltuipán'),
	('La Libertad'),
	('Tamanique'),
	('Teotepeque'),
	('Comasagua'),
	('Santa Tecla');

EXEC register_district @district = @districtlaLibertad, @department = 4;

-- 5 chalatenango

DECLARE @districtChalatenango AS DistrictTableType;

INSERT INTO @districtChalatenango (district_name)
VALUES 
    ('La Palma'),
    ('Citalá'),
    ('San Ignacio'),
	('Nueva Concepción'),
	('Tejutla'),
    ('La Reina'),
    ('Agua Caliente'),
	('Dulce Nombre de María'),
	('El Paraíso'),
    ('San Francisco Morazán'),
    ('San Rafael'),
	('Santa Rita'),
	('San Fernando'),
    ('Chalatenango'),
    ('Arcatao'),
	('Azacualpa'),
	('Comalapa'),
	('Concepción Quezaltepeque'),
	('El Carrizal'),
	('La Laguna'),
	('Las Vueltas'),
	('Nombre de Jesús'),
	('Nueva Trinidad'),
	('Ojos de Agua'),
	('Potonico'),
	('San Antonio de La Cruz'),
	('San Antonio Los Ranchos'),
	('San Francisco Lempa'),
	('San Isidro Labrador'),
	('San José Cancasque'),
	('San Miguel de Mercedes'),
	('San José Las Flores'),
	('San Luis del Carmen');

EXEC register_district @district = @districtChalatenango, @department = 5;

-- 6 usulutan

DECLARE @districtUsulutan AS DistrictTableType;

INSERT INTO @districtUsulutan (district_name)
VALUES 
    ('Santiago de María'),
	('Alegría'),
	('Berlín'),
	('Mercedes Umana'),
	('Jucuapa'),
	('El Triunfo'),
	('Estanzuelas'),
	('San Buenaventura'),
	('Nueva Granada'),
	('Usulután'),
	('Jucuarán'),
	('San Dionisio'),
	('Concepción Batres'),
	('Santa María'),
	('Ozatlán'),
	('Tecapán'),
	('Santa Elena'),
	('California'),
	('Ereguayquín'),
	('Jiquilisco'),
	('Puerto El Triunfo'),
	('San Agustín'),
	('San Francisco Javier');
EXEC register_district @district = @districtUsulutan, @department = 6;


-- 7 san miguel

DECLARE @districtSanMiguel AS DistrictTableType;

INSERT INTO @districtSanMiguel (district_name)
VALUES 
    ('San Miguel Norte'),
	('Ciudad Barrios'),
	('Sesori'),
	('Nuevo Edén de San Juan'),
	('San Gerardo'),
	('San Luis de La Reina'),
	('Carolina'),
	('San Antonio del Mosco'),
	('Chapeltique'),
	('San Miguel'),
	('Comacarán'),
	('Uluazapa'),
	('Moncagua'),
	('Quelepa'),
	('Chirilagua'),
	('Chinameca'),
	('Nueva Guadalupe'),
	('Lolotique'),
	('San Jorge'),
	('San Rafael Oriente'),
	('El Tránsito');

EXEC register_district @district = @districtSanMiguel, @department = 7;

-- 8 morazan

DECLARE @districtMorazan AS DistrictTableType;

INSERT INTO @districtMorazan (district_name)
VALUES 
	('Morazán Norte'),
	('Arambala'),
	('Cacaopera'),
	('Corinto'),
	('El Rosario'),
	('Joateca'),
	('Jocoaitique'),
	('Meanguera'),
	('Perquín'),
	('San Fernando'),
	('San Isidro'),
	('Torola'),
	('Chilanga'),
	('Delicias de Concepción'),
	('El Divisadero'),
	('Gualococti'),
	('Guatajiagua'),
	('Jocoro'),
	('Lolotiquillo'),
	('Osicala'),
	('San Carlos'),
	('San Francisco Gotera'),
	('San Simón'),
	('Sensembra'),
	('Sociedad'),
	('Yamabal'),
	('Yoloaiquín');

EXEC register_district @district = @districtMorazan, @department = 8;

-- 9 la union

DECLARE @districtLaUnion AS DistrictTableType;

INSERT INTO @districtLaUnion (district_name)
VALUES 
    ('Anamorós'),
	('Bolivar'),
	('Concepción de Oriente'),
	('El Sauce'),
	('Lislique'),
	('Nueva Esparta'),
	('Pasaquina'),
	('Polorós'),
	('San José La Fuente'),
	('Santa Rosa de Lima'),
	('Conchagua'),
	('El Carmen'),
	('lntipucá'),
	('La Unión'),
	('Meanguera del Golfo'),
	('San Alejo'),
	('Yayantique'),
	('Yucuaiquín');

EXEC register_district @district = @districtLaUnion, @department = 9;

-- 10 ahuachapn

DECLARE @districtAuchapan AS DistrictTableType;

INSERT INTO @districtAuchapan (district_name)
VALUES 
    ('Atiquizaya'),
	('El Refugio'),
	('San Lorenzo'),
	('Turín'),
	('Ahuachapán'),
	('Apaneca'),
	('Concepción de Ataco'),
	('Tacuba'),
	('Guaymango'),
	('Jujutla'),
	('San Francisco Menendez'),
	('San Pedro Puxtla');

EXEC register_district @district = @districtAuchapan, @department = 10;

-- 11 cabanhas

DECLARE @districtCabanhas AS DistrictTableType;

INSERT INTO @districtCabanhas (district_name)
VALUES 
    ('Sensuntepeque'),
	('Victoria'),
	('Dolores'),
	('Guacotecti'),
	('San Isidro'),
	('llobasco'),
	('Tejutepeque'),
	('Jutiapa'),
	('Cinquera');

EXEC register_district @district = @districtCabanhas, @department = 11;

-- 12 cuscatlan

DECLARE @districtCuscatlan AS DistrictTableType;

INSERT INTO @districtCuscatlan (district_name)
VALUES 
	('Suchitoto'),
	('San José Guayabal'),
	('Oratorio de Concepción'),
	('San Bartolomé Perulapán'),
	('San Pedro Perulapán'),
	('Cojutepeque'),
	('San Rafael Cedros'),
	('Candelaria'),
	('Monte San Juan'),
	('El Carmen'),
	('San Cristóbal'),
	('Santa Cruz Michapa'),
	('San Ramón'),
	('El Rosario'),
	('Santa Cruz Analquito'),
	('Tenancingo');

EXEC register_district @district = @districtCuscatlan, @department = 12;

-- 13 la paz

DECLARE @districtLaPaz AS DistrictTableType;

INSERT INTO @districtLaPaz (district_name)
VALUES 
    ('Cuyultitán'),
	('Olocuilta'),
	('San Juan Talpa'),
	('San Luis Talpa'),
	('San Pedro Masahuat'),
	('Tapalhuaca'),
	('San Francisco Chinameca'),
	('El Rosario'),
	('Jerusalén'),
	('Mercedes La Ceiba'),
	('Paraíso de Osorio'),
	('San Antonio Masahuat'),
	('San Emigdio'),
	('San Juan Tepezontes'),
	('San Luis La Herradura'),
	('San Miguel Tepezontes'),
	('San Pedro Nonualco'),
	('Santa María Ostuma'),
	('Santiago Nonualco'),
	('San Juan Nonualco'),
	('San Rafael Obrajuelo'),
	('Zacatecoluca');

EXEC register_district @district = @districtLaPaz, @department = 13;

-- 14 san vicente

DECLARE @districtSanVicente AS DistrictTableType;

INSERT INTO @districtSanVicente (district_name)
VALUES 
    ('Apastepeque'),
	('Santa Clara'),
	('San Ildefonso'),
	('San Esteban Catarina'),
	('San Sebastián'),
	('San Lorenzo'),
	('Santo Domingo'),
	('San Vicente'),
	('Guadalupe'),
	('Verapaz'),
	('Tepetitán'),
	('Tecoluca'),
	('San Cayetano lstepeque');

EXEC register_district @district = @districtSanVicente, @department = 14;

