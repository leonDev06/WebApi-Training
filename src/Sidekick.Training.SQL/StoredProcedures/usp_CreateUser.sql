CREATE PROCEDURE [dbo].[usp_CreateUser]
	@name nvarchar(100),
	@email nvarchar(MAX)
AS
	INSERT INTO users(Name, Email)
	OUTPUT INSERTED.Id
	VALUES(@name, @email);
RETURN 0
