USE [fsdbunit]
GO

CREATE PROCEDURE [dbo].[up_MigrateData_TableA_To_TableB]
AS

TRUNCATE TABLE [dbo].[TableB]

INSERT INTO [dbo].[TableB]
( [TableB_Code], [TableB_Name] )
SELECT  [A].[TableA_Code],
		[A].[TableA_Name1] + [A].[TableA_Name2]
FROM	[dbo].[TableA] AS [A]