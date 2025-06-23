using System;
using System.Collections.Generic;

namespace SlmsAppDataAccess.Models;

public partial class CourseSectionsOrder
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int CreateCourseId { get; set; }

    public int SectionId { get; set; }

    public int SectionOrder { get; set; }

    public virtual CreateCourse CreateCourse { get; set; }

    public virtual Section Section { get; set; }

    public virtual User User { get; set; }
}
