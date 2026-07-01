using System;
using System.Collections.Generic;

namespace WebAppCore.DbModel;

public partial class LogLogin
{
    public long InfoId { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public string? Status { get; set; }

    /// <summary>
    /// ip地址
    /// </summary>
    public string? Ipaddr { get; set; }

    /// <summary>
    /// 归属地
    /// </summary>
    public string? LoginLocation { get; set; }

    /// <summary>
    /// 浏览器
    /// </summary>
    public string? Browser { get; set; }

    /// <summary>
    /// 系统
    /// </summary>
    public string? Os { get; set; }

    /// <summary>
    /// 固件
    /// </summary>
    public string? Platform { get; set; }

    /// <summary>
    /// 登录时间
    /// </summary>
    public DateTime? LoginTime { get; set; }

    /// <summary>
    /// 创建人
    /// </summary>
    public string? CreateBy { get; set; }

    /// <summary>
    /// 更新者
    /// </summary>
    public string? UpdateBy { get; set; }

    public string? Remark { get; set; }

    public string? Msg { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? UpdateTime { get; set; }

    public DateTime? DeleteTime { get; set; }
}
