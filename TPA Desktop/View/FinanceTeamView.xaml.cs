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
using TPA_Desktop.PageView.PageFinanceTeam;

namespace TPA_Desktop.View
{
    /// <summary>
    /// Interaction logic for FinanceTeamView.xaml
    /// </summary>
    public partial class FinanceTeamView : Window
    {


        public Page currentPage;
        public MainWindow main;
        public FinanceTeamView()
        {
            InitializeComponent();

            currentPage = new FinanceHome();

            pageFinance.Content = currentPage;
        }

       

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Button_Home(object sender, RoutedEventArgs e)
        {
            currentPage = new FinanceHome();

            pageFinance.Content = currentPage;
        }

        private void Button_Bank_Bills(object sender, RoutedEventArgs e)
        {
            currentPage = new BankBills();

            pageFinance.Content = currentPage;
        }

        private void Button_CustomerDepositInterest(object sender, RoutedEventArgs e)
        {
            currentPage = new CustomerDepositInterest();

            pageFinance.Content = currentPage;
        }

        private void Button_Annual(object sender, RoutedEventArgs e)
        {
            currentPage = new AnnualRentalPrice();

            pageFinance.Content = currentPage;
        }

        private void Button_CreditCard_Request(object sender, RoutedEventArgs e)
        {
            currentPage = new HandleCreditCard();

            pageFinance.Content = currentPage;
        }

        private void Button_Request(object sender, RoutedEventArgs e)
        {
            currentPage = new RequestBroken();

            pageFinance.Content = currentPage;
        }
    }
}
