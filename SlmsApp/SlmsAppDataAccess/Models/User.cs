using System;
using System.Collections.Generic;

namespace SlmsAppDataAccess.Models;

public partial class User
{
    public int Id { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get; set; }

    public string PhoneNumber { get; set; }

    public DateTime CreatedAt { get; set; }

    public int RolesId { get; set; }

    public string ResetCode { get; set; }

    public DateTime? ResetCodeExpiration { get; set; }

    public bool UserStatus { get; set; }

    public virtual ICollection<AddVideo> AddVideos { get; set; } = new List<AddVideo>();

    public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; } = new List<CourseEnrollment>();

    public virtual ICollection<CourseSectionsOrder> CourseSectionsOrders { get; set; } = new List<CourseSectionsOrder>();

    public virtual ICollection<CreateCourse> CreateCourses { get; set; } = new List<CreateCourse>();

    public virtual ICollection<CreateQuiz> CreateQuizzes { get; set; } = new List<CreateQuiz>();

    public virtual ICollection<LessonsOrder> LessonsOrders { get; set; } = new List<LessonsOrder>();

    public virtual Myprofile Myprofile { get; set; }

    public virtual Role Roles { get; set; }

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    public virtual ICollection<UserInterest> UserInterests { get; set; } = new List<UserInterest>();

    public virtual ICollection<UserWishlistAndVisited> UserWishlistAndVisiteds { get; set; } = new List<UserWishlistAndVisited>();

    public virtual ICollection<Video> Videos { get; set; } = new List<Video>();
}
