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
using TPA_Desktop.PageView.PageTeller;

namespace TPA_Desktop.PageView.CustomerServiceTeller
{
    /// <summary>
    /// Interaction logic for BlockedAccount.xaml
    /// </summary>
    public partial class BlockedAccount : Page
    {
        public ModelViewCustomer1 customers1;
        public BlockedAccount()
        {
            InitializeComponent();

            customers1 = new ModelViewCustomer1();
            DgUsers.ItemsSource = customers1.grabDatabase();


        }

        private void Button_Blocked_Account(object sender, RoutedEventArgs e)
        {
            int res = customers1.validateCustomerAccountID(txtCustomerAccountIDBlocked.Text);

            if(res == 1)
            {
                customers1.blockedAccount(txtCustomerAccountIDBlocked.Text);
                DgUsers.ItemsSource = customers1.grabDatabase();
                MessageBox.Show("Blocked Account Success !");
            }
            else
            {
                MessageBox.Show("Invalid Customer Account !");
            }
        }

        private void Button_Verify_Account(object sender, RoutedEventArgs e)
        {
            int res = customers1.validateCustomerAccountID(txtCustomerAccountID.Text);
            if(res == 1)
            {
                hiddenText1.Visibility = Visibility.Visible;
                txtCustomerAccountIDBlocked.Visibility = Visibility.Visible;
                hiddenText2.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Invalid Customer Account !");
            }

        }
    }
}
