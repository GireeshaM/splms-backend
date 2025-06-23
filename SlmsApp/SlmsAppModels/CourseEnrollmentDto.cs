using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppModels
{
    public class CourseEnrollmentDto
    {
        public int EnrollmentId { get; set; }
        public int UserId { get; set; }
        public int CreateCourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
