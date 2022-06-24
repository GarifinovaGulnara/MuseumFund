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
    /// Логика взаимодействия для FundsPage1xaml.xaml
    /// </summary>
    public partial class FundsPage1xaml : Page
    {
        public bool IsAdmin;
        public FundsPage1xaml(bool id)
        {
            IsAdmin = id;
            InitializeComponent();
            if (IsAdmin == true)
            {
                AddFundBtn.Visibility = Visibility.Visible;
            }
            else
            {
                AddFundBtn.Visibility = Visibility.Hidden;
            }
        }
    }
}
