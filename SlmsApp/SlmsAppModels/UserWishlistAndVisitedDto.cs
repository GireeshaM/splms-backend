using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppModels
{
    public class UserWishlistAndVisitedDto
    {
        public int UserId { get; set; }
        public int CreateCourseId { get; set; }
        public bool CourseWishlist { get; set; }
        public bool CourseVisited { get; set; }
    }
}
