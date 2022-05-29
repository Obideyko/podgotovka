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
    /// Логика взаимодействия для DataGridPage.xaml
    /// </summary>
    public partial class DataGridPage : Page
    {
        public class Global
        {
            public string sum;
        }
        public DataGridPage()
        {
            InitializeComponent();
            var _currentEmployees = PodgotovkaBaseEntities.GetContext().Emloyees.ToList();
            DGEmployees.ItemsSource = _currentEmployees.Where(u => u.IsActual == true).ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Emloyees));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var forRemoving = DGEmployees.SelectedItems.Cast<Emloyees>().ToList();
            if(MessageBox.Show($"Выдействительно хотите удалить след. {forRemoving.Count()} элементов?", "Внимание!",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    PodgotovkaBaseEntities.GetContext().Emloyees.RemoveRange(forRemoving);
                    PodgotovkaBaseEntities.GetContext().SaveChanges();
                    MessageBox.Show("Successfully");
                    var _currentEmployees = PodgotovkaBaseEntities.GetContext().Emloyees.ToList();
                    DGEmployees.ItemsSource = _currentEmployees.Where(u => u.IsActual == true).ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void ListBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ListViewPage());
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                PodgotovkaBaseEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                var _currentEmployees = PodgotovkaBaseEntities.GetContext().Emloyees.ToList();
                DGEmployees.ItemsSource = _currentEmployees.Where(u => u.IsActual == true).ToList();
            }
        }

        private void DBtn_Click(object sender, RoutedEventArgs e)
        {
            var _currentEmployees = PodgotovkaBaseEntities.GetContext().Emloyees.ToList();
            Emloyees employees = (sender as Button).DataContext as Emloyees;

             if(MessageBox.Show("Вы действительно хотите удаль следующий элемент?", "Внимание!",
                 MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    employees.IsActual = false;
                    PodgotovkaBaseEntities.GetContext().SaveChanges();
                    MessageBox.Show("Successfully");
                    DGEmployees.ItemsSource = _currentEmployees.Where(u => u.IsActual == true).ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
