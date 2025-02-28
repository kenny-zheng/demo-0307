CREATE TABLE [dbo].[tblFunctionOnGroup] (
    [cUserGroupID] INT NOT NULL,
    [cFunctionID]  INT NOT NULL,
    CONSTRAINT [PK_tblFunctionOnRole] PRIMARY KEY CLUSTERED ([cUserGroupID] ASC, [cFunctionID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'功能編號', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblFunctionOnGroup', @level2type = N'COLUMN', @level2name = N'cFunctionID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'使用者群組編號', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblFunctionOnGroup', @level2type = N'COLUMN', @level2name = N'cUserGroupID';

