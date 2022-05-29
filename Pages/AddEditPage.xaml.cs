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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
#pragma warning disable IDE0044 // Добавить модификатор только для чтения
        private Emloyees _currentemloyees = new Emloyees();
#pragma warning restore IDE0044 // Добавить модификатор только для чтения

        public AddEditPage(Emloyees selectedemployees)
        {
            InitializeComponent();
            if (selectedemployees != null)
                _currentemloyees = selectedemployees;

            DataContext = _currentemloyees;
            ComboRole.ItemsSource = PodgotovkaBaseEntities.GetContext().Roles.ToList();

            if (selectedemployees == null)
                _currentemloyees.Birthday = DateTime.Now;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new DataGridPage());
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(_currentemloyees.Name))
                errors.AppendLine("Enter a Name");
            if (_currentemloyees.Age <= 0)
                errors.AppendLine("Enter a Age");
            if (_currentemloyees.Birthday == null || _currentemloyees.Birthday.ToString() == "01.01.0001")
                errors.AppendLine("Enter a Birthday");
            if (_currentemloyees.Roles == null)
                errors.AppendLine("Choose a role");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentemloyees.ID == 0)
                PodgotovkaBaseEntities.GetContext().Emloyees.Add(_currentemloyees);

            try
            {
                PodgotovkaBaseEntities.GetContext().SaveChanges();
                MessageBox.Show("Successfully");
                Manager.MainFrame.Navigate(new DataGridPage());
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
                
        }
    }
}
