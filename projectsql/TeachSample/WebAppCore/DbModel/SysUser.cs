using System;
using System.Collections.Generic;

namespace WebAppCore.DbModel;

public partial class SysUser
{
    public long UserId { get; set; }

    public string? NickName { get; set; }

    public string? Phone { get; set; }

    public int? RoleId { get; set; }

    public string? Salt { get; set; }

    public string? Avatar { get; set; }

    public string? Sex { get; set; }

    public string? Email { get; set; }

    public int? DeptId { get; set; }

    public int? PostId { get; set; }

    public string? CreateBy { get; set; }

    public string? UpdateBy { get; set; }

    public string? Remark { get; set; }

    public string? Status { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? UpdateTime { get; set; }

    public DateTime? DeleteTime { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    /// <summary>
    /// 多角色
    /// </summary>
    public string? RoleIds { get; set; }

    /// <summary>
    /// 多岗位
    /// </summary>
    public string? PostIds { get; set; }
}
