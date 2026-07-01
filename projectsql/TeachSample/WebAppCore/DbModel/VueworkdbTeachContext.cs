using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAppCore.DbModel;

public partial class VueworkdbTeachContext : DbContext
{
    public VueworkdbTeachContext(DbContextOptions<VueworkdbTeachContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CasbinRule> CasbinRules { get; set; }

    public virtual DbSet<ColorDiff> ColorDiffs { get; set; }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<FalldownDevice> FalldownDevices { get; set; }

    public virtual DbSet<FalldownLocation> FalldownLocations { get; set; }

    public virtual DbSet<LogLogin> LogLogins { get; set; }

    public virtual DbSet<LogOper> LogOpers { get; set; }

    public virtual DbSet<ProjectInfo> ProjectInfos { get; set; }

    public virtual DbSet<ResearchPaper> ResearchPapers { get; set; }

    public virtual DbSet<SysApi> SysApis { get; set; }

    public virtual DbSet<SysConfig> SysConfigs { get; set; }

    public virtual DbSet<SysDept> SysDepts { get; set; }

    public virtual DbSet<SysDictDatum> SysDictData { get; set; }

    public virtual DbSet<SysDictType> SysDictTypes { get; set; }

    public virtual DbSet<SysMenu> SysMenus { get; set; }

    public virtual DbSet<SysPost> SysPosts { get; set; }

    public virtual DbSet<SysRole> SysRoles { get; set; }

    public virtual DbSet<SysRoleDept> SysRoleDepts { get; set; }

    public virtual DbSet<SysRoleMenu> SysRoleMenus { get; set; }

    public virtual DbSet<SysUser> SysUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<CasbinRule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("casbin_rule")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => new { e.Ptype, e.V0, e.V1, e.V2, e.V3, e.V4, e.V5 }, "idx_casbin_rule").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ptype)
                .HasMaxLength(100)
                .HasColumnName("ptype");
            entity.Property(e => e.V0)
                .HasMaxLength(100)
                .HasColumnName("v0");
            entity.Property(e => e.V1)
                .HasMaxLength(100)
                .HasColumnName("v1");
            entity.Property(e => e.V2)
                .HasMaxLength(100)
                .HasColumnName("v2");
            entity.Property(e => e.V3)
                .HasMaxLength(100)
                .HasColumnName("v3");
            entity.Property(e => e.V4)
                .HasMaxLength(100)
                .HasColumnName("v4");
            entity.Property(e => e.V5)
                .HasMaxLength(100)
                .HasColumnName("v5");
        });

        modelBuilder.Entity<ColorDiff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("color_diff")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Id, "Id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Name, "ind_name");

            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__efmigrationshistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<FalldownDevice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("falldown_device")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.ContactPhones)
                .HasMaxLength(255)
                .HasComment("家属电话");
            entity.Property(e => e.CreateBy).HasMaxLength(128);
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.DeleteTime).HasColumnType("datetime");
            entity.Property(e => e.DeviceCode).HasMaxLength(128);
            entity.Property(e => e.Flag)
                .HasMaxLength(128)
                .HasComment("删除标识");
            entity.Property(e => e.Model)
                .HasMaxLength(128)
                .HasComment("型号");
            entity.Property(e => e.Phone)
                .HasMaxLength(100)
                .HasComment("电话");
            entity.Property(e => e.Remark).HasMaxLength(255);
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasComment("状态");
            entity.Property(e => e.UpdateBy).HasMaxLength(128);
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<FalldownLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("falldown_location")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.DeviceCode).HasMaxLength(128);
            entity.Property(e => e.Lat)
                .HasPrecision(12, 7)
                .HasComment("纬度");
            entity.Property(e => e.Lon)
                .HasPrecision(12, 7)
                .HasComment("经度");
            entity.Property(e => e.Remark).HasMaxLength(255);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasComment("状态");
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<LogLogin>(entity =>
        {
            entity.HasKey(e => e.InfoId).HasName("PRIMARY");

            entity
                .ToTable("log_logins")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.InfoId).HasColumnName("info_id");
            entity.Property(e => e.Browser)
                .HasMaxLength(255)
                .HasComment("浏览器")
                .HasColumnName("browser");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(128)
                .HasComment("创建人")
                .HasColumnName("create_by");
            entity.Property(e => e.CreateTime)
                .HasColumnType("datetime")
                .HasColumnName("create_time");
            entity.Property(e => e.DeleteTime)
                .HasColumnType("datetime")
                .HasColumnName("delete_time");
            entity.Property(e => e.Ipaddr)
                .HasMaxLength(255)
                .HasComment("ip地址")
                .HasColumnName("ipaddr");
            entity.Property(e => e.LoginLocation)
                .HasMaxLength(255)
                .HasComment("归属地")
                .HasColumnName("login_location");
            entity.Property(e => e.LoginTime)
                .HasComment("登录时间")
                .HasColumnType("timestamp")
                .HasColumnName("login_time");
            entity.Property(e => e.Msg)
                .HasMaxLength(255)
                .HasColumnName("msg");
            entity.Property(e => e.Os)
                .HasMaxLength(255)
                .HasComment("系统")
                .HasColumnName("os");
            entity.Property(e => e.Platform)
                .HasMaxLength(255)
                .HasComment("固件")
                .HasColumnName("platform");
            entity.Property(e => e.Remark)
                .HasMaxLength(255)
                .HasColumnName("remark");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasComment("状态")
                .HasColumnName("status");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(128)
                .HasComment("更新者")
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_time");
            entity.Property(e => e.Username)
                .HasMaxLength(128)
                .HasComment("用户名")
                .HasColumnName("username");
        });

        modelBuilder.Entity<LogOper>(entity =>
        {
            entity.HasKey(e => e.OperId).HasName("PRIMARY");

            entity
                .ToTable("log_opers")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.OperId).HasColumnName("oper_id");
            entity.Property(e => e.BusinessType)
                .HasComment("0其它 1新增 2修改 3删除")
                .HasColumnName("business_type");
            entity.Property(e => e.CreateTime)
                .HasColumnType("datetime")
                .HasColumnName("create_time");
            entity.Property(e => e.DeleteTime)
                .HasColumnType("datetime")
                .HasColumnName("delete_time");
            entity.Property(e => e.Method)
                .HasMaxLength(255)
                .HasComment("请求方法")
                .HasColumnName("method");
            entity.Property(e => e.OperIp)
                .HasMaxLength(255)
                .HasComment("操作IP")
                .HasColumnName("oper_ip");
            entity.Property(e => e.OperLocation)
                .HasMaxLength(255)
                .HasComment("操作地点")
                .HasColumnName("oper_location");
            entity.Property(e => e.OperName)
                .HasMaxLength(255)
                .HasComment("操作人员")
                .HasColumnName("oper_name");
            entity.Property(e => e.OperParam)
                .HasMaxLength(255)
                .HasComment("请求参数")
                .HasColumnName("oper_param");
            entity.Property(e => e.OperUrl)
                .HasMaxLength(255)
                .HasComment("操作url")
                .HasColumnName("oper_url");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasComment("0=正常,1=异常")
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(128)
                .HasComment("操作的模块")
                .HasColumnName("title");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_time");
        });

        modelBuilder.Entity<ProjectInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("project_info")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Id, "Id_UNIQUE").IsUnique();

            entity.Property(e => e.CreateBy).HasMaxLength(45);
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.DeleteTime).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Manager).HasMaxLength(45);
            entity.Property(e => e.Money).HasPrecision(10);
            entity.Property(e => e.PrjCode).HasMaxLength(100);
            entity.Property(e => e.PrjDesc).HasMaxLength(245);
            entity.Property(e => e.PrjName).HasMaxLength(45);
            entity.Property(e => e.PrjStatus).HasMaxLength(45);
            entity.Property(e => e.Remark).HasMaxLength(245);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateBy).HasMaxLength(45);
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<ResearchPaper>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("research_paper")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Id, "paperId_UNIQUE").IsUnique();

            entity.Property(e => e.Author).HasMaxLength(45);
            entity.Property(e => e.Code).HasMaxLength(45);
            entity.Property(e => e.CreateBy).HasMaxLength(45);
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.DeleteTime).HasColumnType("datetime");
            entity.Property(e => e.Journal).HasMaxLength(45);
            entity.Property(e => e.Level).HasMaxLength(45);
            entity.Property(e => e.Orgnization).HasMaxLength(45);
            entity.Property(e => e.Title).HasMaxLength(245);
            entity.Property(e => e.Type).HasMaxLength(45);
            entity.Property(e => e.UpdateBy).HasMaxLength(45);
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<SysApi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sys_apis")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApiGroup)
                .HasMaxLength(191)
                .HasComment("api组")
                .HasColumnName("api_group");
            entity.Property(e => e.CreateTime)
                .HasColumnType("datetime")
                .HasColumnName("create_time");
            entity.Property(e => e.DeleteTime)
                .HasColumnType("datetime")
                .HasColumnName("delete_time");
            entity.Property(e => e.Description)
                .HasMaxLength(191)
                .HasComment("api中文描述")
                .HasColumnName("description");
            entity.Property(e => e.Method)
                .HasMaxLength(191)
                .HasComment("方法")
                .HasColumnName("method");
            entity.Property(e => e.Path)
                .HasMaxLength(191)
                .HasComment("api路径")
                .HasColumnName("path");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_time");
        });

        modelBuilder.Entity<SysConfig>(entity =>
        {
            entity.HasKey(e => e.ConfigId).HasName("PRIMARY");

            entity
                .ToTable("sys_configs")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.ConfigId)
                .HasComment("主键编码")
                .HasColumnName("config_id");
            entity.Property(e => e.ConfigKey)
                .HasMaxLength(128)
                .HasComment("ConfigKey")
                .HasColumnName("config_key");
            entity.Property(e => e.ConfigName)
                .HasMaxLength(128)
                .HasComment("ConfigName")
                .HasColumnName("config_name");
            entity.Property(e => e.ConfigType)
                .HasMaxLength(64)
                .HasComment("是否系统内置0，1")
                .HasColumnName("config_type");
            entity.Property(e => e.ConfigValue)
                .HasMaxLength(255)
                .HasComment("ConfigValue")
                .HasColumnName("config_value");
            entity.Property(e => e.CreateTime)
                .HasColumnType("datetime")
                .HasColumnName("create_time");
            entity.Property(e => e.DeleteTime)
                .HasColumnType("datetime")
                .HasColumnName("delete_time");
            entity.Property(e => e.IsFrontend)
                .HasMaxLength(64)
                .HasComment("是否前台")
                .HasColumnName("is_frontend");
            entity.Property(e => e.Remark)
                .HasMaxLength(128)
                .HasComment("Remark")
                .HasColumnName("remark");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_time");
        });

        modelBuilder.Entity<SysDept>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("PRIMARY");

            entity
                .ToTable("sys_depts")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.DeptId).HasColumnName("dept_id");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(64)
                .HasComment("创建人")
                .HasColumnName("create_by");
            entity.Property(e => e.CreateTime)
                .HasColumnType("datetime")
                .HasColumnName("create_time");
            entity.Property(e => e.DeleteTime)
                .HasColumnType("datetime")
                .HasColumnName("delete_time");
            entity.Property(e => e.DeptName)
                .HasMaxLength(128)
                .HasComment("部门名称")
                .HasColumnName("dept_name");
            entity.Property(e => e.DeptPath)
                .HasMaxLength(255)
                .HasComment("部门路径")
                .HasColumnName("dept_path");
            entity.Property(e => e.Email)
                .HasMaxLength(64)
                .HasComment("邮箱")
                .HasColumnName("email");
            entity.Property(e => e.Leader)
                .HasMaxLength(64)
                .HasComment("负责人")
                .HasColumnName("leader");
            entity.Property(e => e.ParentId)
                .HasComment("上级部门")
                .HasColumnName("parent_id");
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .HasComment("手机")
                .HasColumnName("phone");
            entity.Property(e => e.Sort)
                .HasComment("排序")
                .HasColumnName("sort");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasComment("状态")
                .HasColumnName("status");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(64)
                .HasComment("修改人")
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_time");
        });

        modelBuilder.Entity<SysDictDatum>(entity =>
        {
            entity.HasKey(e => e.DictCode).HasName("PRIMARY");

            entity
                .ToTable("sys_dict_data")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.DictCode).HasColumnName("dict_code");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(191)
                .HasColumnName("create_by");
            entity.Property(e => e.CreateTime)
                .HasColumnType("datetime")
                .HasColumnName("create_time");
            entity.Property(e => e.CssClass)
                .HasMaxLength(128)
                .HasComment("CssClass")
                .HasColumnName("css_class");
            entity.Property(e => e.DeleteTime)
                .HasColumnType("datetime")
                .HasColumnName("delete_time");
            entity.Property(e => e.DictLabel)
                .HasMaxLength(64)
                .HasComment("标签")
                .HasColumnName("dict_label");
            entity.Property(e => e.DictSort)
                .HasComment("排序")
                .HasColumnName("dict_sort");
            entity.Property(e => e.DictType)
                .HasMaxLength(64)
                .HasComment("字典类型")
                .HasColumnName("dict_type");
            entity.Property(e => e.DictValue)
                .HasMaxLength(64)
                .HasComment("值")
                .HasColumnName("dict_value");
            entity.Property(e => e.IsDefault)
                .HasMaxLength(8)
                .HasComment("IsDefault")
                .HasColumnName("is_default");
            entity.Property(e => e.ListClass)
                .HasMaxLength(128)
                .HasComment("ListClass")
                .HasColumnName("list_class");
            entity.Property(e => e.Remark)
                .HasMaxLength(256)
                .HasComment("备注")
                .HasColumnName("remark");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasComment("状态（0正常 1停用）")
                .HasColumnName("status");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(191)
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_time");
        });

        modelBuilder.Entity<SysDictType>(entity =>
        {
            entity.HasKey(e => e.DictId).HasName("PRIMARY");

            entity
                .ToTable("sys_dict_types")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.DictId).HasColumnName("dict_id");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(191)
                .HasColumnName("create_by");
            entity.Property(e => e.CreateTime)
                .HasColumnType("datetime")
                .HasColumnName("create_time");
            entity.Property(e => e.DeleteTime)
                .HasColumnType("datetime")
                .HasColumnName("delete_time");
            entity.Property(e => e.DictName)
                .HasMaxLength(64)
                .HasComment("名称")
                .HasColumnName("dict_name");
            entity.Property(e => e.DictType)
                .HasMaxLength(64)
                .HasComment("类型")
                .HasColumnName("dict_type");
            entity.Property(e => e.Remark)
                .HasMaxLength(256)
                .HasComment("备注")
                .HasColumnName("remark");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasComment("状态")
                .HasColumnName("status");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(191)
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_time");
        });

        modelBuilder.Entity<SysMenu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("PRIMARY");

            entity
                .ToTable("sys_menus")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.MenuId).HasColumnName("menu_id");
            entity.Property(e => e.Component)
                .HasMaxLength(255)
                .HasColumnName("component");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(128)
                .HasColumnName("create_by");
            entity.Property(e => e.CreateTime)
                .HasColumnType("datetime")
                .HasColumnName("create_time");
            entity.Property(e => e.DeleteTime)
                .HasColumnType("datetime")
                .HasColumnName("delete_time");
            entity.Property(e => e.Icon)
                .HasMaxLength(128)
                .HasColumnName("icon");
            entity.Property(e => e.IsAffix)
                .HasMaxLength(1)
                .HasComment("是否登录后固定显示在页面顶部sheet")
                .HasColumnName("is_affix");
            entity.Property(e => e.IsFrame)
                .HasMaxLength(1)
                .HasColumnName("is_frame");
            entity.Property(e => e.IsHide)
                .HasMaxLength(1)
                .HasColumnName("is_hide");
            entity.Property(e => e.IsKeepAlive)
                .HasMaxLength(1)
                .HasColumnName("is_keep_alive");
            entity.Property(e => e.IsLink)
                .HasMaxLength(256)
                .HasColumnName("is_link");
            entity.Property(e => e.MenuName)
                .HasMaxLength(128)
                .HasColumnName("menu_name");
            entity.Property(e => e.MenuType)
                .HasMaxLength(1)
                .HasColumnName("menu_type");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.Path)
                .HasMaxLength(128)
                .HasColumnName("path");
            entity.Property(e => e.Permission)
                .HasMaxLength(32)
                .HasColumnName("permission");
            entity.Property(e => e.Remark)
                .HasMaxLength(191)
                .HasColumnName("remark");
            entity.Property(e => e.Sort).HasColumnName("sort");
            entity.Property(e => e.Status)
                .HasMaxLength(191)
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(64)
                .HasColumnName("title");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(128)
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_time");
        });

        modelBuilder.Entity<SysPost>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PRIMARY");

            entity
                .ToTable("sys_posts")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(128)
                .HasColumnName("create_by");
            entity.Property(e => e.CreateTime)
                .HasColumnType("datetime")
                .HasColumnName("create_time");
            entity.Property(e => e.DeleteTime)
                .HasColumnType("datetime")
                .HasColumnName("delete_time");
            entity.Property(e => e.PostCode)
                .HasMaxLength(128)
                .HasComment("岗位代码")
                .HasColumnName("post_code");
            entity.Property(e => e.PostName)
                .HasMaxLength(128)
                .HasComment("岗位名称")
                .HasColumnName("post_name");
            entity.Property(e => e.Remark)
                .HasMaxLength(255)
                .HasComment("描述")
                .HasColumnName("remark");
            entity.Property(e => e.Sort)
                .HasComment("岗位排序")
                .HasColumnName("sort");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasComment("状态")
                .HasColumnName("status");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(128)
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_time");
        });

        modelBuilder.Entity<SysRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity
                .ToTable("sys_roles")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(128)
                .HasColumnName("create_by");
            entity.Property(e => e.CreateTime)
                .HasColumnType("datetime")
                .HasColumnName("create_time");
            entity.Property(e => e.DataScope)
                .HasMaxLength(1)
                .HasComment("数据范围（1：全部数据权限 2：自定数据权限 3：本部门数据权限 4：本部门及以下数据权限）")
                .HasColumnName("data_scope");
            entity.Property(e => e.DeleteTime)
                .HasColumnType("datetime")
                .HasColumnName("delete_time");
            entity.Property(e => e.Flag)
                .HasMaxLength(128)
                .HasComment("删除标识")
                .HasColumnName("flag");
            entity.Property(e => e.Remark)
                .HasMaxLength(255)
                .HasColumnName("remark");
            entity.Property(e => e.RoleKey)
                .HasMaxLength(128)
                .HasComment("角色代码")
                .HasColumnName("role_key");
            entity.Property(e => e.RoleName)
                .HasMaxLength(128)
                .HasComment("角色名称")
                .HasColumnName("role_name");
            entity.Property(e => e.RoleSort)
                .HasComment("角色排序")
                .HasColumnName("role_sort");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasComment("状态")
                .HasColumnName("status");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(128)
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_time");
        });

        modelBuilder.Entity<SysRoleDept>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sys_role_depts")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DeptId).HasColumnName("dept_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
        });

        modelBuilder.Entity<SysRoleMenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sys_role_menus")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MenuId).HasColumnName("menu_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(128)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<SysUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity
                .ToTable("sys_users")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .HasColumnName("avatar")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(128)
                .HasColumnName("create_by")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.CreateTime)
                .HasColumnType("datetime")
                .HasColumnName("create_time");
            entity.Property(e => e.DeleteTime)
                .HasColumnType("datetime")
                .HasColumnName("delete_time");
            entity.Property(e => e.DeptId).HasColumnName("dept_id");
            entity.Property(e => e.Email)
                .HasMaxLength(128)
                .HasColumnName("email")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.NickName)
                .HasMaxLength(128)
                .HasColumnName("nick_name")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Password)
                .HasMaxLength(128)
                .HasColumnName("password")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .HasColumnName("phone")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.PostIds)
                .HasMaxLength(255)
                .HasComment("多岗位")
                .HasColumnName("post_ids")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Remark)
                .HasMaxLength(255)
                .HasColumnName("remark")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleIds)
                .HasMaxLength(255)
                .HasComment("多角色")
                .HasColumnName("role_ids")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Salt)
                .HasMaxLength(255)
                .HasColumnName("salt")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Sex)
                .HasMaxLength(255)
                .HasColumnName("sex")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasColumnName("status")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(128)
                .HasColumnName("update_by")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_time");
            entity.Property(e => e.Username)
                .HasMaxLength(64)
                .HasColumnName("username")
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
