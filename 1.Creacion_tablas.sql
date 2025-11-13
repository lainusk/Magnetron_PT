-- ============================================
-- PRUEBA Magnetron DESARROLLADOR SENIOR - BASE DE DATOS
-- CREACIÓN DE TABLAS SEGÚN DIAGRAMA ORIGINAL
-- Kelly Diaz Granados 
-- ============================================

-- Eliminamos si existían antes (opcional, para volver a crear)
IF OBJECT_ID('Fact_Detalle', 'U') IS NOT NULL DROP TABLE Fact_Detalle;
IF OBJECT_ID('Fact_Encabezado', 'U') IS NOT NULL DROP TABLE Fact_Encabezado;
IF OBJECT_ID('Producto', 'U') IS NOT NULL DROP TABLE Producto;
IF OBJECT_ID('Persona', 'U') IS NOT NULL DROP TABLE Persona;
GO

-- ============================================
-- TABLA PERSONA
-- ============================================
CREATE TABLE Persona (
    Per_ID INT IDENTITY(1,1) PRIMARY KEY,
    Per_Nombre VARCHAR(100) NOT NULL,
    Per_Apellido VARCHAR(100) NOT NULL,
    Per_TipoDocumento VARCHAR(20) NOT NULL,
    Per_Documento VARCHAR(50) NOT NULL UNIQUE
);
GO

-- ============================================
-- TABLA PRODUCTO
-- ============================================
CREATE TABLE Producto (
    Prod_ID INT IDENTITY(1,1) PRIMARY KEY,
    Prod_Descripcion VARCHAR(255) NOT NULL,
    Prod_Precio DECIMAL(18,2) NOT NULL,
    Prod_Costo DECIMAL(18,2) NOT NULL,
    Prod_UM VARCHAR(30) NOT NULL -- Unidad de medida
);
GO

-- ============================================
-- TABLA FACT_ENCABEZADO
-- ============================================
CREATE TABLE Fact_Encabezado (
    FEnc_ID INT IDENTITY(1,1) PRIMARY KEY,
    FEnc_Numero VARCHAR(50) NOT NULL UNIQUE,
    FEnc_Fecha DATE NOT NULL,
    zPer_ID INT NOT NULL,
    CONSTRAINT FK_FactEncabezado_Persona FOREIGN KEY (zPer_ID)
        REFERENCES Persona(Per_ID)
        ON DELETE CASCADE
);
GO

-- ============================================
-- TABLA FACT_DETALLE
-- ============================================
CREATE TABLE Fact_Detalle (
    FDet_ID INT IDENTITY(1,1) PRIMARY KEY,
    FDet_Linea INT NOT NULL,
    FDet_Cantidad DECIMAL(18,2) NOT NULL,
    zProd_ID INT NOT NULL,
    zFEnc_ID INT NOT NULL,
    CONSTRAINT FK_FactDetalle_Producto FOREIGN KEY (zProd_ID)
        REFERENCES Producto(Prod_ID)
        ON DELETE CASCADE,
    CONSTRAINT FK_FactDetalle_FactEncabezado FOREIGN KEY (zFEnc_ID)
        REFERENCES Fact_Encabezado(FEnc_ID)
        ON DELETE CASCADE
);
GO
