using System;
using System.Collections.Generic;

namespace SlmsAppDataAccess.Models;

public partial class UserWishlistAndVisited
{
    public int UserInteractionId { get; set; }

    public int UserId { get; set; }

    public int CreateCourseId { get; set; }

    public bool CourseWishlist { get; set; }

    public DateTime CourseWishlistDate { get; set; }

    public bool CourseVisited { get; set; }

    public DateTime CourseVisitedDate { get; set; }

    public virtual CreateCourse CreateCourse { get; set; }

    public virtual User User { get; set; }
}
