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

namespace TPA_Desktop.PageView.HumanResourceManagementTeam
{
    /// <summary>
    /// Interaction logic for HRMManageSalary.xaml
    /// </summary>
    public partial class HRMManageSalary : Page
    {

        public ModelViewEmployeeSalary employeeSalary;
        public ModelViewEmployeeSalaryRequest employeeRequestSalary;
        public ModelViewEmployee employee;

        public HRMManageSalary()
        {
            InitializeComponent();

            employeeSalary = new ModelViewEmployeeSalary();
            employeeRequestSalary = new ModelViewEmployeeSalaryRequest();
            employee = new ModelViewEmployee();


            DGEmployee.ItemsSource = employeeSalary.grabDatabase();
            DGSalaryRequest.ItemsSource = employeeRequestSalary.grabDatabase();
        }

        private void Button_Request(object sender, RoutedEventArgs e)
        {
            if (!txtEmployeeID.Text.Equals(""))
            {

                if (!txtNewSalary.Text.Equals(""))
                {
                    int res = employee.validateEmployeeID(txtEmployeeID.Text);

                    if(res == 1)
                    {
                        employeeRequestSalary.insertSalaryRequest(txtEmployeeID.Text, txtNewSalary.Text);
                        
                        DGSalaryRequest.ItemsSource = employeeRequestSalary.grabDatabase();
                     
                        MessageBox.Show("Requested Success !");
                    }
                    else
                    {
                        MessageBox.Show("EmployeeID not valid !");
                    }

                }
                else
                {
                    MessageBox.Show("Please Input New Salary");
                }

            }
            else
            {
                MessageBox.Show("Please Input EmployeeID");
            }

        }

        private void Button_Update(object sender, RoutedEventArgs e)
        {

            if (!txtEmployeeID2.Text.Equals(""))
            {

                int res = employee.validateEmployeeID(txtEmployeeID2.Text);

                if (res == 1)
                {
                    int res2 = employeeRequestSalary.validateRequestSalary(txtEmployeeID2.Text);

                    if(res2 == 1)
                    {
                        int res3 = employeeRequestSalary.returnEmployeeSalaryStatus(txtEmployeeID2.Text);

                        if(res3 == 1)
                        {
                            employee.updateSalary(txtEmployeeID2.Text, (employeeRequestSalary.returnEmployeeSalaryRequest(txtEmployeeID2.Text)).ToString());
                            employeeRequestSalary.updateStatus(txtEmployeeID2.Text);
                            DGEmployee.ItemsSource = employeeSalary.grabDatabase();
                            DGSalaryRequest.ItemsSource = employeeRequestSalary.grabDatabase();
                            MessageBox.Show("Successfully Updated");
                        }
                        else
                        {
                            MessageBox.Show("Request not aprroved Yet !");
                        }

                    }
                    else
                    {
                        MessageBox.Show("EmployeeID don't have Request !");
                    }

                }
                else
                {
                    MessageBox.Show("EmployeeID not valid !");
                }

            }
            else
            {
                MessageBox.Show("Please Input EmployeeID");
            }


        }
    }
}
