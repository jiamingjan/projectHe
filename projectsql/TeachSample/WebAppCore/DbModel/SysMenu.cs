using System;
using System.Collections.Generic;

namespace WebAppCore.DbModel;

public partial class SysMenu
{
    public long MenuId { get; set; }

    public string? MenuName { get; set; }

    public string? Title { get; set; }

    public int? ParentId { get; set; }

    public int? Sort { get; set; }

    public string? Icon { get; set; }

    public string? Path { get; set; }

    public string? Component { get; set; }

    public string? IsFrame { get; set; }

    public string? IsLink { get; set; }

    public string? MenuType { get; set; }

    public string? IsHide { get; set; }

    public string? IsKeepAlive { get; set; }

    /// <summary>
    /// 是否登录后固定显示在页面顶部sheet
    /// </summary>
    public string? IsAffix { get; set; }

    public string? Permission { get; set; }

    public string? Status { get; set; }

    public string? CreateBy { get; set; }

    public string? UpdateBy { get; set; }

    public string? Remark { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? UpdateTime { get; set; }

    public DateTime? DeleteTime { get; set; }
}
