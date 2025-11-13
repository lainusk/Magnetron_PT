-- ============================================
-- DATOS DE PRUEBA - EMPRESA MAGNETRON_PT
-- Kelly Diaz Granados 
-- ============================================

-- PERSONAS 
INSERT INTO Persona (Per_Nombre, Per_Apellido, Per_TipoDocumento, Per_Documento)
VALUES
('Andres ','Garcia ','CC','9001001010'),
('Victor ','Lopez','CC','9002002020'),
('Ai re','Energia','NIT','9003003030'),
('Michelle','Arias','CC','9004004040'),
('Yudy','Munera','CC','9005005050'),
('Electri','Caribe','NIT','9006006060'),
('Kenneth','Rodriguez','CC','9007007070'),
('Raul','Martinez','CC','9008008080'),
('Rocio','Villanueva','CC','9009009090'),
('Andrea','Martinez','CC','9010010100');

-- PRODUCTOS 
INSERT INTO Producto (Prod_Descripcion, Prod_Precio, Prod_Costo, Prod_UM)
VALUES
('Transformador monofásico 15kVA', 1200000, 800000, 'unidad'),
('Transformador trifásico 45kVA', 3800000, 2500000, 'unidad'),
('Bobina de cobre 5kg', 450000, 300000, 'unidad'),
('Núcleo de hierro 10kg', 250000, 180000, 'unidad'),
('Aislador cerámico alta tensión', 90000, 50000, 'unidad'),
('Transformador de control 500VA', 650000, 400000, 'unidad');

-- FACTURAS (ENCABEZADOS)
INSERT INTO Fact_Encabezado (FEnc_Numero, FEnc_Fecha, zPer_ID)
VALUES
('FAC-1001', '2025-01-10', 1),
('FAC-1002', '2025-01-12', 2),
('FAC-1003', '2025-01-14', 3),
('FAC-1004', '2025-01-18', 4),
('FAC-1005', '2025-01-22', 5),
('FAC-1006', '2025-01-25', 6);

-- DETALLE DE FACTURAS
INSERT INTO Fact_Detalle (FDet_Linea, FDet_Cantidad, zProd_ID, zFEnc_ID)
VALUES
(1, 1, 1, 1), 
(2, 2, 5, 1), 
(1, 1, 2, 2), 
(2, 3, 5, 2), 
(1, 4, 3, 3), 
(1, 2, 4, 4), 
(2, 1, 6, 4), 
(1, 2, 1, 5), 
(2, 5, 5, 5), 
(1, 1, 2, 6), 
(2, 2, 3, 6); 