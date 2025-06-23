using System;
using System.Collections.Generic;

namespace SlmsAppDataAccess.Models;

public partial class UserInterest
{
    public int UserId { get; set; }

    public int CategoryId { get; set; }

    public int SubCategoryId { get; set; }

    public virtual Category Category { get; set; }

    public virtual SubCategory SubCategory { get; set; }

    public virtual User User { get; set; }
}
