CREATE PROCEDURE [dbo].[usp_GetUserByID]
	@id INT
AS
	SELECT Id, Name, Email
	FROM users
	WHERE Id = @id;
RETURN 0
