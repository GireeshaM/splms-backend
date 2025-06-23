using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppModels
{
    public class QuizAnswerDto
    {
        public int QuizAnswerId { get; set; }
        public string QuizAnswerText { get; set; }
        public string AnswerDescription { get; set; }
        public DateTime AnswerCreatedDate { get; set; }
        public DateTime? AnswerUpdatedDate { get; set; }
        public bool AnswerCorrectOrNot { get; set; }
        public int QuizQuestionId { get; set; }
    }
}
