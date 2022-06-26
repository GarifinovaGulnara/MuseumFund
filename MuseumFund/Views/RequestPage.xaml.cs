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
    /// Логика взаимодействия для RequestPage.xaml
    /// </summary>
    public partial class RequestPage : Page
    {
        public RequestPage(MusItems mi)
        {
            App.mi = mi;
            InitializeComponent();
            NameMI.Text = App.mi.Name;
            NameOrganization.Text = App.user.NameOrganization;
        }

        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NameMI.Text == "" || NameOrganization.Text == "" || AddressOrg.Text == "" || Phone.Text == "" || FIOKonFace.Text == "" || AddressEx.Text == "" || NameEx.Text == "" || DateBegin.Text == "" || DateEnd.Text == "")
            {
                MessageBox.Show("Введите все данные");
            }
            else
            {
                Request req = new Request(App.user.Name, NameMI.Text, NameOrganization.Text, AddressOrg.Text, Phone.Text, FIOKonFace.Text, AddressEx.Text, NameEx.Text, DateBegin.Text, DateEnd.Text, App.user.Login);
                Request.AddReq(req);
                MessageBox.Show("Заявка отправлена");
            }
        }
    }
}
