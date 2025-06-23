using System;
using System.Collections.Generic;

namespace SlmsAppDataAccess.Models;

public partial class CourseEnrollment
{
    public int EnrollmentId { get; set; }

    public int UserId { get; set; }

    public int CreateCourseId { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public bool IsCompleted { get; set; }

    public virtual CreateCourse CreateCourse { get; set; }

    public virtual User User { get; set; }
}
