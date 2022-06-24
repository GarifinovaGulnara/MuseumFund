using MuseumFund.AdminViews;
using MuseumFund.Views;
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

namespace MuseumFund.Windows
{
    /// <summary>
    /// Логика взаимодействия для AppWindow.xaml
    /// </summary>
    public partial class AppWindow : Window
    {
        public bool IsAdmin;
        public AppWindow(bool id)
        {
            IsAdmin = id;
            InitializeComponent();
            if (IsAdmin == false)
            {
                MainFrame.Navigate(new ProfilPage());
            }
            else
            {
                MainFrame.Navigate(new AProfilPage());
            }
        }

        private void ProfilBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsAdmin == false)
            {
                MainFrame.Navigate(new ProfilPage());
            }
            else
            {
                MainFrame.Navigate(new AProfilPage());
            }
        }

        private void FundsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsAdmin == false)
            {
                MainFrame.Navigate(new FundsPage1xaml(false));
            }
            else
            {
                MainFrame.Navigate(new FundsPage1xaml(true));
            }
        }

        private void MuseumItemsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsAdmin == false)
            {
                MainFrame.Navigate(new MusItemsPage(false));
            }
            else
            {
                MainFrame.Navigate(new MusItemsPage(true));
            }
        }
    }
}
