using System;
using System.Collections.Generic;

namespace WebAppCore.DbModel;

public partial class RadarPreprocessDatum
{
    public long Id { get; set; }

    /// <summary>
    /// 原始数据id
    /// </summary>
    public long? RawId { get; set; }

    /// <summary>
    /// 文件名
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 文件路径
    /// </summary>
    public string? Path { get; set; }

    /// <summary>
    /// 类型
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// 文件大小
    /// </summary>
    public string? Size { get; set; }

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
