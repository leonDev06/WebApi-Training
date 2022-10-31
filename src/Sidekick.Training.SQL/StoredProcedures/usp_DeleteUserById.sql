CREATE PROCEDURE [dbo].[usp_DeleteUserById]
	@id INT
AS    
	DELETE FROM users    WHERE Id = @id;
RETURN 0

