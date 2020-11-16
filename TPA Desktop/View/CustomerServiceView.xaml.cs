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
using TPA_Desktop.PageView.CustomerServiceTeller;

namespace TPA_Desktop.View
{
    /// <summary>
    /// Interaction logic for CustomerServiceView.xaml
    /// </summary>
    public partial class CustomerServiceView : Window
    {

        public Page currentPage;
        public MainWindow main;

        public CustomerServiceView()
        {
            InitializeComponent();

            currentPage = new HomeCustomerService();

            pageCustomerService.Content = currentPage;

        }

        private void Button_Home(object sender, RoutedEventArgs e)
        {
            currentPage = new HomeCustomerService();

            pageCustomerService.Content = currentPage;
        }

        private void Button_Credit_Hor(object sender, RoutedEventArgs e)
        {
            currentPage = new CreateHOC();

            pageCustomerService.Content = currentPage;
        }

        private void Button_Create_Main_Account(object sender, RoutedEventArgs e)
        {
            currentPage = new CreateMainAccount();

            pageCustomerService.Content = currentPage;
        }

        private void Button_Check_Transaction(object sender, RoutedEventArgs e)
        {
            currentPage = new CheckCustomerTransaction();

            pageCustomerService.Content = currentPage;
        }

        private void Button_BlockedAccount(object sender, RoutedEventArgs e)
        {
            currentPage = new BlockedAccount();

            pageCustomerService.Content = currentPage;
        }

        private void Button_CreditCard(object sender, RoutedEventArgs e)
        {
            currentPage = new CreditCard();

            pageCustomerService.Content = currentPage;
        }

        private void Button_Credit_Card_Payments(object sender, RoutedEventArgs e)
        {
            currentPage = new CreditCardPayments();

            pageCustomerService.Content = currentPage;
        }

        private void Button_Slip_Credit_Card(object sender, RoutedEventArgs e)
        {
            currentPage = new CreditCardSlip();

            pageCustomerService.Content = currentPage;
        }

        private void Button_Log_Out(object sender, RoutedEventArgs e)
        {
            main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Button_Create_VA(object sender, RoutedEventArgs e)
        {
            currentPage = new CreateVirtualAccount();

            pageCustomerService.Content = currentPage;
        }

        private void Button_Money_Loans(object sender, RoutedEventArgs e)
        {
            currentPage = new HandleLoans();

            pageCustomerService.Content = currentPage;
        }

        private void Button_Report(object sender, RoutedEventArgs e)
        {
            currentPage = new RequestBroken();

            pageCustomerService.Content = currentPage;
        }
    }
}
