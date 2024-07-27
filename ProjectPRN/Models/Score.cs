using System;
using System.Collections.Generic;

namespace ProjectPRN.Models;

public partial class Score
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int ExamId { get; set; }

    public string Date { get; set; } = null!;

    public double Mark { get; set; }

    public int? Solan { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Exam Exam { get; set; } = null!;
}
