CREATE TABLE [dbo].[tblUser] (
    [cUserID]        INT            IDENTITY (1, 1) NOT NULL,
    [cUserName]      NVARCHAR (50)  NULL,
    [cAccount]       NVARCHAR (100) NULL,
    [cPassword]      NVARCHAR (MAX) NULL,
    [cMail]          NVARCHAR (254) NULL,
    [cIsDeptManager] BIT            NULL,
    [cIsDelete]      BIT            NULL,
    [cCreator]       INT            NULL,
    [cCreateDT]      DATETIME       NULL,
    [cUpdator]       INT            NULL,
    [cUpdateDT]      DATETIME       NULL,
    [cStatus]        INT            NULL,
    [cAgentUnit]     VARCHAR (20)   NULL,
    [cBUID]          INT            NULL,
    CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED ([cUserID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'BU', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblUser', @level2type = N'COLUMN', @level2name = N'cBUID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'代理單位', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblUser', @level2type = N'COLUMN', @level2name = N'cAgentUnit';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'狀態 0:停用 1:啟用', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblUser', @level2type = N'COLUMN', @level2name = N'cStatus';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'更新日期時間', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblUser', @level2type = N'COLUMN', @level2name = N'cUpdateDT';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'更新者', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblUser', @level2type = N'COLUMN', @level2name = N'cUpdator';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'建立日期時間', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblUser', @level2type = N'COLUMN', @level2name = N'cCreateDT';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'建立者', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblUser', @level2type = N'COLUMN', @level2name = N'cCreator';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'緩刪除(0:未刪除, 1:已刪除)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblUser', @level2type = N'COLUMN', @level2name = N'cIsDelete';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否為單位最高權限(0:否, 1:是)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblUser', @level2type = N'COLUMN', @level2name = N'cIsDeptManager';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'信箱', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblUser', @level2type = N'COLUMN', @level2name = N'cMail';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'密碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblUser', @level2type = N'COLUMN', @level2name = N'cPassword';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'cAccount、cAccount2都不可重複', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblUser', @level2type = N'COLUMN', @level2name = N'cAccount';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'使用者名稱', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblUser', @level2type = N'COLUMN', @level2name = N'cUserName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'使用者編號編號', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblUser', @level2type = N'COLUMN', @level2name = N'cUserID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'使用者', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblUser';

