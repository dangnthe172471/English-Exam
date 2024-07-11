using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjectPRN.Models;

public partial class ProjectPrnContext : DbContext
{
    public ProjectPrnContext()
    {
    }

    public ProjectPrnContext(DbContextOptions<ProjectPrnContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<ExamQuestion> ExamQuestions { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Score> Scores { get; set; }

    public virtual DbSet<UserAnswer> UserAnswers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server =DESKTOP-2227T1I\\SQLEXPRESS; database = ProjectPRN;uid=sa;pwd=123; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3213E83FB278C0B2");

            entity.ToTable("Account");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Pass)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("pass");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.User)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("user");
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Exam__3213E83F3B23D301");

            entity.ToTable("Exam");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.NumQuestion).HasColumnName("numQuestion");
            entity.Property(e => e.Timeline).HasColumnName("timeline");
        });

        modelBuilder.Entity<ExamQuestion>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.ExamId, e.QuestionId }).HasName("PK__ExamQues__FD897A4C5D1F8A12");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            entity.HasOne(d => d.Exam).WithMany(p => p.ExamQuestions)
                .HasForeignKey(d => d.ExamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExamQuest__ExamI__3E52440B");

            entity.HasOne(d => d.Question).WithMany(p => p.ExamQuestions)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExamQuest__Quest__3F466844");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3213E83F5A01B245");

            entity.ToTable("Question");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreateBy).HasColumnName("create_by");
            entity.Property(e => e.QuestionPrompt).HasColumnName("question_prompt");

            entity.HasOne(d => d.CreateByNavigation).WithMany(p => p.Questions)
                .HasForeignKey(d => d.CreateBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Question__create__398D8EEE");
        });

        modelBuilder.Entity<Score>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Score__3213E83FD2DC5E33");

            entity.ToTable("Score");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.ExamId).HasColumnName("examId");
            entity.Property(e => e.Mark).HasColumnName("mark");

            entity.HasOne(d => d.Account).WithMany(p => p.Scores)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Score__accountId__4222D4EF");

            entity.HasOne(d => d.Exam).WithMany(p => p.Scores)
                .HasForeignKey(d => d.ExamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Score__examId__4316F928");
        });

        modelBuilder.Entity<UserAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserAnsw__3213E83F3C3305AE");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.ExamId).HasColumnName("examId");
            entity.Property(e => e.QuestionId).HasColumnName("questionId");
            entity.Property(e => e.SelectedAnswer).HasColumnName("selectedAnswer");

            entity.HasOne(d => d.Account).WithMany(p => p.UserAnswers)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserAnswe__accou__45F365D3");

            entity.HasOne(d => d.Exam).WithMany(p => p.UserAnswers)
                .HasForeignKey(d => d.ExamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserAnswe__examI__46E78A0C");

            entity.HasOne(d => d.Question).WithMany(p => p.UserAnswers)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserAnswe__quest__47DBAE45");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
