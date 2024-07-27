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
    /// Interaction logic for FrmAdmin.xaml
    /// </summary>
    public partial class FrmAdmin : Window
    {
        private string name;
        public FrmAdmin()
        {
            InitializeComponent();
            LoadData();
        }

        public FrmAdmin(string name)
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
            dgQuestion.ItemsSource = data;
            var data2 = context.Questions.Select(q => q.ResultNum).Distinct().ToArray();
            cboResult.ItemsSource = data2;
        }
        private void dgQuestion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var question = dgQuestion.SelectedItem as dynamic;
            if (question != null)
            {
                txtID.Text = question.ID.ToString();
                txtQPrompt.Text = question.QuestionPrompt;
                txtQContent.Text = question.QuestionContent;
                txtAnswer1.Text = question.Answer1;
                txtAnswer2.Text = question.Answer2;
                txtAnswer3.Text = question.Answer3;
                txtAnswer4.Text = question.Answer4;
                cboResult.Text = question.Result.ToString();
            }
            else
            {
                // Clear the text boxes when the selection is null
                txtID.Clear();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtQPrompt.Text) || String.IsNullOrEmpty(txtQContent.Text) || String.IsNullOrEmpty(txtAnswer1.Text) || String.IsNullOrEmpty(txtAnswer2.Text) || String.IsNullOrEmpty(txtAnswer3.Text) || String.IsNullOrEmpty(txtAnswer4.Text) || String.IsNullOrEmpty(cboResult.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            else
            {
                var newQuestion = new Question
                {
                    QuestionPrompt = txtQPrompt.Text,
                    Content = txtQContent.Text,
                    Answers1 = txtAnswer1.Text,
                    Answers2 = txtAnswer2.Text,
                    Answers3 = txtAnswer3.Text,
                    Answers4 = txtAnswer4.Text,
                    ResultNum = Convert.ToInt32(cboResult.Text),
                };
                var data = context.Questions.Add(newQuestion);
                context.SaveChanges();
                LoadData();
                MessageBox.Show("Thêm câu hỏi thành công");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn câu hỏi!");
            }
            else
            {
                Question q = context.Questions.FirstOrDefault(q => q.Id == Convert.ToInt32(txtID.Text));
                var data = context.Questions.Remove(q);
                context.SaveChanges();
                LoadData();
                MessageBox.Show("Xóa câu hỏi thành công!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn câu hỏi!");
                return;
            }
            if (String.IsNullOrEmpty(txtQPrompt.Text) || String.IsNullOrEmpty(txtQContent.Text) || String.IsNullOrEmpty(txtAnswer1.Text) || String.IsNullOrEmpty(txtAnswer2.Text) || String.IsNullOrEmpty(txtAnswer3.Text) || String.IsNullOrEmpty(txtAnswer4.Text) || String.IsNullOrEmpty(cboResult.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            else
            {
                Question q = context.Questions.FirstOrDefault(q => q.Id == Convert.ToInt32(txtID.Text));
                q.QuestionPrompt = txtQPrompt.Text;
                q.Content = txtQContent.Text;
                q.Answers1 = txtAnswer1.Text;
                q.Answers2 = txtAnswer2.Text;
                q.Answers3 = txtAnswer3.Text;
                q.Answers4 = txtAnswer4.Text;
                q.ResultNum = Convert.ToInt32(cboResult.Text);
                context.SaveChanges();
                LoadData();
                MessageBox.Show("Cập nhật câu hỏi thành công!");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            FrmExam fe = new FrmExam(this.name);
            fe.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(txtQContent.Text)&&string.IsNullOrEmpty(txtQPrompt.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung câu hỏi hoặc yêu cầu câu hỏi để tìm kiếm!");
                return;
            }
            if (String.IsNullOrEmpty(txtQContent.Text))
            {
                var data = context.Questions.Where(q => q.QuestionPrompt.Contains(txtQPrompt.Text)).Select(q =>
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
                dgQuestion.ItemsSource = data;
            }
            else if (String.IsNullOrEmpty(txtQPrompt.Text))
            {
                var data = context.Questions.Where(q => q.Content.Contains(txtQContent.Text)).Select(q =>
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
                dgQuestion.ItemsSource = data;
            }
            if (!String.IsNullOrEmpty(txtQContent.Text) && !String.IsNullOrEmpty(txtQPrompt.Text))
            {
                var data = context.Questions.Where(q => q.Content.Contains(txtQContent.Text) && q.QuestionPrompt.Contains(txtQPrompt.Text)).Select(q =>
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
                dgQuestion.ItemsSource = data;
            }

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
