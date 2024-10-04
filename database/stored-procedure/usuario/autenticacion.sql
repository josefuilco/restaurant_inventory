/*
Autenticaci�n de usuario:
Descripci�n: El procedimiento tiene que aceptar el nombre de usuario y la contrase�a pero solo mostrar los datos si el usuario est� activo.
EXEC sp_Autenticaci�nUsuario 'admin','adminpass123';
*/

CREATE PROCEDURE sp_AutenticacionUsuario
    @vNom_User VARCHAR(25), 
    @vPass_User VARCHAR(40)
AS
BEGIN
    -- Verificar si el usuario existe y est� activo
    SELECT tId_User
    FROM USERS.USERS 
    WHERE vNom_User = @vNom_User AND vPass_User = @vPass_User AND bActivo = 1;
END;
