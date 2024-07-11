using System;
using System.Collections.Generic;

namespace ProjectPRN.Models;

public partial class Account
{
    public int Id { get; set; }

    public string User { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public int Role { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();

    public virtual ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
}
