CREATE TABLE [dbo].[tblUserGroup] (
    [cID]       INT            IDENTITY (1, 1) NOT NULL,
    [cName]     NVARCHAR (100) NULL,
    [cStatus]   INT            NULL,
    [cCreator]  INT            NULL,
    [cCreateDT] DATETIME       NULL,
    [cUpdator]  INT            NULL,
    [cUpdateDT] DATETIME       NULL,
    [cBUID]     INT            NULL,
    CONSTRAINT [PK_tblUserGroup] PRIMARY KEY CLUSTERED ([cID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'更新日期時間', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblUserGroup', @level2type = N'COLUMN', @level2name = N'cUpdateDT';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'更新者', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblUserGroup', @level2type = N'COLUMN', @level2name = N'cUpdator';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'建立日期時間', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblUserGroup', @level2type = N'COLUMN', @level2name = N'cCreateDT';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'建立者', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblUserGroup', @level2type = N'COLUMN', @level2name = N'cCreator';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'狀態(0:停用, 1:啟用)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblUserGroup', @level2type = N'COLUMN', @level2name = N'cStatus';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'群組名稱', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblUserGroup', @level2type = N'COLUMN', @level2name = N'cName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'使用者群組編號', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblUserGroup', @level2type = N'COLUMN', @level2name = N'cID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'使用者群組', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblUserGroup';

