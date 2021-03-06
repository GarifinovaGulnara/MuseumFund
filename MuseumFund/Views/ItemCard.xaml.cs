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
    /// Логика взаимодействия для ItemCard.xaml
    /// </summary>
    public partial class ItemCard : Page
    {
        public bool IsAdmin;
        public ItemCard(MusItems mi, bool isadmin)
        {
            App.mi = mi;
            IsAdmin = isadmin;
            InitializeComponent();
            if(IsAdmin == false)
            {
                EditMIBtn.Visibility = Visibility.Hidden;
                StatusCB.Visibility = Visibility.Hidden;
                NameMI.IsEnabled = false;
                DateCretionMI.IsEnabled = false;
                DateExactMI.IsEnabled = false;
                AuthorsMI.IsEnabled = false;
                DesMI.IsEnabled = false;
                FundMI.IsEnabled = false;
                CardMI.IsEnabled = false;
            }
            NameMI.Text = App.mi.Name;
            DateCretionMI.Text = App.mi.DateCreation;
            DateExactMI.IsChecked = App.mi.DateExact;
            AuthorsMI.Text = App.mi.Authors;
            DesMI.Text = App.mi.Description;
            StatusMI.Content = App.mi.Status;
            FundMI.SelectedItem = App.mi.Fund;
            CardMI.SelectedItem = App.mi.Card;
            StatusMI.Content = App.mi.Status;
            List<string> StatusList = new List<string>() { "прием на хранение", "передача на выставку", "возвращение с выставки", "списание", "в другом фонде", "в своём фонде"};
            StatusCB.ItemsSource = StatusList;
            GetCards();
            GetFunds();
        }

        private void EditMIBtn_Click(object sender, RoutedEventArgs e)
        {
            App.mi.Name = NameMI.Text;
            App.mi.DateCreation = DateCretionMI.Text;
            App.mi.DateExact = DateExactMI.IsChecked.Value;
            App.mi.Authors = AuthorsMI.Text;
            App.mi.Description = DesMI.Text;
            App.mi.Status = StatusCB.Text;
            App.mi.Fund = FundMI.Text;
            App.mi.Card = CardMI.Text;
            MusItems.EditMI();
        }

        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            var mi = App.mi;
            this.NavigationService.Navigate(new RequestPage(mi));
        }
        public async Task GetFunds()
        {
            FundMI.ItemsSource = (await Funds.GetFunds()).Select(x => x.Name).ToList();
        }
        public async Task GetCards()
        {
            CardMI.ItemsSource = (await Cards.GetAllCards()).Select(x => x.Name).ToList();
        }
    }
}
