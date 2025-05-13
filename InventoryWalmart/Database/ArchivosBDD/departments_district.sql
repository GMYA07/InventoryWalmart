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
    ('Usulut�n'),
    ('San Miguel'),
    ('Moraz�n'),
    ('La Uni�n'),
    ('Ahuachap�n'),
    ('Caba�as'),
    ('Cuscatl�n'),
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
    ('Juay�a'),
    ('Nahuizalco'),
    ('Salcoatit�n'),
	('Santa Catarina Masahuat'),
	('Sonsonate'),
    ('Sonzacate'),
    ('Nahulingo'),
	('San Antonio del Monte'),
	('Santo Domingo de Guzm�n'),
    ('lzalco'),
    ('Armenia'),
	('Caluco'),
	('San Juli�n'),
    ('Cuisnahuat'),
    ('Santa Isabel lshuat�n'),
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
    ('San Mart�n'),
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
	('Santo Tom�s'),
	('Santiago Texacuangos');

EXEC register_district @district = @districtSansalvador, @department = 2;



-- 3 Santa Ana
-- EMPEZAR A REVISAR DE ACA PARA ABAJO

DECLARE @districtSantaAna AS DistrictTableType;

INSERT INTO @districtSantaAna (district_name)
VALUES 
	('Masahuat'),
	('Metap�n'),
	('Santa Rosa Guachipil�n'),
	('Texistepeque'),
	('Santa Ana'),
	('Coatepeque'),
	('El Congo'),
	('Candelaria de la Frontera'),
	('Chalchuapa'),
	('El Porvenir'),
	('San Antonio Pajonal'),
	('San Sebasti�n Salitrillo'),
	('Santiago de La Frontera');

EXEC register_district @district = @districtSantaAna, @department = 3;


-- 4 la libertad


DECLARE @districtlaLibertad AS DistrictTableType;

INSERT INTO @districtlaLibertad (district_name)
VALUES 
    ('Quezaltepeque'),
    ('San Mat�as'),
    ('San Pablo Tacachico'),
	('San Juan Opico'),
	('Ciudad Arce'),
    ('Col�n'),
    ('Jayaque'),
	('Sacacoyo'),
	('Tepecoyo'),
    ('Talnique'),
    ('Antiguo Cuscatl�n'),
	('Huizucar'),
	('Nuevo Cuscatl�n'),
    ('San Jos� Villanueva'),
    ('Zaragoza'),
	('Chiltuip�n'),
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
    ('Cital�'),
    ('San Ignacio'),
	('Nueva Concepci�n'),
	('Tejutla'),
    ('La Reina'),
    ('Agua Caliente'),
	('Dulce Nombre de Mar�a'),
	('El Para�so'),
    ('San Francisco Moraz�n'),
    ('San Rafael'),
	('Santa Rita'),
	('San Fernando'),
    ('Chalatenango'),
    ('Arcatao'),
	('Azacualpa'),
	('Comalapa'),
	('Concepci�n Quezaltepeque'),
	('El Carrizal'),
	('La Laguna'),
	('Las Vueltas'),
	('Nombre de Jes�s'),
	('Nueva Trinidad'),
	('Ojos de Agua'),
	('Potonico'),
	('San Antonio de La Cruz'),
	('San Antonio Los Ranchos'),
	('San Francisco Lempa'),
	('San Isidro Labrador'),
	('San Jos� Cancasque'),
	('San Miguel de Mercedes'),
	('San Jos� Las Flores'),
	('San Luis del Carmen');

EXEC register_district @district = @districtChalatenango, @department = 5;

-- 6 usulutan

DECLARE @districtUsulutan AS DistrictTableType;

INSERT INTO @districtUsulutan (district_name)
VALUES 
    ('Santiago de Mar�a'),
	('Alegr�a'),
	('Berl�n'),
	('Mercedes Umana'),
	('Jucuapa'),
	('El Triunfo'),
	('Estanzuelas'),
	('San Buenaventura'),
	('Nueva Granada'),
	('Usulut�n'),
	('Jucuar�n'),
	('San Dionisio'),
	('Concepci�n Batres'),
	('Santa Mar�a'),
	('Ozatl�n'),
	('Tecap�n'),
	('Santa Elena'),
	('California'),
	('Ereguayqu�n'),
	('Jiquilisco'),
	('Puerto El Triunfo'),
	('San Agust�n'),
	('San Francisco Javier');
EXEC register_district @district = @districtUsulutan, @department = 6;


-- 7 san miguel

DECLARE @districtSanMiguel AS DistrictTableType;

