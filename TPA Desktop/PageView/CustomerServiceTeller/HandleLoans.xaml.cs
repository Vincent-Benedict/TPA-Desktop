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
    /// Interaction logic for HandleLoans.xaml
    /// </summary>
    public partial class HandleLoans : Page
    {

        public ModelViewCustomer1 customers1;
        public ModelViewLoans loans;

        public HandleLoans()
        {
            InitializeComponent();
            customers1 = new ModelViewCustomer1();
            loans = new ModelViewLoans();
            DGLoans.ItemsSource = loans.grabDatabase();
        }

        private void Button_Verify(object sender, RoutedEventArgs e)
        {
            int res = customers1.validateCustomerAccountID(txtCustomerID.Text);

            if(res == 1)
            {
                hidden1.Visibility = Visibility.Visible;
                txtGuaranteeDocument.Visibility = Visibility.Visible;
                hidden2.Visibility = Visibility.Visible;
                txtReason.Visibility = Visibility.Visible;
                hidden3.Visibility = Visibility.Visible;
                txtTypeLoan.Visibility = Visibility.Visible;
                hidden4.Visibility = Visibility.Visible;
                txtAmountMoney.Visibility = Visibility.Visible;
                hidden5.Visibility = Visibility.Visible;

            }
            else
            {
                MessageBox.Show("Customer ID Invalid !");
            }

        }

        private void Button_Insert_Loans(object sender, RoutedEventArgs e)
        {

            if (txtGuaranteeDocument.Text.Equals(""))
            {
                MessageBox.Show("Fill Guarantee Document !");
            }
            else
            {
                if (txtReason.Text.Equals(""))
                {
                    MessageBox.Show("Fill Reason !");
                }
                else
                {
                    if (txtTypeLoan.Text.Equals("Individual"))
                    {
                        if(Int64.Parse(txtAmountMoney.Text) < 10000000 || Int64.Parse(txtAmountMoney.Text) > 1000000000)
                        {
                            MessageBox.Show("Amount of Money must be between 10000000 & 100000000");
                        }
                        else
                        {
                            loans.insertLoans(txtCustomerID.Text, txtGuaranteeDocument.Text, txtReason.Text, txtTypeLoan.Text, txtAmountMoney.Text);
                            DGLoans.ItemsSource = loans.grabDatabase();
                            MessageBox.Show("Inserted Individual Loans Succeed !");
                        }
                    }
                    else if (txtTypeLoan.Text.Equals("Business"))
                    {
                        
                        if (Int64.Parse(txtAmountMoney.Text) < 10000000 || Int64.Parse(txtAmountMoney.Text) > 5000000000)
                        {
                            MessageBox.Show("Amount of Money must be between 10000000 & 5000000000");
                        }
                        else
                        {
                            loans.insertLoans(txtCustomerID.Text, txtGuaranteeDocument.Text, txtReason.Text, txtTypeLoan.Text, txtAmountMoney.Text);
                            DGLoans.ItemsSource = loans.grabDatabase();
                            MessageBox.Show("Inserted Business Loans Succeed !");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Fill Type of Loan with Individual / Business");
                    }

                }
            }

        }
    }
}
