using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppModels
{
    public class LessonsOrderDto
    {
        public int? Id { get; set; } // for update
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int SectionId { get; set; }
        public int? VideoId { get; set; }
        public int? QuizId { get; set; }
        public int OrderId { get; set; }
    }

}
