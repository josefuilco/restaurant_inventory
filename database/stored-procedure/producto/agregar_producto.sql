/*
Agregar Producto
Descripción: El procedimiento debe de insertar un producto a la tabla productos.

EXEC sp_AgregarProducto 'POLLO', 15.75, 200, 20, 2, 3, 10, 1
*/

CREATE PROCEDURE sp_AgregarProducto
	@vNom_Prod VARCHAR(30),
	@dPrecio_Prod DECIMAL(6,2),
	@iStock_Prod INT,
	@iStockMin_Prod INT,
	@iId_Prov INT,
	@tId_CatProd TINYINT,
	@CantidadActualizada INT,
	@IdUser INT
AS
BEGIN
	INSERT INTO INVENTARIO.PRODUCTO
	(vNom_Prod,
	dPrecio_Prod,
	iStock_Prod,
	iStockMin_Prod,
	bActivo_Prod,
	iId_Prov,
	tId_CatProd)
	VALUES 
	(@vNom_Prod, 
	@dPrecio_Prod, 
	@iStock_Prod, 
	@iStockMin_Prod, 
	1, 
	@iId_Prov, 
	@tId_CatProd);

	INSERT INTO INVENTARIO.HISTORIALPRODUCTO(
	iCantActual_HistProd, 
	iCantPre_HistProd,
	dFecha_HistProd, 
	iId_Prod, 
	iId_Ope, 
	vDetalle, 
	tId_User)
    VALUES (
	@CantidadActualizada, 
	0,
	GETDATE(), 
	(SELECT TOP 1 iId_Prod FROM INVENTARIO.PRODUCTO ORDER BY 1 DESC), 
	1, 
	'Producto Nuevo', 
	@IdUser);
END


