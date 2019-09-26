/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
Declare @version int
SET @version = 2

IF(EXiSTS(Select top 1 1 from dbo.VersionInfo where Number= @version))
BEGIN
	Update dbo.VersionInfo
	SET DateTime = GETDATE()
	where Number= @version
END
ELSE
BEGIN
	INSERT dbo.VersionInfo (Number,DateTime)
	Values (@version,GETDATE())
END

:r ReferenceData.sql