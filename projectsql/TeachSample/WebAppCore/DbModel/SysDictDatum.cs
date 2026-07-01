using System;
using System.Collections.Generic;

namespace WebAppCore.DbModel;

public partial class SysDictDatum
{
    public long DictCode { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int? DictSort { get; set; }

    /// <summary>
    /// 标签
    /// </summary>
    public string? DictLabel { get; set; }

    /// <summary>
    /// 值
    /// </summary>
    public string? DictValue { get; set; }

    /// <summary>
    /// 字典类型
    /// </summary>
    public string? DictType { get; set; }

    /// <summary>
    /// 状态（0正常 1停用）
    /// </summary>
    public string? Status { get; set; }

    /// <summary>
    /// CssClass
    /// </summary>
    public string? CssClass { get; set; }

    /// <summary>
    /// ListClass
    /// </summary>
    public string? ListClass { get; set; }

    /// <summary>
    /// IsDefault
    /// </summary>
    public string? IsDefault { get; set; }

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
