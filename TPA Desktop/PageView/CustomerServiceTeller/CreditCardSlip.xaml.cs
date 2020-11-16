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
    /// Interaction logic for CreditCardSlip.xaml
    /// </summary>
    public partial class CreditCardSlip : Page
    {
        public ModelViewCreditCardPayments creditCardPayments;
        public ModelViewCustomerTransaction customerTransaction;
        public CreditCardSlip()
        {
            InitializeComponent();
            creditCardPayments = new ModelViewCreditCardPayments();
            customerTransaction = new ModelViewCustomerTransaction();
            CCTransaction.ItemsSource = creditCardPayments.grabDatabase();
        }

        private void Button_Generate(object sender, RoutedEventArgs e)
        {
            int res = creditCardPayments.validateCreditCardID(txtCreditCardID.Text);

            if (res == 1)
            {
                CCTransaction.ItemsSource = creditCardPayments.grabDatabaseWhere(txtCreditCardID.Text);
            }
            else
            {
                MessageBox.Show("Credit Card ID invalid !");
            }
        }
    }
}
