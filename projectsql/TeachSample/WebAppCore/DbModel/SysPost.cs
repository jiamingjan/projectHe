using System;
using System.Collections.Generic;

namespace WebAppCore.DbModel;

public partial class SysPost
{
    public long PostId { get; set; }

    /// <summary>
    /// 岗位名称
    /// </summary>
    public string? PostName { get; set; }

    /// <summary>
    /// 岗位代码
    /// </summary>
    public string? PostCode { get; set; }

    /// <summary>
    /// 岗位排序
    /// </summary>
    public int? Sort { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public string? Status { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string? Remark { get; set; }

    public string? CreateBy { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? UpdateTime { get; set; }

    public DateTime? DeleteTime { get; set; }
}
