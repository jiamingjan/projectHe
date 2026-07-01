using System;
using System.Collections.Generic;

namespace WebAppCore.DbModel;

public partial class SysDept
{
    public long DeptId { get; set; }

    /// <summary>
    /// 上级部门
    /// </summary>
    public int? ParentId { get; set; }

    /// <summary>
    /// 部门路径
    /// </summary>
    public string? DeptPath { get; set; }

    /// <summary>
    /// 部门名称
    /// </summary>
    public string? DeptName { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int? Sort { get; set; }

    /// <summary>
    /// 负责人
    /// </summary>
    public string? Leader { get; set; }

    /// <summary>
    /// 手机
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public string? Status { get; set; }

    /// <summary>
    /// 创建人
    /// </summary>
    public string? CreateBy { get; set; }

    /// <summary>
    /// 修改人
    /// </summary>
    public string? UpdateBy { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? UpdateTime { get; set; }

    public DateTime? DeleteTime { get; set; }
}
