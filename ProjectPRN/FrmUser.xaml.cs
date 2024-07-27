using Microsoft.EntityFrameworkCore;
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

namespace ProjectPRN
{
    /// <summary>
    /// Interaction logic for FrmUser.xaml
    /// </summary>
    public partial class FrmUser : Window
    {
        private string name;
        private ProjectPrnContext context = new ProjectPrnContext();

        public FrmUser()
        {
            InitializeComponent();
            LoadData();
        }

        public FrmUser(string name)
        {
            InitializeComponent();
            this.name = name;
            Title = "Hello " + name;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var user = context.Accounts.FirstOrDefault(a => a.User.Equals(name));

                // Lấy tất cả các kỳ thi
                var allExams = context.Exams.ToList();

                // Lấy danh sách các kỳ thi mà người dùng đã thi
                var takenExams = context.Scores
                                        .Where(s => s.AccountId == user.Id)
                                        .Select(s => s.ExamId)
                                        .ToList();

                // Lọc ra những kỳ thi mà người dùng chưa thi
                var examsNotTaken = allExams.Where(e => !takenExams.Contains(e.Id)).ToList();

                // Hiển thị danh sách kỳ thi chưa thi trong ListBox
                ExamListBox.ItemsSource = examsNotTaken;

                // Hiển thị lịch sử bài thi
                var examHistory = context.Scores
                                    .Where(s => s.AccountId == user.Id)
                                    .Select(s => new
                                    {
                                        ExamName = context.Exams.FirstOrDefault(e => e.Id == s.ExamId).Name,
                                        ExamDate = s.Date,
                                        ExamScore = Math.Round(s.Mark, 2),
                                        LanThi = s.Solan,
                                    })
                                    .ToList();

                HistoryDataGrid.ItemsSource = examHistory;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private void StartExamButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedExam = (Exam)ExamListBox.SelectedItem;
                if (selectedExam != null)
                {
                    // Lấy danh sách QuestionId từ bảng ExamQuestions
                    var questionIds = context.ExamQuestions
                                            .Where(eq => eq.ExamId == selectedExam.Id)
                                            .Select(eq => eq.QuestionId)
                                            .ToList();

                    // Lấy danh sách các câu hỏi từ bảng Question
                    var questions = context.Questions
                                            .Where(q => questionIds.Contains(q.Id))
                                            .ToList();

                    double timeLine = questions.Count / 2.0;
                    var examDuration = TimeSpan.FromMinutes(timeLine); // Ví dụ: thời gian tính theo phút 30s 1 câu

                    var examWindow = new FrmDoExam(questions, examDuration, this.name, selectedExam.Id);
                    examWindow.Show();
                    this.Close();
                }

                var selectExam1 = HistoryDataGrid.SelectedItem as dynamic;
                string name = selectExam1.ExamName;
               
                var exam = context.Exams.FirstOrDefault(ex => ex.Name.Equals(name));
                var user = context.Accounts.FirstOrDefault(a => a.User.Equals(name));

                int solan = Convert.ToInt32(selectExam1.LanThi);
                if (solan == 2)
                {
                    MessageBox.Show("ban da lam 2 lan");
                    return;
                }

                if (selectExam1 != null)
                {
                    // Lấy danh sách QuestionId từ bảng ExamQuestions
                    var questionIds1 = context.ExamQuestions
                                            .Where(eq => eq.ExamId == exam.Id)
                                            .Select(eq => eq.QuestionId)
                                            .ToList();

                    // Lấy danh sách các câu hỏi từ bảng Question
                    var questions1 = context.Questions
                                            .Where(q => questionIds1.Contains(q.Id))
                                            .ToList();

                    double timeLine1 = questions1.Count / 2.0;
                    var examDuration1 = TimeSpan.FromMinutes(timeLine1); // Ví dụ: thời gian tính theo phút 30s 1 câu

                    var examWindow1 = new FrmDoExam(questions1, examDuration1, this.name, exam.Id);
                    examWindow1.Show();
                    this.Close();
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void HistoryDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var selectedScore = HistoryDataGrid.SelectedItem as dynamic;
                string exName = selectedScore.ExamName;
                int solan = Convert.ToInt32(selectedScore.LanThi);
                if (selectedScore != null && selectedScore.ExamName != null)
                {
                    var user = context.Accounts.FirstOrDefault(a => a.User.Equals(this.name));
                    var exam = context.Exams.FirstOrDefault(ex => ex.Name.Equals(exName));
                    FrmExamResults resultWindow = new FrmExamResults(user.Id, exam.Id, this.name, solan);
                    resultWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn bài thi muốn xem lịch sử.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting exam: {ex.Message}");
            }
        }

        private void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Kiểm tra nếu phím Ctrl hoặc Shift đang được giữ
            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control ||
                (Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
            {
                e.Handled = true;
            }
        }
        private void DataGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Kiểm tra nếu phím Ctrl hoặc Shift đang được giữ
            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control ||
                (Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
            {
                e.Handled = true;
            }
        }
    }
}
