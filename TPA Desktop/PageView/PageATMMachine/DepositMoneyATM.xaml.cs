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
    /// Interaction logic for DepositMoneyATM.xaml
    /// </summary>
    public partial class DepositMoneyATM : Page
    {
        public ModelViewCustomer customers1;
        public ModelViewCustomerTransaction customersTransaction1;
        public DepositMoneyATM()
        {
            InitializeComponent();
            customers1 = new ModelViewCustomer();
            customersTransaction1 = new ModelViewCustomerTransaction();
            DgUsers.ItemsSource = customers1.grabDatabase();
        }

        private void Button_Deposit(object sender, RoutedEventArgs e)
        {

            int depositMoney = Int32.Parse(txtDepositMoney.Text);
            int result = customers1.updateDepositCustomer(txtCustomerID.Text, depositMoney);


            if (result == 0)
            {
                MessageBox.Show("There is no Customer Account Like That !");
                return;
            }
            else
            {
                customersTransaction1.insertTransaction(txtCustomerID.Text, "Deposit using ATM", txtDepositMoney.Text);  
            }


            DgUsers.ItemsSource = customers1.grabDatabase();
            MessageBox.Show("Deposit Success !");
        }
    }
}
