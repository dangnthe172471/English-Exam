using System;
using System.Collections.Generic;

namespace ProjectPRN.Models;

public partial class Question
{
    public int Id { get; set; }

    public int CreateBy { get; set; }

    public string QuestionPrompt { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string Answers1 { get; set; } = null!;

    public string Answers2 { get; set; } = null!;

    public string Answers3 { get; set; } = null!;

    public string Answers4 { get; set; } = null!;

    public int ResultNum { get; set; }

    public virtual Account CreateByNavigation { get; set; } = null!;

    public virtual ICollection<ExamQuestion> ExamQuestions { get; set; } = new List<ExamQuestion>();

    public virtual ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
}
