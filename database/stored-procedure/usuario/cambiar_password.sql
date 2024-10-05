CREATE PROCEDURE sp_CambiarPassword
    @tId_User TINYINT,
    @newPass_User VARCHAR(40),
    @prevPass_User VARCHAR(40)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM USERS.USERS WHERE tId_User = @tId_User AND vPass_User = @prevPass_User)
    BEGIN
        UPDATE USERS.USERS
        SET vPass_User = @newPass_User
        WHERE tId_User = @tId_User;
    END
    ELSE
    BEGIN
        RAISERROR ('La password anterior no coincide', 16, 1);
        RETURN;
    END
END;
