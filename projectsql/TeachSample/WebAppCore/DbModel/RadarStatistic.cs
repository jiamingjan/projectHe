using System;
using System.Collections.Generic;

namespace WebAppCore.DbModel;

public partial class RadarStatistic
{
    public long Id { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// 类型
    /// </summary>
    public string? Oprtype { get; set; }

    /// <summary>
    /// 数量
    /// </summary>
    public int? Num { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string? Remark { get; set; }

    /// <summary>
    /// 统计日期
    /// </summary>
    public DateOnly? Statdate { get; set; }

    public DateTime? Oprtime { get; set; }
}
