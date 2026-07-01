using System;
using System.Collections.Generic;

namespace WebAppCore.DbModel;

public partial class stockrecom
{
    public long Id { get; set; }

    /// <summary>
    /// 股票代码
    /// </summary>
    public string? StockCode { get; set; }

    /// <summary>
    /// 股票名称
    /// </summary>
    public string? StockName { get; set; }

    /// <summary>
    /// 所属行业
    /// </summary>
    public string? StockField { get; set; }

    /// <summary>
    /// 总分
    /// </summary>
    public int? StockScore { get; set; }

    public DateOnly? StockDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateTime { get; set; }
}
