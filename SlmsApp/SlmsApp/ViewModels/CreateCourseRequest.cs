namespace SlmsApp.ViewModels
{
    public class CreateCourseRequest
    {
        public int UserId { get; set; }
        public int? CreateCourseId { get; set; }
        // Ensure these are nullable (int?) to allow null values
        public int? CategoryId { get; set; } // Nullable type
        public string? CategoryName { get; set; } // Fallback if ID not given

        public int? SubCategoryId { get; set; } // Nullable type
        public string? SubCategoryName { get; set; } // Fallback if ID not given

        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public string Level { get; set; }
        public string Duration { get; set; }
        public string CourseOverview { get; set; }
        public string PreRequirements { get; set; }
        public string SkillsYouGain { get; set; }
        public string WhatYouWillLearn { get; set; }

        // File properties should be IFormFile, not string
        public IFormFile? Thumbnail { get; set; }
        public IFormFile? DemoVideo { get; set; }
        public bool CourseStatus { get; set; }
        public bool InProgress { get; set; }
        public bool AdminReview { get; set; }
        public bool IsUploaded { get; set; }
    }
}