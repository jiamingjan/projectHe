using System;
using System.Collections.Generic;

namespace WebAppCore.DbModel;

public partial class LogOper
{
    public long OperId { get; set; }

    /// <summary>
    /// 操作的模块
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// 0其它 1新增 2修改 3删除
    /// </summary>
    public int? BusinessType { get; set; }

    /// <summary>
    /// 请求方法
    /// </summary>
    public string? Method { get; set; }

    /// <summary>
    /// 操作人员
    /// </summary>
    public string? OperName { get; set; }

    /// <summary>
    /// 操作url
    /// </summary>
    public string? OperUrl { get; set; }

    /// <summary>
    /// 操作IP
    /// </summary>
    public string? OperIp { get; set; }

    /// <summary>
    /// 操作地点
    /// </summary>
    public string? OperLocation { get; set; }

    /// <summary>
    /// 请求参数
    /// </summary>
    public string? OperParam { get; set; }

    /// <summary>
    /// 0=正常,1=异常
    /// </summary>
    public string? Status { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? UpdateTime { get; set; }

    public DateTime? DeleteTime { get; set; }
}
