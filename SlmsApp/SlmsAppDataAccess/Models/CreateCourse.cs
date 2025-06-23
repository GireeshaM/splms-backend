using System;
using System.Collections.Generic;

namespace SlmsAppDataAccess.Models;

public partial class CreateCourse
{
    public int CreateCourseId { get; set; }

    public int UserId { get; set; }

    public int CategoryId { get; set; }

    public int SubCategoryId { get; set; }

    public string CourseTitle { get; set; }

    public string CourseDescription { get; set; }

    public string Level { get; set; }

    public string Duration { get; set; }

    public string PreRequirements { get; set; }

    public string SkillsYouGain { get; set; }

    public string WhatYouWillLearn { get; set; }

    public string CourseOverview { get; set; }

    public byte[] Thumbnail { get; set; }

    public byte[] DemoVideo { get; set; }

    public DateTime CourseCreatedDate { get; set; }

    public DateTime CourseUpdatedDate { get; set; }

    public bool CourseStatus { get; set; }

    public bool InProgress { get; set; }

    public bool AdminReview { get; set; }

    public bool IsUploaded { get; set; }

    public virtual Category Category { get; set; }

    public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; } = new List<CourseEnrollment>();

    public virtual ICollection<CourseFaq> CourseFaqs { get; set; } = new List<CourseFaq>();

    public virtual ICollection<CourseSectionsOrder> CourseSectionsOrders { get; set; } = new List<CourseSectionsOrder>();

    public virtual ICollection<LessonsOrder> LessonsOrders { get; set; } = new List<LessonsOrder>();

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    public virtual SubCategory SubCategory { get; set; }

    public virtual User User { get; set; }

    public virtual ICollection<UserWishlistAndVisited> UserWishlistAndVisiteds { get; set; } = new List<UserWishlistAndVisited>();
}
