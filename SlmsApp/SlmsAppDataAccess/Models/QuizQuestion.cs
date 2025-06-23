using System;
using System.Collections.Generic;

namespace SlmsAppDataAccess.Models;

public partial class QuizQuestion
{
    public int QuizQuestionId { get; set; }

    public DateTime QuestionCreatedDate { get; set; }

    public DateTime? QuestionUpdatedDate { get; set; }

    public int CreateQuizId { get; set; }

    public int QuestionTime { get; set; }

    public string QuizQuestionText { get; set; }

    public virtual CreateQuiz CreateQuiz { get; set; }

    public virtual ICollection<QuizAnswer> QuizAnswers { get; set; } = new List<QuizAnswer>();
}
