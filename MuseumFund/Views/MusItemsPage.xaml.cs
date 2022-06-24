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
    /// Логика взаимодействия для MusItemsPage.xaml
    /// </summary>
    public partial class MusItemsPage : Page
    {
        public bool IsAdmin;
        public MusItemsPage(bool id)
        {
            IsAdmin = id;
            InitializeComponent();
            if(IsAdmin == false)
            {
                AddMusItemBtn.Visibility = Visibility.Hidden;
            }
            else
            {
                AddMusItemBtn.Visibility = Visibility.Visible;
            }
        }
    }
}
