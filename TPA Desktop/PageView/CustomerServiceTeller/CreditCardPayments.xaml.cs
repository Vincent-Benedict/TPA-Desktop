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

namespace TPA_Desktop.PageView.CustomerServiceTeller
{
    /// <summary>
    /// Interaction logic for CreditCardPayments.xaml
    /// </summary>
    public partial class CreditCardPayments : Page
    {

        public ModelViewCreditCardPayments creditCardPayments;
        public ModelViewCustomerTransaction customerTransaction;

        public CreditCardPayments()
        {
            InitializeComponent();
            creditCardPayments = new ModelViewCreditCardPayments();
            customerTransaction = new ModelViewCustomerTransaction();
            CCPayments.ItemsSource = creditCardPayments.grabDatabase();
        }

        private void Button_Pay(object sender, RoutedEventArgs e)
        {
            if (txtPaymentsType.Text.Equals("Cash") || txtPaymentsType.Text.Equals("cash"))
            {
                creditCardPayments.pay(txtCreditCardPaymentsID.Text, txtAmountOfMoney.Text);
                CCPayments.ItemsSource = creditCardPayments.grabDatabaseWhere(txtCreditCardID.Text);
                MessageBox.Show("pay success !");
            }
            else if (txtPaymentsType.Text.Equals("Transfer") || txtPaymentsType.Text.Equals("transfer"))
            {
                String y = creditCardPayments.selectSingleCustomerID(txtCreditCardID.Text);
                customerTransaction.insertTransaction(y, "Transfer Credit Card", txtAmountOfMoney.Text);
                creditCardPayments.payTransfer(Int32.Parse(txtAmountOfMoney.Text), txtCreditCardID.Text);       
                creditCardPayments.pay(txtCreditCardPaymentsID.Text, txtAmountOfMoney.Text);
                CCPayments.ItemsSource = creditCardPayments.grabDatabaseWhere(txtCreditCardID.Text);
                MessageBox.Show("pay success !");
            }
            else
            {
                MessageBox.Show("Input Cash or Transfer in Payments Type !");
            }
        }

        private void Button_Verify(object sender, RoutedEventArgs e)
        {
            int res = creditCardPayments.validateCreditCardID(txtCreditCardID.Text);

            if (res == 1)
            {
                hidden1.Visibility = Visibility.Visible;
                txtAmountOfMoney.Visibility = Visibility.Visible;
                hidden2.Visibility = Visibility.Visible;
                txtCreditCardPaymentsID.Visibility = Visibility.Visible;
                hidden3.Visibility = Visibility.Visible;
                txtPaymentsType.Visibility = Visibility.Visible;
                hidden4.Visibility = Visibility.Visible;
                
                CCPayments.ItemsSource = creditCardPayments.grabDatabaseWhere(txtCreditCardID.Text);
            }
            else
            {
                MessageBox.Show("Credit Card ID invalid !");
            }
        }
    }
}
