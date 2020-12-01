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
    /// Interaction logic for TransferToVirtualAccountATM.xaml
    /// </summary>
    public partial class TransferToVirtualAccountATM : Page
    {

        public ModelViewCustomer1 customers1;
        public ModelViewVirtualAccount virtualAccount1;
        public ModelViewCustomer customers2;
        public ModelViewCustomerTransaction customersTransaction1;

        public TransferToVirtualAccountATM()
        {
            InitializeComponent();
            customers1 = new ModelViewCustomer1();
            virtualAccount1 = new ModelViewVirtualAccount();
            DGVA.ItemsSource = virtualAccount1.grabDatabase();
            customers2 = new ModelViewCustomer();
            customersTransaction1 = new ModelViewCustomerTransaction();
        }

        private void Button_Verify(object sender, RoutedEventArgs e)
        {

            int res = customers1.validateCustomerAccountID(txtCustomerID.Text);

            if (res == 1)
            {
                hidden1.Visibility = Visibility.Visible;
                txtVirtualAccountID.Visibility = Visibility.Visible;
                hidden2.Visibility = Visibility.Visible;
                txtAmountOfMoney.Visibility = Visibility.Visible;
                hidden3.Visibility = Visibility.Visible;

            }
            else
            {
                MessageBox.Show("Customer Account ID Invalid !");
            }



        }

        private void Button_Transfer(object sender, RoutedEventArgs e)
        {
            int res = virtualAccount1.transferVirtualAccount(txtVirtualAccountID.Text, txtAmountOfMoney.Text);

            if(res == 1)
            {

                int depositMoney = (Int32.Parse(txtAmountOfMoney.Text) * (-1));
                customers2.updateDepositCustomer(txtCustomerID.Text, depositMoney);
                customersTransaction1.insertTransaction(txtCustomerID.Text, "Transfer to Virtual Account", txtAmountOfMoney.Text);

                DGVA.ItemsSource = virtualAccount1.grabDatabase();
                MessageBox.Show("transfer to virtual account success !");
            }
            else
            {
                MessageBox.Show("Invalid Virtual Account ID");
            }
        }
    }
}
