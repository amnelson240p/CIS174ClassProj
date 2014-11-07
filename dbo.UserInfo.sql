CREATE TABLE [dbo].[UserInfo] (
    [User_Id]  INT           IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (15) NOT NULL,
    [Password] NVARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([User_Id] ASC),
    CONSTRAINT [uc_UserID] UNIQUE NONCLUSTERED ([User_Id] ASC, [Username] ASC)
);

