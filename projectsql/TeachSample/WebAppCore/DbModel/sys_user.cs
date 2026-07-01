using System;
using System.Collections.Generic;

namespace WebAppCore.DbModel;

public partial class sys_user
{
    public long user_id { get; set; }

    public string? nick_name { get; set; }

    public string? phone { get; set; }

    public int? role_id { get; set; }

    public string? salt { get; set; }

    public string? avatar { get; set; }

    public string? sex { get; set; }

    public string? email { get; set; }

    public int? dept_id { get; set; }

    public int? post_id { get; set; }

    public string? create_by { get; set; }

    public string? update_by { get; set; }

    public string? remark { get; set; }

    public string? status { get; set; }

    public DateTime? create_time { get; set; }

    public DateTime? update_time { get; set; }

    public DateTime? delete_time { get; set; }

    public string? username { get; set; }

    public string? password { get; set; }

    /// <summary>
    /// 多角色
    /// </summary>
    public string? role_ids { get; set; }

    /// <summary>
    /// 多岗位
    /// </summary>
    public string? post_ids { get; set; }
}
