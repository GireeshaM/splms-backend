using System;
using System.Collections.Generic;

namespace SlmsAppDataAccess.Models;

public partial class QuizAnswer
{
    public int QuizAnswerId { get; set; }

    public string QuizAnswerText { get; set; }

    public string AnswerDescription { get; set; }

    public DateTime AnswerCreatedDate { get; set; }

    public DateTime? AnswerUpdatedDate { get; set; }

    public bool AnswerCorrectOrNot { get; set; }

    public int QuizQuestionId { get; set; }

    public virtual QuizQuestion QuizQuestion { get; set; }
}
