/*
Traer Producto:
Descripci�n: El procedimiento tiene que traer la lista de productos para poder ser manejados desde el frontend.
EXEC sp_TraerProductos
*/
CREATE PROCEDURE sp_TraerProductos
AS
BEGIN
    -- Seleccionar la lista de productos
    SELECT iId_Prod, vNom_Prod, dPrecio_Prod, iStock_Prod, iStockMin_Prod, iId_Prov, tId_CatProd, bActivo_Prod
    FROM INVENTARIO.PRODUCTO
    WHERE bActivo_Prod = 1; -- Solo productos activos
END;