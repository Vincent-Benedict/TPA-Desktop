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

namespace TPA_Desktop.PageView.CustomerServiceTeller
{
    /// <summary>
    /// Interaction logic for CreditCard.xaml
    /// </summary>
    public partial class CreditCard : Page
    {
        public ModelViewCustomer customers;
        public ModelViewCreditCardRequest creditCardRequest;
        public ModelViewCreditCard creditCardModel;
        
        public CreditCard()
        {
            InitializeComponent();
            creditCardRequest = new ModelViewCreditCardRequest();
            creditCardModel = new ModelViewCreditCard();
            customers = new ModelViewCustomer();
            requestCreditCard.ItemsSource = creditCardRequest.grabDatabase();
            creditCard.ItemsSource = creditCardModel.grabDatabase();
        }

        private void Button_request(object sender, RoutedEventArgs e)
        {
            int res = customers.validateCustomerAccountID(txtCustomerID.Text);

            if(res == 1)
            {
                creditCardRequest.insertCreditCardRequest(txtCustomerID.Text, txtFamilyCardID.Text, txtIdentityCardID.Text);
                requestCreditCard.ItemsSource = creditCardRequest.grabDatabase();
                MessageBox.Show("Insert Request Successfully");
            }
            else
            {
                MessageBox.Show("Invalid Customer ID");
            }


        }

        private void Button_Create(object sender, RoutedEventArgs e)
        {

            int y = creditCardModel.validateCreditCardRequestID(txtRequestCreditCardID.Text);

            if(y == 1) 
            {
                if (txtCreditCardType.Text.Equals(""))
                {
                    MessageBox.Show("Input Credit Card Type Like MasterCard / Visa !");
                    return;
                }

                String x = creditCardModel.grabData(txtRequestCreditCardID.Text);

                //MessageBox.Show(x);

                creditCardModel.insertCreditCard(x, txtCreditCardType.Text);
                creditCardRequest.updateActiveAccount(txtRequestCreditCardID.Text);
                requestCreditCard.ItemsSource = creditCardRequest.grabDatabase();
                creditCard.ItemsSource = creditCardModel.grabDatabase();

                MessageBox.Show("Credit Card Created !");
            }
            else
            {
                MessageBox.Show("Not Approved Yet !");
            }

            

        }
    }
}
