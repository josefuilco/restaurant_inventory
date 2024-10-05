/*
Traer Producto:
Descripci�n: El procedimiento tiene que traer la lista de productos para poder ser manejados desde el frontend.
EXEC sp_TraerProductos
*/
CREATE PROCEDURE sp_TraerProductos
AS
BEGIN
    -- Seleccionar la lista de productos
    SELECT
        prod.iId_Prod,
        prod.vNom_Prod,
        prod.dPrecio_Prod,
        prod.iStock_Prod,
        prod.iStockMin_Prod,
        prod.iId_Prov,
		prov.vNom_Prov,
        prod.tId_CatProd
    FROM INVENTARIO.PRODUCTO prod
    INNER JOIN INVENTARIO.PROVEEDOR prov ON prod.iId_Prov = prov.iId_Prov
    WHERE prod.bActivo_Prod = 1; -- Solo productos activos
END;