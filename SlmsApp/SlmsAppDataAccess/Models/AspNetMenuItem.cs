using System;
using System.Collections.Generic;

namespace SlmsAppDataAccess.Models;

public partial class AspNetMenuItem
{
    public int MenuId { get; set; }

    public string MenuItemName { get; set; }

    public int ModuleId { get; set; }

    public string Icon { get; set; }

    public string Url { get; set; }

    public virtual ICollection<AspNetRoleMenuItem> AspNetRoleMenuItems { get; set; } = new List<AspNetRoleMenuItem>();

    public virtual AspNetModule Module { get; set; }
}
