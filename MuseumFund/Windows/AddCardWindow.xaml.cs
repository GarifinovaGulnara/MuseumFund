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
using System.Windows.Shapes;

namespace MuseumFund.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddCardWindow.xaml
    /// </summary>
    public partial class AddCardWindow : Window
    {
        public AddCardWindow()
        {
            InitializeComponent();
            GetFunds();
        }

        private void AddCardBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NameCard.Text == "" || FundCard.Text == "")
                MessageBox.Show("error");
            else
            {
                Cards card = new Cards(NameCard.Text, FundCard.Text);
                Cards.AddCard(card);
                MessageBox.Show("картотека добавлена");
            }
        }

        public async Task GetFunds()
        {
            FundCard.ItemsSource = (await Funds.GetFunds()).Select(x => x.Name).ToList();
        }
    }
}
