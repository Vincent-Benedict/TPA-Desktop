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
    /// Interaction logic for HRMRequestFiring.xaml
    /// </summary>
    public partial class HRMRequestFiring : Page
    {

        public ModelViewEmployee employee;
        public ModelViewEmployeeRequestFiring employeeRequestFiring;
        public ModelViewEmployeeFired employeeFiring;

        public HRMRequestFiring()
        {
            InitializeComponent();
            employee = new ModelViewEmployee();
            employeeRequestFiring = new ModelViewEmployeeRequestFiring();
            employeeFiring = new ModelViewEmployeeFired();
            DGEmployeeList.ItemsSource = employee.grabDatabase();
            DGRequestEmployeeFiring.ItemsSource = employeeRequestFiring.grabDatabase();
            DGEmployeeFired.ItemsSource = employeeFiring.grabDatabase();
        }

        private void Button_Request(object sender, RoutedEventArgs e)
        {
            if (!txtEmployeeIDRequest.Text.Equals(""))
            {
                int res = employee.validateEmployeeID(txtEmployeeIDRequest.Text);

                if(res == 1)
                {
                    employeeRequestFiring.insertRequest
                    (employee.returnEmployeeID(txtEmployeeIDRequest.Text), employee.returnEmployeeName(txtEmployeeIDRequest.Text));
                    DGEmployeeList.ItemsSource = employee.grabDatabase();
                    DGRequestEmployeeFiring.ItemsSource = employeeRequestFiring.grabDatabase();
                    DGEmployeeFired.ItemsSource = employeeFiring.grabDatabase();
                    MessageBox.Show("request successfully inserted !");

                }
                else
                {
                    MessageBox.Show("Employee ID Invalid !");
                }


            }
            else
            {
                MessageBox.Show("Please Input Employee ID...");
            }

        }

        private void Button_Fired(object sender, RoutedEventArgs e)
        {

            if (!txtEmployeeIDFired.Text.Equals(""))
            {
                int res = employeeRequestFiring.validateEmployeeID(txtEmployeeIDFired.Text);

                if(res == 1)
                {

                    int res2 = employeeRequestFiring.validateEmployeeIDFiredStatus(txtEmployeeIDFired.Text);

                    if(res2 == 1)
                    {
                        employeeFiring.insertEmployeeFired(employeeRequestFiring.returnEmployeeID(txtEmployeeIDFired.Text), employeeRequestFiring.returnEmployeeName(txtEmployeeIDFired.Text));
                        employeeRequestFiring.deleteEmployee(txtEmployeeIDFired.Text);
                        employee.deleteEmployee(txtEmployeeIDFired.Text);


                        DGEmployeeList.ItemsSource = employee.grabDatabase();
                        DGRequestEmployeeFiring.ItemsSource = employeeRequestFiring.grabDatabase();
                        DGEmployeeFired.ItemsSource = employeeFiring.grabDatabase();
                        MessageBox.Show("Successfully Fired Employee !");
                    }
                    else
                    {
                        MessageBox.Show("Request hasn't approved yet !");
                    }

                    

                }
                else
                {
                    MessageBox.Show("Invalid Employee ID");
                }


            }
            else
            {
                MessageBox.Show("Please Input Employee ID...");
            }



        }
    }
}
