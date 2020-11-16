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
    /// Interaction logic for PaymentsATM.xaml
    /// </summary>
    public partial class PaymentsATM : Page
    {

        public ModelViewCustomer customers1;
        public ModelViewCustomerPaymentsBill customersPaymentsBill1;
        public ModelCustomerTransaction customerTransaction1;
        public PaymentsATM()
        {
            InitializeComponent();
            customers1 = new ModelViewCustomer();
            customersPaymentsBill1 = new ModelViewCustomerPaymentsBill();
            customerTransaction1 = new ModelCustomerTransaction();
            DgUsers.ItemsSource = customersPaymentsBill1.grabDatabase();
        }

        private void Button_Pay(object sender, RoutedEventArgs e)
        {
            if (txtPulseOrElectricPulse.Text.Equals("Pulse") || txtPulseOrElectricPulse.Text.Equals("Electric Pulse"))
            {
                if (txtCashOrTransfer.Text.Equals("Cash"))
                {
                    int res = customersPaymentsBill1.pay(txtCustomerAccount.Text, txtPulseOrElectricPulse.Text, txtAmountOfMoney.Text);
                    if (res > 0)
                        customerTransaction1.insertTransaction(txtCustomerAccount.Text, "pay " + txtPulseOrElectricPulse.Text, txtAmountOfMoney.Text);
                }
                else if (txtCashOrTransfer.Text.Equals("Transfer"))
                {
                    int res = customersPaymentsBill1.pay(txtCustomerAccount.Text, txtPulseOrElectricPulse.Text, txtAmountOfMoney.Text);
                    if (res > 0)
                    {
                        customerTransaction1.insertTransaction(txtCustomerAccount.Text, "pay " + txtPulseOrElectricPulse.Text, txtAmountOfMoney.Text);
                        customers1.updateDepositCustomer(txtCustomerAccount.Text, (Int32.Parse(txtAmountOfMoney.Text)) * -1);
                    }

                }
                else
                {
                    MessageBox.Show("Please Input only Cash / Transfer");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please Input only Pulse / Electric Pulse");
                return;
            }


           
            DgUsers.ItemsSource = customersPaymentsBill1.grabDatabase();
            MessageBox.Show("Pay Success !");
        }

        private void Button_Verify(object sender, RoutedEventArgs e)
        {
            int rest = customers1.validateCustomerAccountID(txtCustomerAccount.Text);

            if (rest == 1)
            {
                int rest2 = customersPaymentsBill1.validateCustomerID(txtCustomerAccount.Text);

                if (rest2 == 1)
                {
                    hiddenText1.Visibility = Visibility.Visible;
                    txtPulseOrElectricPulse.Visibility = Visibility.Visible;
                    hiddenText2.Visibility = Visibility.Visible;
                    txtCashOrTransfer.Visibility = Visibility.Visible;
                    hiddenText3.Visibility = Visibility.Visible;
                    txtAmountOfMoney.Visibility = Visibility.Visible;
                    buttonPay.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("There are no bills in your Account !");
                }



            }
            else
            {
                MessageBox.Show("Invalid Customer Account ID !");
            }
        }
    }
}
