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

namespace TPA_Desktop.PageView.PageFinanceTeam
{
    /// <summary>
    /// Interaction logic for BankRequestExpenses.xaml
    /// </summary>
    public partial class BankRequestExpenses : Page
    {

        public ModelViewBankExpenses bankExpenses;

        public BankRequestExpenses()
        {
            InitializeComponent();
            bankExpenses = new ModelViewBankExpenses();
            DGExpenses.ItemsSource = bankExpenses.grabDatabase();

        }

        private void Button_Approve(object sender, RoutedEventArgs e)
        {
            if (!txtRequestExpensesID.Text.Equals(""))
            {
                int res = bankExpenses.updateRequestApprove(txtRequestExpensesID.Text);

                if(res > 0)
                {
                    DGExpenses.ItemsSource = bankExpenses.grabDatabase();
                    MessageBox.Show("Successfully Updated !");
                }
                else
                {
                    MessageBox.Show("Invalid Request Expenses ID !");
                }
            }
            else
            {
                MessageBox.Show("Please Input Request Expenses ID");
            }
        }

        private void Button_Reject(object sender, RoutedEventArgs e)
        {
            if (!txtRequestExpensesID.Text.Equals(""))
            {
                int res = bankExpenses.updateRequestReject(txtRequestExpensesID.Text);

                if (res > 0)
                {
                    DGExpenses.ItemsSource = bankExpenses.grabDatabase();
                    MessageBox.Show("Successfully Updated !");
                }
                else
                {
                    MessageBox.Show("Invalid Request Expenses ID !");
                }
            }
            else
            {
                MessageBox.Show("Please Input Request Expenses ID");
            }
        }
    }
}
