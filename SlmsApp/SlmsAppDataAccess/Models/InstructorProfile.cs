using System;
using System.Collections.Generic;

namespace SlmsAppDataAccess.Models;

public partial class InstructorProfile
{
    public int ProfileId { get; set; }

    public int Id { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string Gender { get; set; }

    public string MaritalStatus { get; set; }

    public string AlternateMobileNo { get; set; }

    public string PersonalMailId { get; set; }

    public string HighestQualification { get; set; }

    public string Stream { get; set; }

    public string CollegeName { get; set; }

    public int? PassedOutYear { get; set; }

    public string Designation { get; set; }

    public string JobTitle { get; set; }

    public string CurrentAddress { get; set; }

    public string PermanentAddress { get; set; }

    public string PhotoPath { get; set; }

    public DateTime? Created_date { get; set; }
    public DateTime? Updated_date { get; set; }

    public string LinkedInUrl { get; set; }

    public string GithubUrl { get; set; }

    public string Experience { get; set; }

    public virtual User IdNavigation { get; set; }
}
