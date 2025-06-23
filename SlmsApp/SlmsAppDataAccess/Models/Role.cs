using System;
using System.Collections.Generic;

namespace SlmsAppDataAccess.Models;

public partial class Role
{
    public int RolesId { get; set; }

    public string Name { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<AspNetRoleMenuItem> AspNetRoleMenuItems { get; set; } = new List<AspNetRoleMenuItem>();

    public virtual ICollection<Myprofile> Myprofiles { get; set; } = new List<Myprofile>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
