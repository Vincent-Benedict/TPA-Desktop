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
    /// Interaction logic for CreateVirtualAccount.xaml
    /// </summary>
    public partial class CreateVirtualAccount : Page
    {

        public ModelViewCustomer1 customers1;
        public ModelViewVirtualAccount virtualAccount1;
        public CreateVirtualAccount()
        {
            InitializeComponent();
            customers1 = new ModelViewCustomer1();
            virtualAccount1 = new ModelViewVirtualAccount();
            DGVA.ItemsSource = virtualAccount1.grabDatabase();
        }

        private void Button_Verify_Account(object sender, RoutedEventArgs e)
        {
            int res = customers1.validateCustomerAccountID(txtCustomerAccountID.Text);

            if(res == 1)
            {
                int res2 = customers1.validateBusinessAccount(txtCustomerAccountID.Text);

                if(res2 == 1)
                {
                    Hidden1.Visibility = Visibility.Visible;
                    txtVirtualAccountName.Visibility = Visibility.Visible;
                    Hidden2.Visibility = Visibility.Visible;
                    txtVirtualAccountNumber.Visibility = Visibility.Visible;
                    Hidden3.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("Customer Account ID is not business account !");
                }

            }
            else
            {
                MessageBox.Show("Customer Account ID Invalid !");
            }

        }

        private void Button_Create(object sender, RoutedEventArgs e)
        {
            virtualAccount1.insertVirtualAccount(txtCustomerAccountID.Text, txtVirtualAccountName.Text, txtVirtualAccountNumber.Text);
            DGVA.ItemsSource = virtualAccount1.grabDatabase();
            MessageBox.Show("Create Virtual Account Success !");
        }
    }
}
