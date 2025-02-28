CREATE TABLE [dbo].[tblBusinessUnit] (
    [cID]                INT            IDENTITY (1, 1) NOT NULL,
    [cBUCode]            NVARCHAR (20)  NULL,
    [cName]              NVARCHAR (50)  NULL,
    [cDescription]       NVARCHAR (200) NULL,
    [cCreateDT]          DATETIME       NULL,
    [cCreator]           INT            NULL,
    [cUpdateDT]          DATETIME       NULL,
    [cUpdator]           INT            NULL,
    [cStatus]            INT            NULL,
    [cRemark]            NVARCHAR (500) NULL,
    [cUserLimit]         INT            NULL,
    [cPlatformIsSupport] BIT            NULL,
    [cType]              INT            NULL,
    CONSTRAINT [PK_tblBusinessUnit] PRIMARY KEY CLUSTERED ([cID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'1 平台 2 商戶', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblBusinessUnit', @level2type = N'COLUMN', @level2name = N'cType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否支援', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblBusinessUnit', @level2type = N'COLUMN', @level2name = N'cPlatformIsSupport';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'使用者上限', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblBusinessUnit', @level2type = N'COLUMN', @level2name = N'cUserLimit';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'備註', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblBusinessUnit', @level2type = N'COLUMN', @level2name = N'cRemark';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'狀態', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblBusinessUnit', @level2type = N'COLUMN', @level2name = N'cStatus';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'說明', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblBusinessUnit', @level2type = N'COLUMN', @level2name = N'cDescription';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'BU名稱', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblBusinessUnit', @level2type = N'COLUMN', @level2name = N'cName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'BU代碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblBusinessUnit', @level2type = N'COLUMN', @level2name = N'cBUCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'BUID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblBusinessUnit', @level2type = N'COLUMN', @level2name = N'cID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'企業主檔', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblBusinessUnit';

