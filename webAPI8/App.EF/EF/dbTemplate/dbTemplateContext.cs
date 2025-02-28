using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace App.EF.EF.dbTemplate;

public partial class DbTemplateContext : DbContext
{
    public DbTemplateContext()
    {
    }

    public DbTemplateContext(DbContextOptions<DbTemplateContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAccessLog> TblAccessLog { get; set; }

    public virtual DbSet<TblBusinessUnit> TblBusinessUnit { get; set; }

    public virtual DbSet<TblFunction> TblFunction { get; set; }

    public virtual DbSet<TblFunctionOnBu> TblFunctionOnBu { get; set; }

    public virtual DbSet<TblFunctionOnGroup> TblFunctionOnGroup { get; set; }

    public virtual DbSet<TblLoginLog> TblLoginLog { get; set; }

    public virtual DbSet<TblSample> TblSample { get; set; }

    public virtual DbSet<TblUser> TblUser { get; set; }

    public virtual DbSet<TblUserGroup> TblUserGroup { get; set; }

    public virtual DbSet<TblUserOnGroup> TblUserOnGroup { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAccessLog>(entity =>
        {
            entity.HasKey(e => e.CId);

            entity.ToTable("tblAccessLog");

            entity.Property(e => e.CId).HasColumnName("cID");
            entity.Property(e => e.CActionName)
                .HasMaxLength(50)
                .HasComment("{\r\n  \"isquery\":1,\r\n  \"isRequire\":1,\r\n  \"columnDesc\":\"動作名稱\"\r\n}")
                .HasColumnName("cActionName");
            entity.Property(e => e.CApiname)
                .HasMaxLength(50)
                .HasComment("API")
                .HasColumnName("cAPIName");
            entity.Property(e => e.CCreateDt)
                .HasComment("建立日期")
                .HasColumnType("datetime")
                .HasColumnName("cCreateDT");
            entity.Property(e => e.CCreator)
                .HasComment("建立者Id")
                .HasColumnName("cCreator");
            entity.Property(e => e.CFunctionId)
                .HasComment("{\r\n  \"isquery\":1,\r\n  \"type\":\"dropdownlist\",\r\n  \"options\":[{\"text\":\"功能1\",\"value\":\"1\"},{\"text\":\"功能2\",\"value\":\"2\"},{\"text\":\"功能3\",\"value\":\"3\"}],\r\n  \"columnDesc\":\"功能\"\r\n}")
                .HasColumnName("cFunctionID");
            entity.Property(e => e.CIp)
                .HasMaxLength(50)
                .HasComment("IP")
                .HasColumnName("cIP");
            entity.Property(e => e.CRemark)
                .HasMaxLength(500)
                .HasComment("備註")
                .HasColumnName("cRemark");
            entity.Property(e => e.CRequest)
                .HasComment("請求參數")
                .HasColumnName("cRequest");
            entity.Property(e => e.CUpdateDt)
                .HasComment("更新日期")
                .HasColumnType("datetime")
                .HasColumnName("cUpdateDT");
            entity.Property(e => e.CUpdator)
                .HasComment("更新者Id")
                .HasColumnName("cUpdator");
            entity.Property(e => e.CUrl)
                .HasMaxLength(200)
                .HasComment("URL")
                .HasColumnName("cUrl");
            entity.Property(e => e.CUserId).HasColumnName("cUserID");
        });

        modelBuilder.Entity<TblBusinessUnit>(entity =>
        {
            entity.HasKey(e => e.CId);

            entity.ToTable("tblBusinessUnit", tb => tb.HasComment("企業主檔"));

            entity.Property(e => e.CId)
                .HasComment("BUID")
                .HasColumnName("cID");
            entity.Property(e => e.CBucode)
                .HasMaxLength(20)
                .HasComment("BU代碼")
                .HasColumnName("cBUCode");
            entity.Property(e => e.CCreateDt)
                .HasColumnType("datetime")
                .HasColumnName("cCreateDT");
            entity.Property(e => e.CCreator).HasColumnName("cCreator");
            entity.Property(e => e.CDescription)
                .HasMaxLength(200)
                .HasComment("說明")
                .HasColumnName("cDescription");
            entity.Property(e => e.CName)
                .HasMaxLength(50)
                .HasComment("BU名稱")
                .HasColumnName("cName");
            entity.Property(e => e.CPlatformIsSupport)
                .HasComment("是否支援")
                .HasColumnName("cPlatformIsSupport");
            entity.Property(e => e.CRemark)
                .HasMaxLength(500)
                .HasComment("備註")
                .HasColumnName("cRemark");
            entity.Property(e => e.CStatus)
                .HasComment("狀態")
                .HasColumnName("cStatus");
            entity.Property(e => e.CType)
                .HasComment("1 平台 2 商戶")
                .HasColumnName("cType");
            entity.Property(e => e.CUpdateDt)
                .HasColumnType("datetime")
                .HasColumnName("cUpdateDT");
            entity.Property(e => e.CUpdator).HasColumnName("cUpdator");
            entity.Property(e => e.CUserLimit)
                .HasComment("使用者上限")
                .HasColumnName("cUserLimit");
        });

        modelBuilder.Entity<TblFunction>(entity =>
        {
            entity.HasKey(e => e.CId);

            entity.ToTable("tblFunction", tb => tb.HasComment("單元(已審核)"));

            entity.Property(e => e.CId)
                .ValueGeneratedNever()
                .HasComment("模組編號")
                .HasColumnName("cID");
            entity.Property(e => e.CCompetenceType)
                .HasComment("(0:是單元, 1:新增, 2:修改, 3:檢視, 4:刪除, 5:審核)")
                .HasColumnName("cCompetenceType");
            entity.Property(e => e.CCreateDt)
                .HasComment("建立日期時間")
                .HasColumnType("datetime")
                .HasColumnName("cCreateDT");
            entity.Property(e => e.CCreator)
                .HasComment("建立者")
                .HasColumnName("cCreator");
            entity.Property(e => e.CCssStyle)
                .HasMaxLength(50)
                .HasComment("後台CSS樣式名稱")
                .HasColumnName("cCssStyle");
            entity.Property(e => e.CFlowId)
                .HasComment("審查流程ID")
                .HasColumnName("cFlowID");
            entity.Property(e => e.CIsDelete)
                .HasComment("緩刪除(0:未刪除, 1:已刪除)")
                .HasColumnName("cIsDelete");
            entity.Property(e => e.CIsMenu)
                .HasComment("是否為後台目錄(0:否, 1:是)")
                .HasColumnName("cIsMenu");
            entity.Property(e => e.CMenuIndex)
                .HasComment("前台及後台目錄索引值(排序由小到大)")
                .HasColumnName("cMenuIndex");
            entity.Property(e => e.CName)
                .HasMaxLength(20)
                .HasComment("模組名稱")
                .HasColumnName("cName");
            entity.Property(e => e.CPageUrl)
                .HasMaxLength(200)
                .HasComment("功能頁面")
                .HasColumnName("cPageUrl");
            entity.Property(e => e.CParentId)
                .HasComment("父模組編號")
                .HasColumnName("cParentID");
            entity.Property(e => e.CStatus)
                .HasComment("狀態(0:停用, 1:啟用)")
                .HasColumnName("cStatus");
            entity.Property(e => e.CUpdateDt)
                .HasComment("修改日期時間")
                .HasColumnType("datetime")
                .HasColumnName("cUpdateDT");
            entity.Property(e => e.CUpdator)
                .HasComment("修改者")
                .HasColumnName("cUpdator");
        });

        modelBuilder.Entity<TblFunctionOnBu>(entity =>
        {
            entity.HasKey(e => new { e.CBuid, e.CFunctionId });

            entity.ToTable("tblFunctionOnBU", tb => tb.HasComment("模組功能管理(對應企業)"));

            entity.Property(e => e.CBuid).HasColumnName("cBUID");
            entity.Property(e => e.CFunctionId).HasColumnName("cFunctionID");
            entity.Property(e => e.CStatus).HasColumnName("cStatus");
        });

        modelBuilder.Entity<TblFunctionOnGroup>(entity =>
        {
            entity.HasKey(e => new { e.CUserGroupId, e.CFunctionId }).HasName("PK_tblFunctionOnRole");

            entity.ToTable("tblFunctionOnGroup");

            entity.Property(e => e.CUserGroupId)
                .HasComment("使用者群組編號")
                .HasColumnName("cUserGroupID");
            entity.Property(e => e.CFunctionId)
                .HasComment("功能編號")
                .HasColumnName("cFunctionID");
        });

        modelBuilder.Entity<TblLoginLog>(entity =>
        {
            entity.HasKey(e => e.CId).HasName("PK_tblLoginHistory");

            entity.ToTable("tblLoginLog");

            entity.Property(e => e.CId).HasColumnName("cID");
            entity.Property(e => e.CCreateDt)
                .HasComment("建立日期")
                .HasColumnType("datetime")
                .HasColumnName("cCreateDT");
            entity.Property(e => e.CCreator)
                .HasComment("建立者Id")
                .HasColumnName("cCreator");
            entity.Property(e => e.CIp)
                .HasMaxLength(50)
                .HasColumnName("cIP");
            entity.Property(e => e.CUpdateDt)
                .HasComment("更新日期")
                .HasColumnType("datetime")
                .HasColumnName("cUpdateDT");
            entity.Property(e => e.CUpdator)
                .HasComment("更新者Id")
                .HasColumnName("cUpdator");
            entity.Property(e => e.CUserId).HasColumnName("cUserID");
            entity.Property(e => e.CUserToken)
                .HasMaxLength(500)
                .HasColumnName("cUserToken");
        });

        modelBuilder.Entity<TblSample>(entity =>
        {
            entity.HasKey(e => e.CId).HasName("PK_tblTemplate");

            entity.ToTable("tblSample");

            entity.Property(e => e.CId)
                .ValueGeneratedNever()
                .HasComment("Key")
                .HasColumnName("cId");
            entity.Property(e => e.CDescription)
                .HasMaxLength(500)
                .HasComment("{\r\n  \"isquery\":0,\r\n  \"isRequire\":1,\r\n  \"columnDesc\":\"必填範例\"\r\n}")
                .HasColumnName("cDescription");
            entity.Property(e => e.CQueryBox)
                .HasMaxLength(100)
                .HasComment("{\r\n  \"isquery\":1,\r\n  \"columnDesc\":\"查詢範例\"\r\n}")
                .HasColumnName("cQueryBox");
            entity.Property(e => e.CStartDate)
                .HasComment("日期範例")
                .HasColumnType("datetime")
                .HasColumnName("cStartDate");
            entity.Property(e => e.CTitle)
                .HasMaxLength(50)
                .HasComment("文字框範例")
                .HasColumnName("cTitle");
            entity.Property(e => e.CType)
                .HasMaxLength(10)
                .HasComment("{\r\n  \"isquery\":1,\r\n  \"isRequire\":1,\r\n  \"type\":\"dropdownlist\",\r\n  \"options\":[{\"text\":\"功能1\",\"value\":\"T1\"},{\"text\":\"功能2\",\"value\":\"T2\"},{\"text\":\"功能3\",\"value\":\"T3\"}],\r\n  \"columnDesc\":\"下拉範例\"\r\n}")
                .HasColumnName("cType");
            entity.Property(e => e.CType2)
                .HasMaxLength(100)
                .HasComment("{\r\n  \"isquery\":0,\r\n  \"isRequire\":1,\r\n  \"type\":\"dropdownlist\",\r\n  \"options\":[{\"text\":\"B功能1\",\"value\":\"T1\"},{\"text\":\"B功能2\",\"value\":\"T2\"},{\"text\":\"B功能3\",\"value\":\"T3\"}],\r\n  \"columnDesc\":\"下拉範例2\"\r\n}")
                .HasColumnName("cType2");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.CUserId);

            entity.ToTable("tblUser", tb => tb.HasComment("使用者"));

            entity.Property(e => e.CUserId)
                .HasComment("使用者編號編號")
                .HasColumnName("cUserID");
            entity.Property(e => e.CAccount)
                .HasMaxLength(100)
                .HasComment("cAccount、cAccount2都不可重複")
                .HasColumnName("cAccount");
            entity.Property(e => e.CAgentUnit)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("代理單位")
                .HasColumnName("cAgentUnit");
            entity.Property(e => e.CBuid)
                .HasComment("BU")
                .HasColumnName("cBUID");
            entity.Property(e => e.CCreateDt)
                .HasComment("建立日期時間")
                .HasColumnType("datetime")
                .HasColumnName("cCreateDT");
            entity.Property(e => e.CCreator)
                .HasComment("建立者")
                .HasColumnName("cCreator");
            entity.Property(e => e.CIsDelete)
                .HasComment("緩刪除(0:未刪除, 1:已刪除)")
                .HasColumnName("cIsDelete");
            entity.Property(e => e.CIsDeptManager)
                .HasComment("是否為單位最高權限(0:否, 1:是)")
                .HasColumnName("cIsDeptManager");
            entity.Property(e => e.CMail)
                .HasMaxLength(254)
                .HasComment("信箱")
                .HasColumnName("cMail");
            entity.Property(e => e.CPassword)
                .HasComment("密碼")
                .HasColumnName("cPassword");
            entity.Property(e => e.CStatus)
                .HasComment("狀態 0:停用 1:啟用")
                .HasColumnName("cStatus");
            entity.Property(e => e.CUpdateDt)
                .HasComment("更新日期時間")
                .HasColumnType("datetime")
                .HasColumnName("cUpdateDT");
            entity.Property(e => e.CUpdator)
                .HasComment("更新者")
                .HasColumnName("cUpdator");
            entity.Property(e => e.CUserName)
                .HasMaxLength(50)
                .HasComment("使用者名稱")
                .HasColumnName("cUserName");
        });

        modelBuilder.Entity<TblUserGroup>(entity =>
        {
            entity.HasKey(e => e.CId);

            entity.ToTable("tblUserGroup", tb => tb.HasComment("使用者群組"));

            entity.Property(e => e.CId)
                .HasComment("使用者群組編號")
                .HasColumnName("cID");
            entity.Property(e => e.CBuid).HasColumnName("cBUID");
            entity.Property(e => e.CCreateDt)
                .HasComment("建立日期時間")
                .HasColumnType("datetime")
                .HasColumnName("cCreateDT");
            entity.Property(e => e.CCreator)
                .HasComment("建立者")
                .HasColumnName("cCreator");
            entity.Property(e => e.CName)
                .HasMaxLength(100)
                .HasComment("群組名稱")
                .HasColumnName("cName");
            entity.Property(e => e.CStatus)
                .HasComment("狀態(0:停用, 1:啟用)")
                .HasColumnName("cStatus");
            entity.Property(e => e.CUpdateDt)
                .HasComment("更新日期時間")
                .HasColumnType("datetime")
                .HasColumnName("cUpdateDT");
            entity.Property(e => e.CUpdator)
                .HasComment("更新者")
                .HasColumnName("cUpdator");
        });

        modelBuilder.Entity<TblUserOnGroup>(entity =>
        {
            entity.HasKey(e => new { e.CUserId, e.CUserGroupId });

            entity.ToTable("tblUserOnGroup");

            entity.Property(e => e.CUserId).HasColumnName("cUserID");
            entity.Property(e => e.CUserGroupId).HasColumnName("cUserGroupID");
            entity.Property(e => e.CStatus).HasColumnName("cStatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
