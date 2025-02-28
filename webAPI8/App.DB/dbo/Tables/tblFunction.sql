CREATE TABLE [dbo].[tblFunction] (
    [cID]             INT            NOT NULL,
    [cName]           NVARCHAR (20)  NULL,
    [cParentID]       INT            NULL,
    [cPageUrl]        NVARCHAR (200) NULL,
    [cIsMenu]         BIT            NULL,
    [cMenuIndex]      INT            NULL,
    [cCssStyle]       NVARCHAR (50)  NULL,
    [cStatus]         INT            NULL,
    [cIsDelete]       BIT            NULL,
    [cCompetenceType] TINYINT        NULL,
    [cCreateDT]       DATETIME       NULL,
    [cCreator]        INT            NULL,
    [cUpdateDT]       DATETIME       NULL,
    [cUpdator]        INT            NULL,
    [cFlowID]         INT            NOT NULL,
    CONSTRAINT [PK_tblFunction] PRIMARY KEY CLUSTERED ([cID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'審查流程ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblFunction', @level2type = N'COLUMN', @level2name = N'cFlowID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'修改者', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblFunction', @level2type = N'COLUMN', @level2name = N'cUpdator';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'修改日期時間', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblFunction', @level2type = N'COLUMN', @level2name = N'cUpdateDT';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'建立者', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblFunction', @level2type = N'COLUMN', @level2name = N'cCreator';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'建立日期時間', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblFunction', @level2type = N'COLUMN', @level2name = N'cCreateDT';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'(0:是單元, 1:新增, 2:修改, 3:檢視, 4:刪除, 5:審核)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblFunction', @level2type = N'COLUMN', @level2name = N'cCompetenceType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'緩刪除(0:未刪除, 1:已刪除)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblFunction', @level2type = N'COLUMN', @level2name = N'cIsDelete';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'狀態(0:停用, 1:啟用)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblFunction', @level2type = N'COLUMN', @level2name = N'cStatus';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'後台CSS樣式名稱', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblFunction', @level2type = N'COLUMN', @level2name = N'cCssStyle';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'前台及後台目錄索引值(排序由小到大)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblFunction', @level2type = N'COLUMN', @level2name = N'cMenuIndex';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否為後台目錄(0:否, 1:是)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblFunction', @level2type = N'COLUMN', @level2name = N'cIsMenu';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'功能頁面', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblFunction', @level2type = N'COLUMN', @level2name = N'cPageUrl';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'父模組編號', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblFunction', @level2type = N'COLUMN', @level2name = N'cParentID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'模組名稱', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblFunction', @level2type = N'COLUMN', @level2name = N'cName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'模組編號', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblFunction', @level2type = N'COLUMN', @level2name = N'cID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'單元(已審核)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblFunction';

