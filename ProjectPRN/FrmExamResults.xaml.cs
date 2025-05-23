﻿using ProjectPRN.Models;
using System.Windows;
using System.Windows.Input;

namespace ProjectPRN
{
    /// <summary>
    /// Interaction logic for FrmExamResults.xaml
    /// </summary>
    public partial class FrmExamResults : Window
    {
        public FrmExamResults()
        {
            InitializeComponent();
        }
        private string name;
        public double TotalScore { get; set; }
        private int corectQ = 0;
        private int totalQ = 0;

        private int accountId;
        private int examId;
        private int solan;

        private ProjectPrnContext context = new ProjectPrnContext();

        public FrmExamResults(int accountId, int examId, string name, int solan)
        {
            InitializeComponent();
            this.accountId = accountId;
            this.examId = examId;
            this.name = name;
            this.solan = solan;
            Title = "Hello " + name;
            ShowResult();
        }

        private void ShowResult()
        {
            var userAnswers = context.UserAnswers
                                    .Where(ua => ua.AccountId == accountId && ua.ExamId == examId && ua.Solan == solan)
                                    .ToList();

            var resultView = new List<Object>();
            int stt = 1;

            foreach (var userAnswer in userAnswers)
            {
                var question = context.Questions.FirstOrDefault(q => q.Id == userAnswer.QuestionId);
                if (question != null)
                {
                    bool isCorrect = userAnswer.SelectedAnswer == question.ResultNum.ToString();
                    if (isCorrect) corectQ++;
                    resultView.Add(new
                    {
                        STT = stt++,
                        QuestionPropmt = question.QuestionPrompt,
                        QuestionContent = question.Content,
                        UserAnswer = userAnswer.SelectedAnswer.Equals("1") ? question.Answers1 : (userAnswer.SelectedAnswer.Equals("2") ? question.Answers2 : (userAnswer.SelectedAnswer.Equals("3") ? question.Answers3 : (userAnswer.SelectedAnswer.Equals("4") ? question.Answers4 : ""))),
                        CorrectAnswer = question.ResultNum == 1 ? question.Answers1 : (question.ResultNum == 2 ? question.Answers2 : (question.ResultNum == 3 ? question.Answers3 : (question.ResultNum == 4 ? question.Answers4 : ""))),
                        //UserAnswer = userAnswer.SelectedAnswer,
                        //CorrectAnswer = question.ResultNum.ToString(),
                        Result = isCorrect ? "Đúng" : "Sai"

                    }); ;
                    totalQ++;
                }
            }

            ResultDataGrid.ItemsSource = resultView;

            // Tính tổng điểm và hiển thị lên giao diện
            TotalScore = Math.Round(context.Scores.FirstOrDefault(s => s.AccountId == accountId && s.ExamId == examId)?.Mark ?? 0, 2);
            txtCorrect.Text = corectQ.ToString();
            txtTotal.Text = totalQ.ToString();
            DataContext = this;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrmUser fu = new FrmUser(this.name);
            fu.Show();
            this.Close();
        }

        private void ResultDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            return;
        }
    }
}
