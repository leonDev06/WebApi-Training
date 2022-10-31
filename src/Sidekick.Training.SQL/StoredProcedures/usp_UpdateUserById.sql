CREATE PROCEDURE [dbo].[usp_UpdateUserById]
    @id INT,
    @name nvarchar(100),
    @email nvarchar(MAX)
AS
    UPDATE users
    SET Name = @name, Email = @email
    WHERE Id = @id;
RETURN 0