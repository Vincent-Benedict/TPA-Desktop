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
using TPA_Desktop.PageView.PageATMMachine;

namespace TPA_Desktop.View
{
    /// <summary>
    /// Interaction logic for ATMMachine.xaml
    /// </summary>
    public partial class ATMMachine : Window
    {

        public Page currentPage;
        public MainWindow main;
        public ATMMachine()
        {
            InitializeComponent();

            currentPage = new HomeATMMachine();

            pageATMMachine.Content = currentPage;
        }

        private void Button_Home(object sender, RoutedEventArgs e)
        {
            currentPage = new HomeATMMachine();

            pageATMMachine.Content = currentPage;
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Button_Deposit(object sender, RoutedEventArgs e)
        {
            currentPage = new DepositMoneyATM();

            pageATMMachine.Content = currentPage;
        }

        private void Button_Transfer_ATM(object sender, RoutedEventArgs e)
        {
            currentPage = new TransferMoneyATM();

            pageATMMachine.Content = currentPage;
        }

        private void Button_Withdrawl(object sender, RoutedEventArgs e)
        {
            currentPage = new WithdrawlMoneyATM();

            pageATMMachine.Content = currentPage;
        }

        private void Button_Payments(object sender, RoutedEventArgs e)
        {
            currentPage = new PaymentsATM();

            pageATMMachine.Content = currentPage;
        }

        private void Button_Check_Transation(object sender, RoutedEventArgs e)
        {
            currentPage = new CustomerTransactionATM();

            pageATMMachine.Content = currentPage;
        }

        private void Button_Transfer_VA(object sender, RoutedEventArgs e)
        {
            currentPage = new TransferToVirtualAccountATM();

            pageATMMachine.Content = currentPage;
        }

        private void Button_CreditCardTransaction(object sender, RoutedEventArgs e)
        {
            currentPage = new CreditCardTransactionATM();

            pageATMMachine.Content = currentPage;
        }
    }
}
