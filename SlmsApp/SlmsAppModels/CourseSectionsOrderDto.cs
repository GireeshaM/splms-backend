using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppModels
{
    public class CourseSectionsOrderDto
    {
        public int UserId { get; set; }
        public int CreateCourseId { get; set; }
        public int SectionId { get; set; }
        public int SectionOrder { get; set; }
    }

}
