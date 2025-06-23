using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppModels
{
    public class MyProfileDto
    {
        public int UserId { get; set; }
        public int RolesId { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? MaritalStatus { get; set; }
        public string? AlternateMobileNumber { get; set; }
        public string? HighestQualification { get; set; }
        public string? QualificationStream { get; set; }
        public string? CollegeName { get; set; }
        public int? PassedOutYear { get; set; }
        public string? Designation { get; set; }
        public string? JobTitle { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? PhotoPath { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? GitHubUrl { get; set; }
        public decimal? Experience { get; set; }
    }
}
