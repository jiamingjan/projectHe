using System;
using System.Collections.Generic;

namespace WebAppCore.DbModel;

public partial class SysApi
{
    public long Id { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? UpdateTime { get; set; }

    public DateTime? DeleteTime { get; set; }

    /// <summary>
    /// api路径
    /// </summary>
    public string? Path { get; set; }

    /// <summary>
    /// api中文描述
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// api组
    /// </summary>
    public string? ApiGroup { get; set; }

    /// <summary>
    /// 方法
    /// </summary>
    public string? Method { get; set; }
}
