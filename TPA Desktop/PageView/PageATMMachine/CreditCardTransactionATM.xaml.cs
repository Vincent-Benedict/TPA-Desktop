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
    /// Interaction logic for CreditCardTransactionATM.xaml
    /// </summary>
    public partial class CreditCardTransactionATM : Page
    {
        public ModelViewCustomer1 customers1;
        public ModelViewCreditCard creditCard1;
        public ModelViewCreditCardTransaction creditCardTransaction1;

        public CreditCardTransactionATM()
        {
            InitializeComponent();
            customers1 = new ModelViewCustomer1();
            creditCard1 = new ModelViewCreditCard();
            creditCardTransaction1 = new ModelViewCreditCardTransaction();
        }

        private void Button_View(object sender, RoutedEventArgs e)
        {

            int res = customers1.validateCustomerAccountID(txtCustomerID.Text);

            if (res == 1)
            {
                int res2 = creditCard1.validateCardInCreditCard(txtCustomerID.Text);
                
                if(res2 == 1)
                {
                    int res3 = creditCard1.validateCreditCardTransaction(txtCustomerID.Text);

                    if(res3 > 0)
                    {
                        DGCreditCardTransaction.ItemsSource = creditCardTransaction1.grabDatabase(txtCustomerID.Text);
                    }
                    else
                    {
                        MessageBox.Show("You don't have any credit card transaction");
                    }
                }
                else
                {
                    MessageBox.Show("Your account don't have credit card");
                }

            }
            else
            {
                MessageBox.Show("Customer Account ID Invalid !");
            }

        }
    }
}
