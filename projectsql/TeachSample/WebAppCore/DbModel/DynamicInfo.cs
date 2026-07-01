using System;
using System.Collections.Generic;

namespace WebAppCore.DbModel;

public partial class DynamicInfo
{
    public long Id { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    public string? Label { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string? Remark { get; set; }

    public DateTime? Oprtime { get; set; }
}
