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
    /// Interaction logic for CreateMainAccount.xaml
    /// </summary>
    public partial class CreateMainAccount : Page
    {

        public ModelViewCustomer1 customers1;
        public ModelViewCustomerDetail customerDetail;
        public CreateMainAccount()
        {
            InitializeComponent();
            customers1 = new ModelViewCustomer1();
            customerDetail = new ModelViewCustomerDetail();
            DgUsers.ItemsSource = customers1.grabDatabase();
        }

        private void Button_Next(object sender, RoutedEventArgs e)
        {
            if(AccountType.Text.Equals("Regular Account") || AccountType.Text.Equals("regular account") ||
                AccountType.Text.Equals("Business Account") || AccountType.Text.Equals("Business account"))
            {
                HiddenInitialDeposit.Visibility = Visibility.Visible;
                txtHiddenInitialDeposit.Visibility = Visibility.Visible;
                buttonCreateAccount.Visibility = Visibility.Visible;
            }else if(AccountType.Text.Equals("Student Account") || AccountType.Text.Equals("student account"))
            {

                HiddenInitialDeposit.Visibility = Visibility.Visible;
                txtHiddenInitialDeposit.Visibility = Visibility.Visible;
                HiddenLink.Visibility = Visibility.Visible;
                txtHiddenLink.Visibility = Visibility.Visible;
                buttonCreateAccount.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Fill Student Account / Regular Account / Business Account");
            }
        }

        private void Button_Create_Account(object sender, RoutedEventArgs e)
        {


            String x = "CU";
            if (AccountType.Text.Equals("Regular Account") || AccountType.Text.Equals("regular account") ||
                AccountType.Text.Equals("Business Account") || AccountType.Text.Equals("Business account"))
            {
                
                if(customers1.grabDatabase().Count() < 10)
                {
                    x = x + "00";
                    x += (customers1.grabDatabase().Count()+1).ToString();
                } else if(customers1.grabDatabase().Count() < 100)
                {
                    x = x + "0";
                    x += (customers1.grabDatabase().Count() + 1).ToString();
                }
                else
                {
                    x += (customers1.grabDatabase().Count() + 1).ToString();
                }
                customers1.insertNewRegularCustomerAccount(x, txtName.Text, txtHiddenInitialDeposit.Text, AccountType.Text);
            }
            else if (AccountType.Text.Equals("Student Account") || AccountType.Text.Equals("student account"))
            {
                int res = customers1.validateCustomerAccountID(txtHiddenLink.Text);

                if(res == 1)
                {
                    
                    if (customers1.grabDatabase().Count() < 10)
                    {
                        x = x + "00";
                        x += (customers1.grabDatabase().Count() + 1).ToString();
                    }
                    else if (customers1.grabDatabase().Count() < 100)
                    {
                        x = x + "0";
                        x += (customers1.grabDatabase().Count() + 1).ToString();
                    }
                    else
                    {
                        x += (customers1.grabDatabase().Count() + 1).ToString();
                    }
                    customers1.insertNewRegularCustomerAccount(x, txtName.Text, txtHiddenInitialDeposit.Text, AccountType.Text, txtHiddenLink.Text);
                }
                else
                {
                    MessageBox.Show("invalid customer account !");
                    return;
                }
                
            }

            MessageBox.Show("Create Customer Successfully !");

            customerDetail.insertCustomerDetail(txtName.Text, txtEmail.Text, txtPhoneNumber.Text, txtAddress.Text, x);

            DgUsers.ItemsSource = customers1.grabDatabase();


        }
    }
}
