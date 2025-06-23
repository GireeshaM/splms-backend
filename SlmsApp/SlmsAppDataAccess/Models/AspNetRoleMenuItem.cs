using System;
using System.Collections.Generic;

namespace SlmsAppDataAccess.Models;

public partial class AspNetRoleMenuItem
{
    public int RoleMenuId { get; set; }

    public int RoleId { get; set; }

    public int MenuId { get; set; }

    public virtual AspNetMenuItem Menu { get; set; }

    public virtual Role Role { get; set; }
}
