

USE CarStore;
GO
IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetSpecials')
BEGIN
   DROP PROCEDURE GetSpecials
END
GO

CREATE PROCEDURE GetSpecials
AS
SELECT s.Title, s.Description
FROM Specials s
GO
