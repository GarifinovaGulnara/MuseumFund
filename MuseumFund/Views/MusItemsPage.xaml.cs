using MuseumFund.AdminViews;
using MuseumFund.Data;
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

namespace MuseumFund.Views
{
    /// <summary>
    /// Логика взаимодействия для MusItemsPage.xaml
    /// </summary>
    public partial class MusItemsPage : Page
    {
        public bool IsAdmin;
        public MusItemsPage(bool id)
        {
            IsAdmin = id;
            InitializeComponent();
            if(IsAdmin == false)
            {
                AddMusItemBtn.Visibility = Visibility.Hidden;
            }
            else
            {
                AddMusItemBtn.Visibility = Visibility.Visible;
            }
            GetInfoMIAsync();
        }
        public async Task GetInfoMIAsync()
        {
            ListMesItems.ItemsSource = await MusItems.GetMI();
        }
        public async Task GetSearchList()
        {
            ListMesItems.ItemsSource = await MusItems.SearchList(SearchTB.Text);
        }
        private void AddMusItemBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddMusItemPage());
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            GetSearchList();
        }

        private void ListMesItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lst = ListMesItems.SelectedItem as MusItems;
            this.NavigationService.Navigate(new ItemCard(lst, IsAdmin));
        }
    }
}
