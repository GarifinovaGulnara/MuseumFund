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
    /// Логика взаимодействия для AddFundWindow.xaml
    /// </summary>
    public partial class AddFundWindow : Window
    {
        public AddFundWindow()
        {
            InitializeComponent();
            GetInfo();
        }

        private void AddFundBtn_Click(object sender, RoutedEventArgs e)
        {
            if(NameFund.Text == " " || SupervisorFund.SelectedItem == null)
            {
                MessageBox.Show("error");
            }
            else
            {
                Funds fund = new Funds(NameFund.Text, SupervisorFund.Text);
                Funds.AddFund(fund);
                NameFund.Text = "Название фонда";
            }
        }
        public async Task GetInfo()
        {
            SupervisorFund.ItemsSource = (await Supervisor.GetSupVis()).Select(X => X.FIO).ToList();
        }
    }
}
