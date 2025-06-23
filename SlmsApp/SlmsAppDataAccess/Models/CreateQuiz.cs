using System;
using System.Collections.Generic;

namespace SlmsAppDataAccess.Models;

public partial class CreateQuiz
{
    public int CreateQuizId { get; set; }

    public string QuizTitle { get; set; }

    public string QuizDescription { get; set; }

    public DateTime QuizCreationTime { get; set; }

    public DateTime? QuizUpdateTime { get; set; }

    public int SectionId { get; set; }

    public int CreatedByUserId { get; set; }

    public virtual User CreatedByUser { get; set; }

    public virtual ICollection<LessonsOrder> LessonsOrders { get; set; } = new List<LessonsOrder>();

    public virtual ICollection<QuizQuestion> QuizQuestions { get; set; } = new List<QuizQuestion>();

    public virtual Section Section { get; set; }
}
