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

namespace MuseumFund
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginAuth.Text == "" || PassAuth.Password == "")
            {
                MessageBox.Show("Введите все данные");
            }
            else
            {
                Users us = new Users(LoginAuth.Text, PassAuth.Password);
                Users.LogInUser(us);
                if (App.user.IsAdmin == true)
                {
                    MessageBox.Show("Приветсвуем, Администратор");
                    AppWindow mw = new AppWindow(true);
                    mw.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Успешный вход");
                    AppWindow mw = new AppWindow(false);
                    mw.Show();
                    this.Close();
                }
            }
        }

        private void LogUpBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NameReg.Text == "" || SurnameReg.Text == "" || PatronicReg.Text == "" || OrganizationName.Text == "" || LoginReg.Text == "" || PassReg.Password == "")
            {
                MessageBox.Show("Введите все данные");
            }
            else
            {
                Users us = new Users(SurnameReg.Text, NameReg.Text, PatronicReg.Text, OrganizationName.Text, LoginReg.Text, PassReg.Password, false);
                Users.AddUser(us);
                MessageBox.Show("Вы зарегистрировались!");
                AppWindow mw = new AppWindow(us.IsAdmin);
                mw.Show();
                this.Close();
                App.user = us;
            }
        }
    }
}
