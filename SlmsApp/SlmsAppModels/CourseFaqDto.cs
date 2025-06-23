using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppModels
{
    public class CourseFaqDto
    {
        public int CourseFaqsId { get; set; }
        public int CreateCourseId { get; set; }
        public string FaqQuestion { get; set; }
        public string FaqAnswer { get; set; }
    }
}
