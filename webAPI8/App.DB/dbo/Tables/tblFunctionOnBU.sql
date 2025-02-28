CREATE TABLE [dbo].[tblFunctionOnBU] (
    [cBUID]       INT NOT NULL,
    [cFunctionID] INT NOT NULL,
    [cStatus]     INT NULL,
    CONSTRAINT [PK_tblFunctionOnBU] PRIMARY KEY CLUSTERED ([cBUID] ASC, [cFunctionID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'模組功能管理(對應企業)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'tblFunctionOnBU';

