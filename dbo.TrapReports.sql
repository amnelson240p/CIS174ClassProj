CREATE TABLE [dbo].[TrapReports] (
    [TrapReport_Id] INT            IDENTITY (1, 1) NOT NULL,
    [User_Id]      INT  NOT NULL,
    [Latitude]      DECIMAL (9, 6) NOT NULL,
    [Longitude]     DECIMAL (9, 6) NOT NULL,
    [Street]        NVARCHAR (30)  NOT NULL,
    [City]          NVARCHAR (30)  NOT NULL,
    [State]         NCHAR (2)      NOT NULL,
    [TrapType]      NCHAR (1)      NOT NULL,
    [ReportTime]    NUMERIC (10)   NOT NULL,
    [ExpireTime]    NUMERIC (10)   NOT NULL,
    PRIMARY KEY CLUSTERED ([TrapReport_Id] ASC),
    CONSTRAINT [chkTrapType] CHECK ([TrapType]='F' OR [TrapType]='M'),
	CONSTRAINT fk_TrapReport_UserInfo FOREIGN KEY (User_Id) REFERENCES UserInfo(User_Id) 
);

