CREATE TABLE [dbo].[tblAccessLog] (
    [cID]         INT            IDENTITY (1, 1) NOT NULL,
    [cUserID]     INT            NULL,
    [cFunctionID] INT            NULL,
    [cActionName] NVARCHAR (50)  NULL,
    [cAPIName]    NVARCHAR (50)  NULL,
    [cRequest]    NVARCHAR (MAX) NULL,
    [cUrl]        NVARCHAR (200) NULL,
    [cRemark]     NVARCHAR (500) NULL,
    [cIP]         NVARCHAR (50)  NULL,
    [cCreateDT]   DATETIME       NULL,
    [cCreator]    INT            NULL,
    [cUpdateDT]   DATETIME       NULL,
    [cUpdator]    INT            NULL,
    CONSTRAINT [PK_tblAccessLog] PRIMARY KEY CLUSTERED ([cID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'更新者Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblAccessLog', @level2type = N'COLUMN', @level2name = N'cUpdator';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'更新日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblAccessLog', @level2type = N'COLUMN', @level2name = N'cUpdateDT';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'建立者Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblAccessLog', @level2type = N'COLUMN', @level2name = N'cCreator';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'建立日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblAccessLog', @level2type = N'COLUMN', @level2name = N'cCreateDT';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'IP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblAccessLog', @level2type = N'COLUMN', @level2name = N'cIP';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'備註', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblAccessLog', @level2type = N'COLUMN', @level2name = N'cRemark';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'URL', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblAccessLog', @level2type = N'COLUMN', @level2name = N'cUrl';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'請求參數', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblAccessLog', @level2type = N'COLUMN', @level2name = N'cRequest';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'API', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblAccessLog', @level2type = N'COLUMN', @level2name = N'cAPIName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'{
  "isquery":1,
  "isRequire":1,
  "columnDesc":"動作名稱"
}', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblAccessLog', @level2type = N'COLUMN', @level2name = N'cActionName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'{
  "isquery":1,
  "type":"dropdownlist",
  "options":[{"text":"功能1","value":"1"},{"text":"功能2","value":"2"},{"text":"功能3","value":"3"}],
  "columnDesc":"功能"
}', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblAccessLog', @level2type = N'COLUMN', @level2name = N'cFunctionID';

