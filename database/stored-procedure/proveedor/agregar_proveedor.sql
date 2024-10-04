/*
Agregar Proveedor:
Descripci�n: El procedimiento tiene que agregar un proveedor a la base de datos.
EXEC sp_AgregarProveedor 'PROV 1 PRUEBA', '948597856'
*/

CREATE PROCEDURE sp_AgregarProveedor
    @vNom_Prov VARCHAR(30),
    @vTel_Prov VARCHAR(9)
AS
BEGIN
    -- Insertar un nuevo proveedor en la tabla INVENTARIO.PROVEEDOR
    INSERT INTO INVENTARIO.PROVEEDOR (vNom_Prov, vTel_Prov, bActivo)
    VALUES (@vNom_Prov, @vTel_Prov, 1);
	SELECT 
	vNom_Prov, 
	vTel_Prov, 
	bActivo
	FROM INVENTARIO.PROVEEDOR
END;
