using System;
using System.Collections.Generic;

namespace SlmsAppDataAccess.Models;

public partial class SubCategory
{
    public int SubCategoriesId { get; set; }

    public string Name { get; set; }

    public int CategoryId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Category Category { get; set; }

    public virtual ICollection<CreateCourse> CreateCourses { get; set; } = new List<CreateCourse>();

    public virtual ICollection<UserInterest> UserInterests { get; set; } = new List<UserInterest>();
}
