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
    /// Логика взаимодействия для ProfilPage.xaml
    /// </summary>
    public partial class ProfilPage : Page
    {
        public ProfilPage()
        {
            InitializeComponent();
            SaveChangeBtn.Visibility = Visibility.Hidden;
            FIOTB.Text = App.user.Surname + " " + App.user.Name + " " + App.user.Patronic;
            LogInTB.Text = App.user.Login;
            PassTB.Text = App.user.Pass;
            DataContext = App.user;
        }

        private void SaveChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            FIOTB.IsEnabled = false;
            LogInTB.IsEnabled = false;
            PassTB.IsEnabled = false;
            SaveChangeBtn.Visibility = Visibility.Hidden;
            string[] fio = FIOTB.Text.Split(' ');
            App.user.Surname = fio[0];
            App.user.Name = fio[1];
            App.user.Patronic = fio[2];
            App.user.Login = LogInTB.Text;
            App.user.Pass = PassTB.Text;
            Users.EditProfile();
        }

        private void EditProfilBtn_Click(object sender, RoutedEventArgs e)
        {
            FIOTB.IsEnabled = true;
            LogInTB.IsEnabled = true;
            PassTB.IsEnabled = true;
            SaveChangeBtn.Visibility = Visibility.Visible;
        }
    }
}
