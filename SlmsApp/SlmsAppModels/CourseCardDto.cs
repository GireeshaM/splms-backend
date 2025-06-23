using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppModels
{
    public class CourseCardDto
    {
        // From CreateCourse
        public int CreateCourseId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public string Level { get; set; }
        public string PreRequirements { get; set; }
        public string SkillsYouGain { get; set; }
        public string WhatYouWillLearn { get; set; }
        public string CourseOverview { get; set; }
        public byte[] Thumbnail { get; set; }
        public DateTime CourseCreatedDate { get; set; }
        public DateTime CourseUpdatedDate { get; set; }
        public bool CourseStatus { get; set; }
        public bool InProgress { get; set; }
        public bool AdminReview { get; set; }
        public bool IsUploaded { get; set; }

        // From Users
        public string FullName { get; set; }

        // From myprofiles
        public string PhotoPath { get; set; }

        // From Videos
        public decimal? VideoDuration { get; set; }

        // From CourseEnrollments
        public int? EnrollmentId { get; set; }

        // From UserWishlistAndVisited
        public int? UserInteractionId { get; set; }

        // Computed fields (recommended)
        public bool IsEnrolled { get; set; }
        public bool IsWishlisted { get; set; }
    }

}
