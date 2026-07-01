using System;
using System.Collections.Generic;

namespace WebAppCore.DbModel;

public partial class FalldownLocation
{
    public long Id { get; set; }

    public string? DeviceCode { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public string? Status { get; set; }

    /// <summary>
    /// 经度
    /// </summary>
    public decimal? Lon { get; set; }

    /// <summary>
    /// 纬度
    /// </summary>
    public decimal? Lat { get; set; }

    public string? Remark { get; set; }

    public DateTime? UpdateTime { get; set; }
}
