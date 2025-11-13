-- ============================================
-- PRUEBA Magnetron DESARROLLADOR SENIOR - BASE DE DATOS
-- Liste los productos según su utilidad generada por facturación.
-- Kelly Diaz Granados
-- ============================================

CREATE OR ALTER VIEW VW_Productos_UtilidadGenerada AS
SELECT 
    pr.Prod_ID,
    pr.Prod_Descripcion,
    COALESCE(SUM((pr.Prod_Precio - pr.Prod_Costo) * fd.FDet_Cantidad), 0) AS UtilidadGenerada
FROM [dbo].[Producto] AS pr
LEFT JOIN [dbo].[Fact_Detalle] AS fd
    ON fd.zProd_ID = pr.Prod_ID
LEFT JOIN [dbo].[Fact_Encabezado] AS fe
    ON fe.FEnc_ID = fd.zFEnc_ID
GROUP BY 
    pr.Prod_ID,
    pr.Prod_Descripcion

