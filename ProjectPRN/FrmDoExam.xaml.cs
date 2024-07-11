using Microsoft.Identity.Client;
using Microsoft.Identity.Client.NativeInterop;
using ProjectPRN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ProjectPRN
{
    /// <summary>
    /// Interaction logic for FrmDoExam.xaml
    /// </summary>
    public partial class FrmDoExam : Window
    {
        private string name;
        private int examID;

        private int currentQuestionIndex = 0;
        private List<Question> questions;
        private List<int?> selectedAnswersList = new List<int?>();
        private DispatcherTimer timer;
        private TimeSpan timeLeft;
        private ProjectPrnContext context = new ProjectPrnContext();

        public FrmDoExam()
        {
            InitializeComponent();
        }

        public FrmDoExam(List<Question> questions, TimeSpan duration, string name, int examID)
        {
            InitializeComponent();
            this.examID = examID;
            this.name = name;
            Title = "Hello " + name;
            this.questions = questions;
            this.timeLeft = duration;
            InitializeTimer();
            InitializeSelectedAnswersList();
            DisplayQuestion(currentQuestionIndex);
        }

        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void InitializeSelectedAnswersList()
        {
            // Khởi tạo danh sách câu trả lời với các giá trị null
            for (int i = 0; i < questions.Count; i++)
            {
                selectedAnswersList.Add(null);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timeLeft == TimeSpan.Zero)
            {
                timer.Stop();
                MessageBox.Show("Time's up!");
                TimeUp();
            }
            else
            {
                timeLeft = timeLeft.Add(TimeSpan.FromSeconds(-1));
                TimerTextBlock.Text = timeLeft.ToString("c");
            }
        }

        private void DisplayQuestion(int index)
        {
            if (index < 0 || index >= questions.Count) return;

            var question = questions[index];
            QuestionNumberTextBlock.Text = $"Question {index + 1}/{questions.Count}";
            QuestionPromptTextBlock.Text = question.QuestionPrompt;
            QuestionContentTextBlock.Text = question.Content;

            Answer1RadioButton.Content = question.Answers1;
            Answer2RadioButton.Content = question.Answers2;
            Answer3RadioButton.Content = question.Answers3;
            Answer4RadioButton.Content = question.Answers4;

            // Reset the selected answer
            Answer1RadioButton.IsChecked = false;
            Answer2RadioButton.IsChecked = false;
            Answer3RadioButton.IsChecked = false;
            Answer4RadioButton.IsChecked = false;

            // Hiển thị câu trả lời đã chọn (nếu có)
            int? selectedAnswer = selectedAnswersList[index];
            if (selectedAnswer.HasValue)
            {
                switch (selectedAnswer)
                {
                    case 1: Answer1RadioButton.IsChecked = true; break;
                    case 2: Answer2RadioButton.IsChecked = true; break;
                    case 3: Answer3RadioButton.IsChecked = true; break;
                    case 4: Answer4RadioButton.IsChecked = true; break;
                }
            }
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            SaveSelectedAnswer();
            if (currentQuestionIndex > 0)
            {
                currentQuestionIndex--;
                DisplayQuestion(currentQuestionIndex);
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            SaveSelectedAnswer();
            if (currentQuestionIndex < questions.Count - 1)
            {
                currentQuestionIndex++;
                DisplayQuestion(currentQuestionIndex);
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            SaveSelectedAnswer();
            SubmitExam();
        }

        private void SaveSelectedAnswer()
        {
            int? selectedAnswer = null;

            if (Answer1RadioButton.IsChecked == true) selectedAnswer = 1;
            else if (Answer2RadioButton.IsChecked == true) selectedAnswer = 2;
            else if (Answer3RadioButton.IsChecked == true) selectedAnswer = 3;
            else if (Answer4RadioButton.IsChecked == true) selectedAnswer = 4;

            // Lưu câu trả lời vào danh sách
            selectedAnswersList[currentQuestionIndex] = selectedAnswer;
        }
        private void TimeUp()
        {
            SaveSelectedAnswer();
            // Lưu điểm số vào bảng Score
            double score = CalculateScore(); // Phương thức để tính điểm số của người dùng
            SaveScore(score);

            // Lưu đáp án từng câu vào bảng UserAnswers
            SaveUserAnswers();

            // Dừng bộ đếm thời gian và thông báo đã nộp bài
            timer.Stop();
            MessageBox.Show("Exam submitted!");

            // Hiển thị màn hình kết quả
            var user = context.Accounts.FirstOrDefault(a => a.User.Equals(this.name));
            FrmExamResults resultWindow = new FrmExamResults(user.Id, examID, this.name);
            resultWindow.Show();
            this.Close();
        }
        private void SubmitExam()
        {
            if (MessageBox.Show("Bạn có chắc muốn nộp bài không?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                // Lưu điểm số vào bảng Score
                double score = CalculateScore(); // Phương thức để tính điểm số của người dùng
                SaveScore(score);

                // Lưu đáp án từng câu vào bảng UserAnswers
                SaveUserAnswers();

                // Dừng bộ đếm thời gian và thông báo đã nộp bài
                timer.Stop();
                MessageBox.Show("Exam submitted!");

                // Hiển thị màn hình kết quả
                var user = context.Accounts.FirstOrDefault(a => a.User.Equals(this.name));
                FrmExamResults resultWindow = new FrmExamResults(user.Id, examID, this.name);
                resultWindow.Show();
                this.Close();
            }
        }

        private double CalculateScore()
        {
            int totalQuestions = questions.Count;
            if (totalQuestions == 0)
                return 0.0;

            int correctAnswers = 0;

            for (int index = 0; index < totalQuestions; index++)
            {
                // Kiểm tra xem index có nằm trong khoảng hợp lệ của selectedAnswersList
                if (index >= 0 && index < selectedAnswersList.Count)
                {
                    int? selectedAnswer = selectedAnswersList[index];
                    if (selectedAnswer.HasValue)
                    {
                        // Lấy đáp án đúng của câu hỏi từ Question.ResultNum
                        int correctAnswer = questions[index].ResultNum;

                        // So sánh và tính điểm
                        if (selectedAnswer == correctAnswer)
                        {
                            correctAnswers++;
                        }
                    }
                    // Nếu không tìm thấy selectedAnswer cho câu hỏi này, bạn có thể xử lý hoặc bỏ qua tùy vào logic của bạn
                }
            }

            // Tính điểm số dựa trên số câu đúng và tổng số câu hỏi
            double score = (double)correctAnswers / totalQuestions * 10;
            return score;
        }


        private void SaveScore(double score)
        {
            var user = context.Accounts.FirstOrDefault(a => a.User.Equals(this.name));

            Score newScore = new Score
            {
                AccountId = user.Id,
                ExamId = this.examID,
                Date = DateOnly.FromDateTime(DateTime.Now),
                Mark = score,
            };
            context.Scores.Add(newScore);
            context.SaveChanges();
        }

        private void SaveUserAnswers()
        {
            var user = context.Accounts.FirstOrDefault(a => a.User.Equals(this.name));

            for (int index = 0; index < questions.Count; index++)
            {
                int selectedAnswer = 0; // Giá trị mặc định là 0

                // Kiểm tra xem index có nằm trong khoảng hợp lệ của selectedAnswersList
                if (index >= 0 && index < selectedAnswersList.Count && selectedAnswersList[index].HasValue)
                {
                    selectedAnswer = selectedAnswersList[index].Value;
                }

                // Lưu đáp án từng câu vào bảng UserAnswers
                UserAnswer userAnswer = new UserAnswer
                {
                    AccountId = user.Id,
                    ExamId = this.examID,
                    QuestionId = questions[index].Id, // Lấy ID của câu hỏi từ danh sách questions
                    SelectedAnswer = selectedAnswer.ToString()
                };
                context.UserAnswers.Add(userAnswer);
            }

            context.SaveChanges();
        }


    }
}
