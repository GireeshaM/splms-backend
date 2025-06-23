using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppModels
{
    public class SwapSectionOrderDto
    {
        public int UserId { get; set; }
        public int CreateCourseId { get; set; }
        public int FirstSectionId { get; set; }
        public int SecondSectionId { get; set; }
    }

}
