using System;
using System.Collections.Generic;

namespace ProjectPRN.Models;

public partial class UserAnswer
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int ExamId { get; set; }

    public int QuestionId { get; set; }

    public string SelectedAnswer { get; set; } = null!;

    public int? Solan { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Exam Exam { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;
}
