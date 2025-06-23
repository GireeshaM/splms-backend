using System;
using System.Collections.Generic;

namespace SlmsAppDataAccess.Models;

public partial class Section
{
    public int SectionId { get; set; }

    public string SectionName { get; set; }

    public string SectionObjective { get; set; }

    public DateTime SectionCreatedDate { get; set; }

    public DateTime? SectionUpdatedDate { get; set; }

    public int CreatedByUserId { get; set; }

    public bool IsActive { get; set; }

    public int? CreateCourseId { get; set; }

    public virtual ICollection<AddVideo> AddVideos { get; set; } = new List<AddVideo>();

    public virtual ICollection<CourseSectionsOrder> CourseSectionsOrders { get; set; } = new List<CourseSectionsOrder>();

    public virtual CreateCourse CreateCourse { get; set; }

    public virtual ICollection<CreateQuiz> CreateQuizzes { get; set; } = new List<CreateQuiz>();

    public virtual User CreatedByUser { get; set; }

    public virtual ICollection<LessonsOrder> LessonsOrders { get; set; } = new List<LessonsOrder>();

    public virtual ICollection<Video> Videos { get; set; } = new List<Video>();
}
