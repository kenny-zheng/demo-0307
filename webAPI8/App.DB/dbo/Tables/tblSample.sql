CREATE TABLE [dbo].[tblSample] (
    [cId]          INT            NOT NULL,
    [cTitle]       NVARCHAR (50)  NULL,
    [cDescription] NVARCHAR (500) NULL,
    [cType]        NVARCHAR (10)  NOT NULL,
    [cStartDate]   DATETIME       NOT NULL,
    [cQueryBox]    NVARCHAR (100) NULL,
    [cType2]       NVARCHAR (100) NULL,
    CONSTRAINT [PK_tblTemplate] PRIMARY KEY CLUSTERED ([cId] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'{
  "isquery":0,
  "isRequire":1,
  "type":"dropdownlist",
  "options":[{"text":"B功能1","value":"T1"},{"text":"B功能2","value":"T2"},{"text":"B功能3","value":"T3"}],
  "columnDesc":"下拉範例2"
}', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblSample', @level2type = N'COLUMN', @level2name = N'cType2';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'{
  "isquery":1,
  "columnDesc":"查詢範例"
}', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblSample', @level2type = N'COLUMN', @level2name = N'cQueryBox';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'日期範例', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblSample', @level2type = N'COLUMN', @level2name = N'cStartDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'{
  "isquery":1,
  "isRequire":1,
  "type":"dropdownlist",
  "options":[{"text":"功能1","value":"T1"},{"text":"功能2","value":"T2"},{"text":"功能3","value":"T3"}],
  "columnDesc":"下拉範例"
}', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblSample', @level2type = N'COLUMN', @level2name = N'cType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'{
  "isquery":0,
  "isRequire":1,
  "columnDesc":"必填範例"
}', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblSample', @level2type = N'COLUMN', @level2name = N'cDescription';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'文字框範例', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblSample', @level2type = N'COLUMN', @level2name = N'cTitle';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Key', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblSample', @level2type = N'COLUMN', @level2name = N'cId';

