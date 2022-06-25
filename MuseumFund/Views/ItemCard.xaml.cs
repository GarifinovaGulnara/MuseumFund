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
            FundMI.SelectedItem = App.mi.Fund;
            CardMI.SelectedItem = App.mi.Card;
        }

        private void AddMIBtn_Click(object sender, RoutedEventArgs e)
        {
            App.mi.Name = NameMI.Text;
            App.mi.DateCreation = DateCretionMI.Text;
            App.mi.DateExact = DateExactMI.IsChecked.Value;
            App.mi.Authors = AuthorsMI.Text;
            App.mi.Description = DesMI.Text;
            App.mi.Fund = FundMI.Text;
            App.mi.Card = CardMI.Text;
            MusItems.EditMI();
        }
    }
}
