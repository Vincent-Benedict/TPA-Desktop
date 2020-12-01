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
    /// Interaction logic for ExpensesItemRepair.xaml
    /// </summary>
    public partial class ExpensesItemRepair : Page
    {

        public ModelViewRequestExpenses listRequest;

        public ExpensesItemRepair()
        {
            InitializeComponent();
            listRequest = new ModelViewRequestExpenses();
            DGExpenses.ItemsSource = listRequest.grabDatabase();
        }

        private void Button_Approve(object sender, RoutedEventArgs e)
        {
            if (!txtREID.Text.Equals(""))
            {
                int x = listRequest.updateRequestApprove(txtREID.Text);
                DGExpenses.ItemsSource = listRequest.grabDatabase();

                if (x > 0)
                {
                    MessageBox.Show("Successfully Updated !");
                }
                else
                {
                    MessageBox.Show("Invalid requestExpensesID !");
                }
            }
            else
            {
                MessageBox.Show("Please Input Request Expenses ID !");
            }


        }

        private void Button_Reject(object sender, RoutedEventArgs e)
        {
            if (!txtREID.Text.Equals(""))
            {
                int x = listRequest.updateRequestReject(txtREID.Text);
                DGExpenses.ItemsSource = listRequest.grabDatabase();

                if (x > 0)
                {
                    MessageBox.Show("Successfully Updated !");
                }
                else
                {
                    MessageBox.Show("Invalid requestExpensesID !");
                }
            }
            else
            {
                MessageBox.Show("Please Input Request Expenses ID !");
            }
        }
    }
}
