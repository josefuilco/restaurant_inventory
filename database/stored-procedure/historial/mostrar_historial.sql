/*
DESCRIPCION:
Mostrar el historial desde un rango de fechas pre-establecido.
---------------------------------------------------------------
PRUEBA:
EXEC sp_MostrarHistorial '2024-01-01', '2024-12-31';
*/

CREATE PROCEDURE sp_MostrarHistorial
	@from DATETIME,
	@to DATETIME
AS
BEGIN
	SELECT
		h.iId_HistProd,
		h.iCantActual_HistProd,
		h.iCantPre_HistProd,
		h.dFecha_HistProd,
		pr.iId_Prod,
		pr.vNom_Prod,
		o.iId_Ope,
		u.vNom_User,
		h.vDetalle
	FROM
		INVENTARIO.HISTORIALPRODUCTO h
	INNER JOIN
		INVENTARIO.OPERACION o ON h.iId_Ope = o.iId_Ope
	INNER JOIN
		USERS.USERS u ON h.tId_User = u.tId_User
	INNER JOIN
		INVENTARIO.PRODUCTO pr ON h.iId_Prod = pr.iId_Prod
	WHERE
		h.dFecha_HistProd BETWEEN @from AND @to;
END;