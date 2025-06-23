using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppModels
{
    public class CreateQuizDto
    {
        public int CreateQuizId { get; set; }
        public string QuizTitle { get; set; }
        public string QuizDescription { get; set; }
        public DateTime QuizCreationTime { get; set; }
        public DateTime? QuizUpdateTime { get; set; }
        public int SectionId { get; set; }
        public int CreatedByUserId { get; set; }
    }
}
