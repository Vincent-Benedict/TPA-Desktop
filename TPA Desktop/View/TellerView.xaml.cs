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
using TPA_Desktop.PageView;
using TPA_Desktop.PageView.CustomerServiceTeller;
using TPA_Desktop.PageView.PageTeller;

namespace TPA_Desktop.View
{
    /// <summary>
    /// Interaction logic for TellerView.xaml
    /// </summary>
    public partial class TellerView : Window
    {

        public Page currentPage;
        public MainWindow main;

        public TellerView()
        {
            InitializeComponent();
            currentPage = new HomeTeller();

            pageTeller.Content = currentPage;
            
        }

        private void Button_Home(object sender, RoutedEventArgs e)
        {
            currentPage = new HomeTeller();
            pageTeller.Content = currentPage;
        }

        private void Button_Deposit(object sender, RoutedEventArgs e)
        {
            currentPage = new DepositMoney();
            pageTeller.Content = currentPage;
        }

        private void Button_Transfer(object sender, RoutedEventArgs e)
        {
            currentPage = new TransferMoney();
            pageTeller.Content = currentPage;
        }

        private void Button_Payments(object sender, RoutedEventArgs e)
        {
            currentPage = new PaymentsTeller();
            pageTeller.Content = currentPage;
        }

        private void Button_Withdrawl(object sender, RoutedEventArgs e)
        {
            currentPage = new WithdrawlMoney();
            pageTeller.Content = currentPage;
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Button_Request(object sender, RoutedEventArgs e)
        {
            currentPage = new RequestBroken();
            pageTeller.Content = currentPage;
        }
    }
}
