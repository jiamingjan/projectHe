using System;
using System.Collections.Generic;

namespace WebAppCore.DbModel;

public partial class SysRoleMenu
{
    public long Id { get; set; }

    public int? RoleId { get; set; }

    public int? MenuId { get; set; }

    public string? RoleName { get; set; }
}
