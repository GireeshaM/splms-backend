using System;
using System.Collections.Generic;

namespace SlmsAppDataAccess.Models;

public partial class AspNetModule
{
    public int ModuleId { get; set; }

    public string ModuleName { get; set; }

    public string Icon { get; set; }

    public string Url { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<AspNetMenuItem> AspNetMenuItems { get; set; } = new List<AspNetMenuItem>();
}
