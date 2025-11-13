-- ============================================
-- PRUEBA Magnetron DESARROLLADOR SENIOR - BASE DE DATOS
-- Persona que compró el producto con el precio unitario más alto.
-- Kelly Diaz Granados 
-- ============================================

CREATE OR ALTER VIEW VW_Persona_ProductoMasCaro AS
SELECT 
    p.Per_ID,
    p.Per_Nombre,
    p.Per_Apellido,
    pr.Prod_ID,
    pr.Prod_Descripcion,
    pr.Prod_Precio AS PrecioProducto
FROM [dbo].[Persona] AS p
INNER JOIN [dbo].[Fact_Encabezado] AS fe
    ON fe.zPer_ID = p.Per_ID
INNER JOIN [dbo].[Fact_Detalle] AS fd
    ON fd.zFEnc_ID = fe.FEnc_ID
INNER JOIN [dbo].[Producto] AS pr
    ON pr.Prod_ID = fd.zProd_ID
WHERE pr.Prod_Precio = (
    SELECT MAX(pr2.Prod_Precio)
    FROM [dbo].[Producto] AS pr2
);
