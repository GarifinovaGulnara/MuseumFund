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
    /// Логика взаимодействия для ListMIInCardWindow.xaml
    /// </summary>
    public partial class ListMIInCardWindow : Window
    {
        public ListMIInCardWindow(Cards card)
        {
            App.card = card;
            InitializeComponent();
            GetInfo();
        }
        public async Task GetInfo()
        {
            ListMesItemsInCard.ItemsSource = await MusItems.GetMIInCard(App.card.Name);
        }
    }
}
