using MuseumFund.Data;
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

namespace MuseumFund.Views
{
    /// <summary>
    /// Логика взаимодействия для FundCard.xaml
    /// </summary>
    public partial class FundCard : Page
    {
        public bool IsAdmin;
        public FundCard(Funds fund, bool isadmin)
        {
            App.fund = fund;
            IsAdmin = isadmin;
            InitializeComponent();
            if (IsAdmin == false)
                AddCardBtn.Visibility = Visibility.Hidden;
            GetInfoFundCard();
        }
        public async Task GetInfoFundCard()
        {
            ListCards.ItemsSource = await Cards.GetCards(App.fund.Name);
        }

        private void AddCardBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCardWindow acw = new AddCardWindow();
            acw.Show();
        }

        private void ListCards_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lst = ListCards.SelectedItem as Cards;
            ListMIInCardWindow lmiic = new ListMIInCardWindow(lst);
            lmiic.Show();
        }
    }
}
