/*
SELECT * FROM INVENTARIO.HISTORIALPRODUCTO
SELECT * FROM INVENTARIO.PRODUCTO
EXEC sp_ActualizarStock 15, 5, 2
*/

CREATE PROCEDURE sp_ActualizarStock
	@iId_Prod INT,
	@CantidadActualizada INT,
	@IdUser INT
AS
BEGIN
	UPDATE INVENTARIO.PRODUCTO
	SET iStock_Prod = @CantidadActualizada
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
	(@CantidadActualizada, 
	(SELECT TOP 1 iCantActual_HistProd FROM INVENTARIO.HISTORIALPRODUCTO WHERE iId_Prod = @iId_Prod ORDER BY dFecha_HistProd DESC),
	GETDATE(), 
	@iId_Prod, 
	3, 
	'Producto Actualizado - Stock', 
	@IdUser);
END;
