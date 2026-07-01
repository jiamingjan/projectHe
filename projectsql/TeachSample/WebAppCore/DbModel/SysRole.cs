using System;
using System.Collections.Generic;

namespace WebAppCore.DbModel;

public partial class SysRole
{
    public long RoleId { get; set; }

    /// <summary>
    /// 角色名称
    /// </summary>
    public string? RoleName { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public string? Status { get; set; }

    /// <summary>
    /// 角色代码
    /// </summary>
    public string? RoleKey { get; set; }

    /// <summary>
    /// 数据范围（1：全部数据权限 2：自定数据权限 3：本部门数据权限 4：本部门及以下数据权限）
    /// </summary>
    public string? DataScope { get; set; }

    /// <summary>
    /// 角色排序
    /// </summary>
    public int? RoleSort { get; set; }

    /// <summary>
    /// 删除标识
    /// </summary>
    public string? Flag { get; set; }

    public string? CreateBy { get; set; }

    public string? UpdateBy { get; set; }

    public string? Remark { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? UpdateTime { get; set; }

    public DateTime? DeleteTime { get; set; }
}
