-- ============================================
-- PRUEBA Magnetron DESARROLLADOR SENIOR - BASE DE DATOS
-- Lista personas con total Facturado, si no tiene facturas, obtiene la persona y facturado = 0.
-- Kelly Diaz Granados 
-- ============================================
CREATE OR ALTER VIEW VW_TotalFacturadoPorPersona AS

SELECT 
    p.Per_ID,
    p.Per_Nombre,
    p.Per_Apellido,
    COALESCE(SUM(fd.FDet_Cantidad * pr.Prod_Precio), 0) AS TotalFacturado
FROM [dbo].[Persona] AS p
LEFT JOIN [dbo].[Fact_Encabezado] AS f
    ON f.zPer_ID = p.Per_ID
LEFT JOIN [dbo].[Fact_Detalle] AS fd
    ON fd.zFEnc_ID = f.FEnc_ID
LEFT JOIN [dbo].[Producto] AS pr
    ON fd.zProd_ID =pr.Prod_ID

GROUP BY 
    p.Per_ID,
    p.Per_Nombre,
    p.Per_Apellido;

