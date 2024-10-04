CREATE DATABASE InventarioRestauranteDB;
USE InventarioRestauranteDB;

CREATE SCHEMA USERS;
CREATE TABLE USERS.ROLES
(
	tId_Rol TINYINT PRIMARY KEY,
	vNom_Rol VARCHAR(30) NOT NULL
);
CREATE TABLE USERS.USERS
(
	tId_User TINYINT IDENTITY(1,1) PRIMARY KEY,
	vNom_User VARCHAR(25) NOT NULL,
	vPass_User VARCHAR(40) NOT NULL,
	vCorreo_User VARCHAR(50) NOT NULL,
	dFecha_User DATETIME NOT NULL,
	bActivo BIT NOT NULL,
	tId_Rol TINYINT NOT NULL,
	FOREIGN KEY (tId_Rol) REFERENCES USERS.ROLES (tId_Rol)
);
GO

CREATE SCHEMA INVENTARIO;
CREATE TABLE INVENTARIO.OPERACION
(
	iId_Ope INT IDENTITY(1,1) PRIMARY KEY,
	vTipo_Ope VARCHAR(25) NOT NULL,
	bActivo BIT NOT NULL
);

CREATE TABLE INVENTARIO.UNIDADMEDIDA
(
	tId_UniMed TINYINT IDENTITY(1,1) PRIMARY KEY,
	vNombre_UniMed VARCHAR(25) NOT NULL
);
CREATE TABLE INVENTARIO.CATEGORIAPRODUCTO
(
	tId_CatProd TINYINT IDENTITY(1,1) PRIMARY KEY,
	vNom_CatProd VARCHAR(30) NOT NULL,
	tId_UniMed TINYINT NOT NULL,
	FOREIGN KEY (tId_UniMed) REFERENCES INVENTARIO.UNIDADMEDIDA (tId_UniMed)
);
CREATE TABLE INVENTARIO.PROVEEDOR
(
	iId_Prov INT IDENTITY(1,1) PRIMARY KEY,
	vNom_Prov VARCHAR(30) NOT NULL,
	vTel_Prov VARCHAR(9) NOT NULL,
	bActivo BIT NOT NULL
);
CREATE TABLE INVENTARIO.PRODUCTO
(
	iId_Prod INT IDENTITY(1,1) PRIMARY KEY,
	vNom_Prod VARCHAR(30) NOT NULL,
	dPrecio_Prod DECIMAL(6,2) NOT NULL,
	iStock_Prod INT NOT NULL,
	iStockMin_Prod INT NOT NULL,
	bActivo_Prod BIT NOT NULL,
	iId_Prov INT NOT NULL,
	FOREIGN KEY (iId_Prov) REFERENCES INVENTARIO.PROVEEDOR (iId_Prov),
	tId_CatProd TINYINT NOT NULL,
	FOREIGN KEY (tId_CatProd) REFERENCES INVENTARIO.CATEGORIAPRODUCTO (tId_CatProd)
);
CREATE TABLE INVENTARIO.HISTORIALPRODUCTO
(
	iId_HistProd INT IDENTITY(1,1) PRIMARY KEY,
	iCantActual_HistProd INT NOT NULL,
	iCantPre_HistProd INT NOT NULL,
	dFecha_HistProd DATETIME NOT NULL,
	iId_Prod INT NOT NULL,
	FOREIGN KEY (iId_Prod) REFERENCES INVENTARIO.PRODUCTO (iId_Prod),
	iId_Ope INT NOT NULL,
	tId_User INT,
	vDetalle VARCHAR(100)
);
CREATE TABLE INVENTARIO.CATEGORIACOMIDA
(
	tId_CatComida TINYINT IDENTITY(1,1) PRIMARY KEY,
	vNom_CatComida VARCHAR(30) NOT NULL
);
CREATE TABLE INVENTARIO.COMIDA
(
	iId_Comida INT IDENTITY(1,1) PRIMARY KEY,
	vNom_Comida VARCHAR(30) NOT NULL,
	dPrecio_Comida DECIMAL(6,2) NOT NULL,
	vCant_Comida INT NOT NULL,
	bActivo BIT NOT NULL,
	tId_CatComida TINYINT NOT NULL,
	FOREIGN KEY (tId_CatComida) REFERENCES INVENTARIO.CATEGORIACOMIDA (tId_CatComida)
);
CREATE TABLE INVENTARIO.RECETA
(
	iId_Receta INT IDENTITY(1,1) PRIMARY KEY,
	iCantProd_Receta INT NOT NULL,
	iId_Comida INT NOT NULL,
	FOREIGN KEY (iId_Comida) REFERENCES INVENTARIO.COMIDA (iId_Comida),
	iId_Prod INT NOT NULL,
	FOREIGN KEY (iId_Prod) REFERENCES INVENTARIO.PRODUCTO (iId_Prod)
);