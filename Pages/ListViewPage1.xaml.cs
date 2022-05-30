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
    /// Логика взаимодействия для ListViewPage1.xaml
    /// </summary>
    public partial class ListViewPage1 : Page
    {
        public ListViewPage1()
        {
            InitializeComponent();
            ActualCheck.IsChecked = false;
            Update();
        }

        private void Update()
        {
            var currentTour = PodgotovkaBaseEntities.GetContext().Tour.ToList();
            currentTour = currentTour.Where(u => u.Name.ToLower().Contains(SearchTB.Text.ToLower())).ToList();
            if (ActualCheck.IsChecked.Value)
                currentTour = currentTour.Where(p => p.IsActual).ToList();
            LViewTour.ItemsSource = currentTour;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new DataGridPage());
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void ActualCheck_Checked(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
