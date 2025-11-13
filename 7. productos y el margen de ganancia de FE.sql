-- ============================================
-- PRUEBA Magnetron DESARROLLADOR SENIOR - BASE DE DATOS
-- Liste los productos y el margen de ganancia de cada uno según su facturación.
-- Kelly Diaz Granados
-- ============================================

CREATE OR ALTER VIEW VW_Productos_MargenGanancia AS
SELECT 
    pr.Prod_ID,
    pr.Prod_Descripcion,
    COALESCE(
        CASE 
            WHEN SUM(fd.FDet_Cantidad * pr.Prod_Costo) = 0 THEN 0
            ELSE 
                (
                    (SUM(fd.FDet_Cantidad * pr.Prod_Precio) 
                    - SUM(fd.FDet_Cantidad * pr.Prod_Costo))
                    / SUM(fd.FDet_Cantidad * pr.Prod_Costo)
                ) * 100
        END, 
    0) AS MargenGananciaPorcentaje
FROM [dbo].[Producto] AS pr
LEFT JOIN [dbo].[Fact_Detalle] AS fd
    ON fd.zProd_ID = pr.Prod_ID
LEFT JOIN [dbo].[Fact_Encabezado] AS fe
    ON fe.FEnc_ID = fd.zFEnc_ID
GROUP BY 
    pr.Prod_ID,
    pr.Prod_Descripcion