INSERT INTO @districtSanMiguel (district_name)
VALUES 
    ('San Miguel Norte'),
	('Ciudad Barrios'),
	('Sesori'),
	('Nuevo Ed�n de San Juan'),
	('San Gerardo'),
	('San Luis de La Reina'),
	('Carolina'),
	('San Antonio del Mosco'),
	('Chapeltique'),
	('San Miguel'),
	('Comacar�n'),
	('Uluazapa'),
	('Moncagua'),
	('Quelepa'),
	('Chirilagua'),
	('Chinameca'),
	('Nueva Guadalupe'),
	('Lolotique'),
	('San Jorge'),
	('San Rafael Oriente'),
	('El Tr�nsito');

EXEC register_district @district = @districtSanMiguel, @department = 7;

-- 8 morazan

DECLARE @districtMorazan AS DistrictTableType;

INSERT INTO @districtMorazan (district_name)
VALUES 
	('Moraz�n Norte'),
	('Arambala'),
	('Cacaopera'),
	('Corinto'),
	('El Rosario'),
	('Joateca'),
	('Jocoaitique'),
	('Meanguera'),
	('Perqu�n'),
	('San Fernando'),
	('San Isidro'),
	('Torola'),
	('Chilanga'),
	('Delicias de Concepci�n'),
	('El Divisadero'),
	('Gualococti'),
	('Guatajiagua'),
	('Jocoro'),
	('Lolotiquillo'),
	('Osicala'),
	('San Carlos'),
	('San Francisco Gotera'),
	('San Sim�n'),
	('Sensembra'),
	('Sociedad'),
	('Yamabal'),
	('Yoloaiqu�n');

EXEC register_district @district = @districtMorazan, @department = 8;

-- 9 la union

DECLARE @districtLaUnion AS DistrictTableType;

INSERT INTO @districtLaUnion (district_name)
VALUES 
    ('Anamor�s'),
	('Bolivar'),
	('Concepci�n de Oriente'),
	('El Sauce'),
	('Lislique'),
	('Nueva Esparta'),
	('Pasaquina'),
	('Polor�s'),
	('San Jos� La Fuente'),
	('Santa Rosa de Lima'),
	('Conchagua'),
	('El Carmen'),
	('lntipuc�'),
	('La Uni�n'),
	('Meanguera del Golfo'),
	('San Alejo'),
	('Yayantique'),
	('Yucuaiqu�n');

EXEC register_district @district = @districtLaUnion, @department = 9;

-- 10 ahuachapn

DECLARE @districtAuchapan AS DistrictTableType;

INSERT INTO @districtAuchapan (district_name)
VALUES 
    ('Atiquizaya'),
	('El Refugio'),
	('San Lorenzo'),
	('Tur�n'),
	('Ahuachap�n'),
	('Apaneca'),
	('Concepci�n de Ataco'),
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
	('San Jos� Guayabal'),
	('Oratorio de Concepci�n'),
	('San Bartolom� Perulap�n'),
	('San Pedro Perulap�n'),
	('Cojutepeque'),
	('San Rafael Cedros'),
	('Candelaria'),
	('Monte San Juan'),
	('El Carmen'),
	('San Crist�bal'),
	('Santa Cruz Michapa'),
	('San Ram�n'),
	('El Rosario'),
	('Santa Cruz Analquito'),
	('Tenancingo');

EXEC register_district @district = @districtCuscatlan, @department = 12;

-- 13 la paz

DECLARE @districtLaPaz AS DistrictTableType;

INSERT INTO @districtLaPaz (district_name)
VALUES 
    ('Cuyultit�n'),
	('Olocuilta'),
	('San Juan Talpa'),
	('San Luis Talpa'),
	('San Pedro Masahuat'),
	('Tapalhuaca'),
	('San Francisco Chinameca'),
	('El Rosario'),
	('Jerusal�n'),
	('Mercedes La Ceiba'),
	('Para�so de Osorio'),
	('San Antonio Masahuat'),
	('San Emigdio'),
	('San Juan Tepezontes'),
	('San Luis La Herradura'),
	('San Miguel Tepezontes'),
	('San Pedro Nonualco'),
	('Santa Mar�a Ostuma'),
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
	('San Sebasti�n'),
	('San Lorenzo'),
	('Santo Domingo'),
	('San Vicente'),
	('Guadalupe'),
	('Verapaz'),
	('Tepetit�n'),
	('Tecoluca'),
	('San Cayetano lstepeque');

EXEC register_district @district = @districtSanVicente, @department = 14;

