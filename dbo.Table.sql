CREATE TABLE [dbo].[TrapReports]
(
	[TrapReport_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Username] NVARCHAR(15) NOT NULL, 
    [Latitude] DECIMAL(9, 6) NOT NULL, 
    [Longitude] DECIMAL(9, 6) NOT NULL, 
    [Street] NVARCHAR(30) NOT NULL, 
    [City] NVARCHAR(30) NOT NULL, 
    [State] NCHAR(2) NOT NULL, 
    [TrapType] NCHAR(1) NOT NULL, 
    [ReportTime] NUMERIC(10) NOT NULL, 
    [ExpireTime] NUMERIC(10) NOT NULL,
	CONSTRAINT chkTrapType CHECK ([TrapType] in ('M', 'F'))
)
