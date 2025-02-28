CREATE TABLE [dbo].[tblUserOnGroup] (
    [cUserID]      INT NOT NULL,
    [cUserGroupID] INT NOT NULL,
    [cStatus]      BIT NULL,
    CONSTRAINT [PK_tblUserOnGroup] PRIMARY KEY CLUSTERED ([cUserID] ASC, [cUserGroupID] ASC)
);

