using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppModels
{
    public class QuizQuestionDTO
    {
        public int QuizQuestionId { get; set; }
        public string QuizQuestionText { get; set; }
        public DateTime QuestionCreatedDate { get; set; }
        public DateTime? QuestionUpdatedDate { get; set; }
        public int CreateQuizId { get; set; }
        public int QuestionTime { get; set; }
    }
}
