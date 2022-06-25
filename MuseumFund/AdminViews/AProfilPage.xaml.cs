using MuseumFund.Windows;
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

namespace MuseumFund.AdminViews
{
    /// <summary>
    /// Логика взаимодействия для AProfilPage.xaml
    /// </summary>
    public partial class AProfilPage : Page
    {
        public AProfilPage()
        {
            InitializeComponent();
        }

        private void SaveChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            AddSupervisorWindow asw = new AddSupervisorWindow();
            asw.Show();
        }
    }
}
