-- ============================================
-- PRUEBA Magnetron DESARROLLADOR SENIOR - BASE DE DATOS
-- Liste los productos según su cantidad facturada en orden descendente.
-- Kelly Diaz Granados
-- ============================================

CREATE OR ALTER VIEW VW_Productos_CantidadFacturada AS
SELECT 
    pr.Prod_ID,
    pr.Prod_Descripcion,
    COALESCE(SUM(fd.FDet_Cantidad), 0) AS CantidadFacturada
FROM [dbo].[Producto] AS pr
LEFT JOIN [dbo].[Fact_Detalle] AS fd
    ON fd.zProd_ID = pr.Prod_ID
GROUP BY 
    pr.Prod_ID,
    pr.Prod_Descripcion

