using System;
using System.Collections.Generic;

namespace SlmsAppDataAccess.Models;

public partial class CourseFaq
{
    public int CourseFaqsId { get; set; }

    public int CreateCourseId { get; set; }

    public string FaqQuestion { get; set; }

    public string FaqAnswer { get; set; }

    public DateTime FaqCreatedDate { get; set; }

    public DateTime? FaqUpdatedDate { get; set; }

    public virtual CreateCourse CreateCourse { get; set; }
}
