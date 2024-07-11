using ProjectPRN.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectPRN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        ProjectPrnContext context = new ProjectPrnContext();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrmRegiser register = new FrmRegiser();
            register.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // tìm xem có user nào mà account == txtAccount và password == txtPassword hay không ?
            var user = context.Accounts.FirstOrDefault(a => a.User.Equals(txtUser.Text) && a.Pass.Equals(txtPass.Password));
            if (user!=null)
            {
                if (user.Role == 1)
                {
                    string name = user.User;
                    FrmAdmin admin = new FrmAdmin(name);
                    admin.Show();
                    this.Close();
                }
                if (user.Role == 0)
                {
                    string name = user.User;
                    FrmUser fu = new FrmUser(name);
                    fu.Show();
                    this.Close();
                }
               
            }
            else
            {
                MessageBox.Show("login that bai");
            }
        }
    }
}