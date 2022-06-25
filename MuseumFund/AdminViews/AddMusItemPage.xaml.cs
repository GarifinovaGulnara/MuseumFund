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

namespace MuseumFund.AdminViews
{
    /// <summary>
    /// Логика взаимодействия для AddMusItemPage.xaml
    /// </summary>
    public partial class AddMusItemPage : Page
    {
        public AddMusItemPage()
        {
            InitializeComponent();
        }

        private void AddMIBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NameMI.Text == " " || DateCretionMI.Text == " " || DateExactMI == null || AuthorsMI.Text == " " || FundMI == null)
            {
                MessageBox.Show("error");
            }
            else
            {
                MusItems mi = new MusItems(NameMI.Text, DateCretionMI.Text, DateExactMI.IsChecked.Value, AuthorsMI.Text, DesMI.Text, FundMI.Text, CardMI.Text);
                MusItems.AddMI(mi);
                MessageBox.Show("");
                NameMI.Text = "Название предмета";
                DateCretionMI.Text = "Дата создания";
                DateExactMI.IsChecked = null;
                AuthorsMI.Text = "Авторы";
                DesMI.Text = "Описание";
                FundMI.Text = "";
                CardMI.Text = "";
            }
        }
    }
}
