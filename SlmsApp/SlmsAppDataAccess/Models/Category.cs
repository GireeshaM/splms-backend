using System;
using System.Collections.Generic;

namespace SlmsAppDataAccess.Models;

public partial class Category
{
    public int CategoriesId { get; set; }

    public string Name { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<CreateCourse> CreateCourses { get; set; } = new List<CreateCourse>();

    public virtual ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();

    public virtual ICollection<UserInterest> UserInterests { get; set; } = new List<UserInterest>();
}
