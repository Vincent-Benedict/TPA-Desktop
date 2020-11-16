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
using TPA_Desktop.MVVM;
using TPA_Desktop.PageView.PageTeller;

namespace TPA_Desktop.PageView.PageATMMachine
{
    /// <summary>
    /// Interaction logic for TransferMoneyATM.xaml
    /// </summary>
    public partial class TransferMoneyATM : Page
    {

        public ModelViewCustomer customers1;
        public ModelViewCustomerTransaction customersTransaction1;

        public TransferMoneyATM()
        {
            InitializeComponent();

            customers1 = new ModelViewCustomer();
            customersTransaction1 = new ModelViewCustomerTransaction();
            DgUsers.ItemsSource = customers1.grabDatabase();
        }

        private void Button_Verify_Account_ATM(object sender, RoutedEventArgs e)
        {
            int rest = customers1.validateCustomerAccountID(txtCustomerAccount.Text);

            if (rest == 1)
            {
                hiddenBlock1.Visibility = Visibility.Visible;
                hiddenBlock2.Visibility = Visibility.Visible;
                hiddenBlock3.Visibility = Visibility.Visible;
                hiddenBlock4.Visibility = Visibility.Visible;
                hiddenBlock5.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Invalid Customer Account ID !");
            }

        }

        private void Button_Transfer_ATM(object sender, RoutedEventArgs e)
        {
            int rest = customers1.validateCustomerAccountID(hiddenBlock2.Text);

            if (rest == 1)
            {
                customers1.transferMoney(txtCustomerAccount.Text, hiddenBlock2.Text, Int32.Parse(hiddenBlock4.Text));

                customersTransaction1.insertTransaction(txtCustomerAccount.Text, "Transfer ATM", hiddenBlock4.Text);
                customersTransaction1.insertTransaction(hiddenBlock2.Text, "Transfered by ATM", hiddenBlock4.Text);

                DgUsers.ItemsSource = customers1.grabDatabase();

                MessageBox.Show("Transfer Success !");
            }
            else
            {
                MessageBox.Show("Invalid Customer Account ID !");
            }


        }
    }
}
