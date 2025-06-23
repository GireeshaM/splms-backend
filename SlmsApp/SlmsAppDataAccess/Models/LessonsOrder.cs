using System;
using System.Collections.Generic;

namespace SlmsAppDataAccess.Models;

public partial class LessonsOrder
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int CourseId { get; set; }

    public int SectionId { get; set; }

    public int? VideoId { get; set; }

    public int? QuizId { get; set; }

    public int OrderId { get; set; }

    public virtual CreateCourse Course { get; set; }

    public virtual CreateQuiz Quiz { get; set; }

    public virtual Section Section { get; set; }

    public virtual User User { get; set; }

    public virtual Video Video { get; set; }
}
