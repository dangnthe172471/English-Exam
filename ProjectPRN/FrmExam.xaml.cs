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
    /// Interaction logic for FrmExam.xaml
    /// </summary>
    public partial class FrmExam : Window
    {
        private string name;
        public FrmExam()
        {
            InitializeComponent();
            LoadData();
        }

        public FrmExam(string name)
        {
            InitializeComponent();
            this.name = name;
            Title = "Hello " + name;
            LoadData();
        }

        ProjectPrnContext context = new ProjectPrnContext();
        private void LoadData()
        {
            var data = context.Questions.Select(q =>
            new
            {
                ID = q.Id,
                QuestionPrompt = q.QuestionPrompt,
                QuestionContent = q.Content,
                Answer1 = q.Answers1,
                Answer2 = q.Answers2,
                Answer3 = q.Answers3,
                Answer4 = q.Answers4,
                Result = q.ResultNum,
            }).ToList();
            lbQuestions.ItemsSource = data;
            var data2 = context.Exams.Select(e =>
            new
            {
                ID = e.Id,
                Name = e.Name,
                Date = e.Date,
                NumQuestion = e.NumQuestion,
                Time = e.Timeline,
            }).ToList();
            dgExam.ItemsSource = data2;
            lbQuestions1.ItemsSource = null;
        }

        private void SelectionMethod_Checked(object sender, RoutedEventArgs e)
        {
            if (rbRandom.IsChecked == true)
            {
                randomPanel.Visibility = Visibility.Visible;
                manualPanel.Visibility = Visibility.Collapsed;
            }
            else if (rbManual.IsChecked == true)
            {
                randomPanel.Visibility = Visibility.Collapsed;
                manualPanel.Visibility = Visibility.Visible;
            }
        }

        private void CreateRandomExam_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNameExam.Text) || string.IsNullOrEmpty(txtRandomCount.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            var exam = context.Exams.FirstOrDefault(exam => exam.Name.Equals(txtNameExam.Text));
            if (exam != null)
            {
                MessageBox.Show("Tên đề thi đã tồn tại!");
                return;
            }
            if (int.TryParse(txtRandomCount.Text, out int questionCount))
            {
                if (questionCount > (context.Questions.ToList()).Count || questionCount < 1)
                {
                    MessageBox.Show("Số câu hỏi random phải từ 1 đến " + (context.Questions.ToList()).Count + " câu hỏi!");
                    return;
                }
                var randomQuestions = context.Questions.OrderBy(q => Guid.NewGuid()).Take(questionCount).ToList();
                double timeLine = questionCount / 2.0;
                var newExam = new Exam
                {
                    Name = txtNameExam.Text,
                    Date = DateTime.Now.ToString(),
                    NumQuestion = questionCount,
                    Timeline = timeLine.ToString(),
                };

                // Lưu đề thi vào cơ sở dữ liệu
                context.Exams.Add(newExam);
                context.SaveChanges();

                // Thêm các câu hỏi vào bảng trung gian ExamQuestions
                foreach (var question in randomQuestions)
                {
                    var examQuestion = new ExamQuestion
                    {
                        ExamId = newExam.Id,
                        QuestionId = question.Id,
                    };
                    context.ExamQuestions.Add(examQuestion);
                }

                context.SaveChanges();
                LoadData();
                MessageBox.Show($"Tạo thành công đề thi có {questionCount} câu hỏi.");
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số câu hỏi là số nguyên!");
            }
        }

        private void CreateManualExam_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNameExam1.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            var exam = context.Exams.FirstOrDefault(exam => exam.Name.Equals(txtNameExam1.Text));
            if (exam != null)
            {
                MessageBox.Show("Tên đề thi đã tồn tại!");
                return;
            }
            var selectedQuestions = lbQuestions.SelectedItems.Cast<dynamic>().ToList();
            double timeLine = selectedQuestions.Count / 2.0;
            var newExam = new Exam
            {
                Name = txtNameExam1.Text,
                Date = DateTime.Now.ToString(),
                NumQuestion = selectedQuestions.Count,
                Timeline = timeLine.ToString(),
            };

            // Lưu đề thi vào cơ sở dữ liệu
            context.Exams.Add(newExam);
            context.SaveChanges();

            // Thêm các câu hỏi vào bảng trung gian ExamQuestions
            foreach (var question in selectedQuestions)
            {
                var examQuestion = new ExamQuestion
                {
                    ExamId = newExam.Id,
                    QuestionId = question.ID,
                };
                context.ExamQuestions.Add(examQuestion);
            }

            context.SaveChanges();
            LoadData();

            MessageBox.Show($"Tạo thành công bài thi có {selectedQuestions.Count} câu hỏi.");
        }

        private void dgExam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var exam = dgExam.SelectedItem as dynamic;
            if (exam != null)
            {
                int id = exam.ID;
                txtID.Text = id.ToString();
                var data = context.Questions.ToList();
                var data1 = context.Questions
               .Where(q => q.ExamQuestions.Any(eq => eq.ExamId == id)).Select(q => new
               {
                   ID = q.Id,
                   QuestionPrompt = q.QuestionPrompt,
                   QuestionContent = q.Content,
                   Answer1 = q.Answers1,
                   Answer2 = q.Answers2,
                   Answer3 = q.Answers3,
                   Answer4 = q.Answers4,
                   Result = q.ResultNum,
               }).ToList();
                lbQuestions1.ItemsSource = data1;

                var data2 = context.Questions
             .Where(q => !q.ExamQuestions.Any(eq => eq.ExamId == id)).Select(q => new
             {
                 ID = q.Id,
                 QuestionPrompt = q.QuestionPrompt,
                 QuestionContent = q.Content,
                 Answer1 = q.Answers1,
                 Answer2 = q.Answers2,
                 Answer3 = q.Answers3,
                 Answer4 = q.Answers4,
                 Result = q.ResultNum,
             }).ToList();
                lbQuestions.ItemsSource = data2;

            }
            else
            {
                txtID.Clear();
            }
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var data = context.Questions.Select(q => new
            {
                ID = q.Id,
                QuestionPrompt = q.QuestionPrompt,
                QuestionContent = q.Content,
                Answer1 = q.Answers1,
                Answer2 = q.Answers2,
                Answer3 = q.Answers3,
                Answer4 = q.Answers4,
                Result = q.ResultNum,
            }).ToList();
            lbQuestions.ItemsSource = data;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Đề thi không tồn tại");
                return;
            }
            var exam = context.Exams.FirstOrDefault(ex => ex.Id == Convert.ToInt32(txtID.Text));
            var examQuetion = context.ExamQuestions.Where(eq => eq.ExamId == Convert.ToInt32(txtID.Text)).ToList();
            foreach (var eq in examQuetion)
            {
                context.ExamQuestions.Remove(eq);
            }
            context.Exams.Remove(exam);
            context.SaveChanges();
            LoadData();
            MessageBox.Show("Xóa đề thi thành công!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrmAdmin ad = new FrmAdmin(this.name);
            ad.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var data2 = context.Exams.Where(ex => ex.Name.Contains(txtSearch.Text)).Select(e =>
            new
            {
                ID = e.Id,
                Name = e.Name,
                Date = e.Date,
                NumQuestion = e.NumQuestion,
                Time = e.Timeline,
            }).ToList();
            dgExam.ItemsSource = data2;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn đề thi!");
                return;
            }

            int id = Convert.ToInt32(txtID.Text);

            var selectedQuestions = lbQuestions1.SelectedItems.Cast<dynamic>().Select(ex => ex.ID).ToList();
            if (selectedQuestions.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn câu hỏi muốn xóa!(ở bảng 2)");
                return;
            }

            var examQuestion = context.ExamQuestions.Where(eq => eq.ExamId == id).ToList();

            // Tạo danh sách các câu hỏi cần xóa
            var questionsToRemove = examQuestion.Where(eq => selectedQuestions.Contains(eq.QuestionId)).ToList();

            // Tạo danh sách các câu hỏi còn lại
            var remainingQuestions = examQuestion.Where(eq => !selectedQuestions.Contains(eq.QuestionId)).ToList();
            if (remainingQuestions.Count == 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa toàn bộ câu hỏi trong đề(sẽ xóa đề thi)?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Button_Click(sender, e);
                    return;
                }
                else
                {
                    return;
                }
            }

            // Xóa các câu hỏi cần xóa
            context.ExamQuestions.RemoveRange(questionsToRemove);
            context.SaveChanges();

            double timeLine = remainingQuestions.Count() / 2.0;

            var exam = context.Exams.FirstOrDefault(ex => ex.Id == id);
            exam.Timeline = timeLine.ToString();
            exam.NumQuestion = remainingQuestions.Count();
            context.SaveChanges();

            var data3 = context.Exams.Select(e =>
           new
           {
               ID = e.Id,
               Name = e.Name,
               Date = e.Date,
               NumQuestion = e.NumQuestion,
               Time = e.Timeline,
           }).ToList();
            dgExam.ItemsSource = data3;
            var data = context.Questions.ToList();
            var data1 = context.Questions
           .Where(q => q.ExamQuestions.Any(eq => eq.ExamId == id)).Select(q => new
           {
               ID = q.Id,
               QuestionPrompt = q.QuestionPrompt,
               QuestionContent = q.Content,
               Answer1 = q.Answers1,
               Answer2 = q.Answers2,
               Answer3 = q.Answers3,
               Answer4 = q.Answers4,
               Result = q.ResultNum,
           }).ToList();
            lbQuestions1.ItemsSource = data1;

            var data2 = context.Questions
         .Where(q => !q.ExamQuestions.Any(eq => eq.ExamId == id)).Select(q => new
         {
             ID = q.Id,
             QuestionPrompt = q.QuestionPrompt,
             QuestionContent = q.Content,
             Answer1 = q.Answers1,
             Answer2 = q.Answers2,
             Answer3 = q.Answers3,
             Answer4 = q.Answers4,
             Result = q.ResultNum,
         }).ToList();
            lbQuestions.ItemsSource = data2;

            MessageBox.Show("Xóa câu hỏi trong đề thành công!");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn đề thi!");
                return;
            }

            int id = Convert.ToInt32(txtID.Text);

            var selectedQuestions = lbQuestions.SelectedItems.Cast<dynamic>().Select(ex => ex.ID).ToList();
            if (selectedQuestions.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn câu hỏi muốn thêm!(ở bảng 1)");
                return;
            }
            var examQuestion = context.ExamQuestions.Where(eq => eq.ExamId == id).ToList();

            // Tạo danh sách các câu hỏi cần add
            var questionsToAdd = selectedQuestions.Where(sq => !examQuestion.Any(eq => eq.QuestionId == sq)).Select(sq => new ExamQuestion
            {
                ExamId = id,
                QuestionId = sq
            }).ToList();

            // Xóa các câu hỏi cần add
            context.ExamQuestions.AddRange(questionsToAdd);
            context.SaveChanges();

            examQuestion = context.ExamQuestions.Where(eq => eq.ExamId == id).ToList();
            double timeLine = examQuestion.Count() / 2.0;

            var exam = context.Exams.FirstOrDefault(ex => ex.Id == id);
            exam.Timeline = timeLine.ToString();
            exam.NumQuestion = examQuestion.Count();
            context.SaveChanges();

            var data3 = context.Exams.Select(e =>
           new
           {
               ID = e.Id,
               Name = e.Name,
               Date = e.Date,
               NumQuestion = e.NumQuestion,
               Time = e.Timeline,
           }).ToList();
            dgExam.ItemsSource = data3;
            var data = context.Questions.ToList();
            var data1 = context.Questions
           .Where(q => q.ExamQuestions.Any(eq => eq.ExamId == id)).Select(q => new
           {
               ID = q.Id,
               QuestionPrompt = q.QuestionPrompt,
               QuestionContent = q.Content,
               Answer1 = q.Answers1,
               Answer2 = q.Answers2,
               Answer3 = q.Answers3,
               Answer4 = q.Answers4,
               Result = q.ResultNum,
           }).ToList();
            lbQuestions1.ItemsSource = data1;

            var data2 = context.Questions
         .Where(q => !q.ExamQuestions.Any(eq => eq.ExamId == id)).Select(q => new
         {
             ID = q.Id,
             QuestionPrompt = q.QuestionPrompt,
             QuestionContent = q.Content,
             Answer1 = q.Answers1,
             Answer2 = q.Answers2,
             Answer3 = q.Answers3,
             Answer4 = q.Answers4,
             Result = q.ResultNum,
         }).ToList();
            lbQuestions.ItemsSource = data2;

            MessageBox.Show("Thêm câu hỏi vào đề thành công!");

        }
    }
}
