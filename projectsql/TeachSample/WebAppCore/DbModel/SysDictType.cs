using System;
using System.Collections.Generic;

namespace WebAppCore.DbModel;

public partial class SysDictType
{
    public long DictId { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string? DictName { get; set; }

    /// <summary>
    /// 类型
    /// </summary>
    public string? DictType { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public string? Status { get; set; }

    public string? CreateBy { get; set; }

    public string? UpdateBy { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string? Remark { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? UpdateTime { get; set; }

    public DateTime? DeleteTime { get; set; }
}
