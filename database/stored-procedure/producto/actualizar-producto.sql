/*
Actualizar Producto:
Descripción: El procedimiento tiene que actualizar las características del producto según su ID.
EXEC sp_ActualizarProducto 15, 'CHICKEN', 10, 250, 50,1,3, 20, 2 
*/

ALTER PROCEDURE sp_ActualizarProducto
	@iId_Prod INT,
    @vNom_Prod VARCHAR(30),
    @dPrecio_Prod DECIMAL(6,2),
    @iStock_Prod INT,
    @iStockMin_Prod INT,
    @iId_Prov INT,
    @tId_CatProd TINYINT,
	@IdUser INT
AS
BEGIN
    UPDATE INVENTARIO.PRODUCTO
    SET vNom_Prod = @vNom_Prod,
        dPrecio_Prod = @dPrecio_Prod,
        iStock_Prod = @iStock_Prod,
        iStockMin_Prod = @iStockMin_Prod,
        iId_Prov = @iId_Prov,
        tId_CatProd = @tId_CatProd
    WHERE iId_Prod = @iId_Prod AND bActivo_Prod = 1;

	INSERT INTO INVENTARIO.HISTORIALPRODUCTO
	(iCantActual_HistProd, 
	iCantPre_HistProd,
	dFecha_HistProd, 
	iId_Prod, 
	iId_Ope, 
	vDetalle, 
	tId_User)
    VALUES 
	(@iStock_Prod, 
	(SELECT TOP 1 iCantActual_HistProd FROM INVENTARIO.HISTORIALPRODUCTO WHERE iId_Prod = @iId_Prod ORDER BY dFecha_HistProd DESC),
	GETDATE(), 
	@iId_Prod, 
	3, 
	'Producto Actualizado', 
	@IdUser);

END;
