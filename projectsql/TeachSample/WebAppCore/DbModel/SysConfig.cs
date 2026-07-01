using System;
using System.Collections.Generic;

namespace WebAppCore.DbModel;

public partial class SysConfig
{
    /// <summary>
    /// 主键编码
    /// </summary>
    public long ConfigId { get; set; }

    /// <summary>
    /// ConfigName
    /// </summary>
    public string? ConfigName { get; set; }

    /// <summary>
    /// ConfigKey
    /// </summary>
    public string? ConfigKey { get; set; }

    /// <summary>
    /// ConfigValue
    /// </summary>
    public string? ConfigValue { get; set; }

    /// <summary>
    /// 是否系统内置0，1
    /// </summary>
    public string? ConfigType { get; set; }

    /// <summary>
    /// 是否前台
    /// </summary>
    public string? IsFrontend { get; set; }

    /// <summary>
    /// Remark
    /// </summary>
    public string? Remark { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? UpdateTime { get; set; }

    public DateTime? DeleteTime { get; set; }
}
