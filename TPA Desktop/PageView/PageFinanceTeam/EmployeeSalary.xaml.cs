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
    /// Interaction logic for EmployeeSalary.xaml
    /// </summary>
    public partial class EmployeeSalary : Page
    {

        public ModelViewEmployeeSalaryRequest employeeRequestSalary;

        public EmployeeSalary()
        {
            InitializeComponent();
            employeeRequestSalary = new ModelViewEmployeeSalaryRequest();
            DGSalaryRequest.ItemsSource = employeeRequestSalary.grabDatabase();
        }

        private void Button_Approve(object sender, RoutedEventArgs e)
        {
            if (!txtEmployeeID.Text.Equals(""))
            {
                int res = employeeRequestSalary.validateRequestSalary(txtEmployeeID.Text);

                if(res == 1)
                {
                    int x = 0;
                    x = employeeRequestSalary.updateSalaryApprove(txtEmployeeID.Text);
                    DGSalaryRequest.ItemsSource = employeeRequestSalary.grabDatabase();

                    if (x > 0)
                    {
                        MessageBox.Show("Successfully Updated !");
                    }
                    else
                    {
                        MessageBox.Show("Invalid Employee ID Request");
                    }

                }
                else
                {
                    MessageBox.Show("Employee ID invalid !");
                }
            }
            else
            {
                MessageBox.Show("Please Input Employee ID !");
            }
        }

        private void Reject_Approve(object sender, RoutedEventArgs e)
        {

            if (!txtEmployeeID.Text.Equals(""))
            {
                int res = employeeRequestSalary.validateRequestSalary(txtEmployeeID.Text);

                if (res == 1)
                {
                    int x = 0;
                    x = employeeRequestSalary.updateSalaryReject(txtEmployeeID.Text);
                    DGSalaryRequest.ItemsSource = employeeRequestSalary.grabDatabase();

                    if (x > 0)
                    {
                        MessageBox.Show("Successfully Updated !");
                    }
                    else
                    {
                        MessageBox.Show("Invalid Employee ID Request");
                    }

                }
                else
                {
                    MessageBox.Show("Employee ID invalid !");
                }
            }
            else
            {
                MessageBox.Show("Please Input Employee ID !");
            }







        }
    }
}
