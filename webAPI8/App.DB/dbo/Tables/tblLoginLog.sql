CREATE TABLE [dbo].[tblLoginLog] (
    [cID]        INT            IDENTITY (1, 1) NOT NULL,
    [cUserID]    INT            NULL,
    [cUserToken] NVARCHAR (500) NULL,
    [cIP]        NVARCHAR (50)  NULL,
    [cCreateDT]  DATETIME       NULL,
    [cCreator]   INT            NULL,
    [cUpdateDT]  DATETIME       NULL,
    [cUpdator]   INT            NULL,
    CONSTRAINT [PK_tblLoginHistory] PRIMARY KEY CLUSTERED ([cID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'更新者Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblLoginLog', @level2type = N'COLUMN', @level2name = N'cUpdator';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'更新日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblLoginLog', @level2type = N'COLUMN', @level2name = N'cUpdateDT';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'建立者Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblLoginLog', @level2type = N'COLUMN', @level2name = N'cCreator';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'建立日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblLoginLog', @level2type = N'COLUMN', @level2name = N'cCreateDT';

