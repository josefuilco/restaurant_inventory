/*
Borrar Producto:
Descripción: El procedimiento tiene que actualizar el estado del producto, de true a false, para identificar si el producto ha sido borrado.

exec sp_BorrarProducto '15', 1
*/
CREATE PROCEDURE sp_BorrarProducto
    @iId_Prod INT,
	@IdUser INT
AS
BEGIN
    -- Actualizar el estado del producto a inactivo (borrar)
    UPDATE INVENTARIO.PRODUCTO
    SET bActivo_Prod = 0
    WHERE iId_Prod = @iId_Prod;

	INSERT INTO INVENTARIO.HISTORIALPRODUCTO
	(iCantActual_HistProd, 
	iCantPre_HistProd,
	dFecha_HistProd, 
	iId_Prod, 
	iId_Ope, 
	vDetalle, 
	tId_User)
    VALUES 
	(0, 
	0,
	GETDATE(), 
	@iId_Prod, 
	2, 
	'Producto Eliminado', 
	@IdUser);
END;