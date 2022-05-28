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
        public DataGridPage()
        {
            InitializeComponent();
            DGEmployees.ItemsSource = PodgotovkaBaseEntities.GetContext().Emloyees.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ListViewPage());
        }
    }
}
