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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectPodgotovka.Pages
{
    /// <summary>
    /// Логика взаимодействия для EnterPage.xaml
    /// </summary>
    public partial class EnterPage : Page
    {
        public EnterPage()
        {
            InitializeComponent();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTB == null || PasswordPB == null)
                MessageBox.Show("Введите логин и пароль");
            using(var db = new PodgotovkaBaseEntities())
            {
                var user = db.Users.AsNoTracking().FirstOrDefault(u => u.Login == LoginTB.Text && u.Password == PasswordPB.Password);
                if(user == null)
                {
                    MessageBox.Show("Пользователь не найден!");
                    return;
                }
                MessageBox.Show("Good!");
                Manager.MainFrame.Navigate(new DataGridPage());
            }
        }
    }
}
