using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppModels
{
    public class CreateCourseDto
    {
        public int? CreateCourseId { get; set; } 
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public string Level { get; set; }
        public string Duration { get; set; }
        public string[] PreRequirements { get; set; }
        public string[] SkillsYouGain { get; set; }
        public string[] WhatYouWillLearn { get; set; }
        public string CourseOverview { get; set; }
        public byte[] Thumbnail { get; set; }
        public byte[] DemoVideo { get; set; }
        public string CategoryName { get; set; }       
        public string SubCategoryName { get; set; }
        public bool InProgress { get; set; }
        public bool CourseStatus { get; set; }
        public bool AdminReview { get; set; }
        public bool IsUploaded { get; set; }
        public DateTime? CourseCreatedDate { get; set; }
        public DateTime? CourseUpdatedDate { get; set; }
    }


}
