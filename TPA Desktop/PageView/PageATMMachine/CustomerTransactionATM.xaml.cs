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
    /// Interaction logic for CustomerTransactionATM.xaml
    /// </summary>
    public partial class CustomerTransactionATM : Page
    {
        public ModelViewCustomerTransaction customerTransaction;
        public ModelViewCustomer customer;
        public CustomerTransactionATM()
        {
            InitializeComponent();
            customerTransaction = new ModelViewCustomerTransaction();
            
            customer = new ModelViewCustomer();
        }

        private void Button_Check_ATM(object sender, RoutedEventArgs e)
        {
            int res = customer.validateCustomerAccountID(customerID.Text);
            if (res == 1)
            {
                if (customerTransaction.grabDatabase(customerID.Text).Count == 0)
                {
                    MessageBox.Show("You didn't do transaction !");
                    return;
                }
                DgUsers.ItemsSource = customerTransaction.grabDatabase(customerID.Text);
            }
            else
            {
                MessageBox.Show("Invalid Customer Account !");
            }

        }
    }
}
