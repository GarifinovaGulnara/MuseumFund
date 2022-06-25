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
    /// Логика взаимодействия для AddSupervisorWindow.xaml
    /// </summary>
    public partial class AddSupervisorWindow : Window
    {
        public AddSupervisorWindow()
        {
            InitializeComponent();
        }

        private void AddSupervisorBtn_Click(object sender, RoutedEventArgs e)
        {
            Supervisor sv = new Supervisor(NameSupervisor.Text);
            Supervisor.AddSupVis(sv);
            MessageBox.Show("хранитель добавлен");
            NameSupervisor.Text = "ФИО хранителя фонда";
        }
    }
}
