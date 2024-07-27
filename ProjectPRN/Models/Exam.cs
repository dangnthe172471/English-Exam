using System;
using System.Collections.Generic;

namespace ProjectPRN.Models;

public partial class Exam
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Date { get; set; } = null!;

    public int NumQuestion { get; set; }

    public string Timeline { get; set; } = null!;

    public virtual ICollection<ExamQuestion> ExamQuestions { get; set; } = new List<ExamQuestion>();

    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();

    public virtual ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
}
