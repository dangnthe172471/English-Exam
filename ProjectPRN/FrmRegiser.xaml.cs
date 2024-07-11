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
    /// Interaction logic for FrmRegiser.xaml
    /// </summary>
    public partial class FrmRegiser : Window
    {
        public FrmRegiser()
        {
            InitializeComponent();
        }
        ProjectPrnContext context = new ProjectPrnContext();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtUser.Text) || String.IsNullOrEmpty(txtPass.Password) || String.IsNullOrEmpty(txtRePass.Password) || String.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            var user = context.Accounts.FirstOrDefault(a => a.User.Equals(txtUser.Text));
            if (!txtPass.Password.Equals(txtRePass.Password))
            {
                MessageBox.Show("Mật khẩu không khớp!");
            }
            else
            {
                if (user != null)
                {
                    MessageBox.Show("Tài khoản đã tồn tại!");
                }
                else
                {
                    Account account = new Account();
                    account.User = txtUser.Text;
                    account.Pass = txtPass.Password;
                    account.Email = txtEmail.Text;
                    account.Phone = txtPhone.Text;
                    context.Accounts.Add(account);
                    context.SaveChanges();
                    MessageBox.Show("Đăng ký tài khoản thành công!");
                }
            }

        }
    }
}
