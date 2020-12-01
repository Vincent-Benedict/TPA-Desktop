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

namespace TPA_Desktop.PageView.PageManager
{
    /// <summary>
    /// Interaction logic for FireEmployee.xaml
    /// </summary>
    public partial class FireEmployee : Page
    {

        public ModelViewEmployee employee;
        public ModelViewEmployeeRequestFiring employeeRequestFiring;
        public ModelViewEmployeeFired employeeFiring;
        public FireEmployee()
        {
            InitializeComponent();
            employee = new ModelViewEmployee();
            employeeRequestFiring = new ModelViewEmployeeRequestFiring();
            employeeFiring = new ModelViewEmployeeFired();
            DGEmployeeList.ItemsSource = employee.grabDatabase();
            DGRequestEmployeeFiring.ItemsSource = employeeRequestFiring.grabDatabase();
            DGEmployeeFired.ItemsSource = employeeFiring.grabDatabase();
        }

        private void Button_Input(object sender, RoutedEventArgs e)
        {
            if (!txtEmployeeIDRequest.Text.Equals(""))
            {
                int res = employee.validateEmployeeID(txtEmployeeIDRequest.Text);

                if (res == 1)
                {
                    employeeRequestFiring.insert
                    (employee.returnEmployeeID(txtEmployeeIDRequest.Text), employee.returnEmployeeName(txtEmployeeIDRequest.Text));
                    DGEmployeeList.ItemsSource = employee.grabDatabase();
                    DGRequestEmployeeFiring.ItemsSource = employeeRequestFiring.grabDatabase();
                    DGEmployeeFired.ItemsSource = employeeFiring.grabDatabase();
                    MessageBox.Show("successfully inserted !");

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

        private void Button_Approve(object sender, RoutedEventArgs e)
        {
            if (!txtEmployeeIDRequest.Text.Equals(""))
            {
                int res = employee.validateEmployeeID(txtEmployeeIDFired.Text);

                if (res == 1)
                {
                    int res2 = employeeRequestFiring.updateRequestApprove(txtEmployeeIDFired.Text);

                    if(res2 == 1)
                    {
                        DGEmployeeList.ItemsSource = employee.grabDatabase();
                        DGRequestEmployeeFiring.ItemsSource = employeeRequestFiring.grabDatabase();
                        DGEmployeeFired.ItemsSource = employeeFiring.grabDatabase();
                        MessageBox.Show("Successfully Approved !");
                    }
                    else
                    {
                        MessageBox.Show("Employee ID not valid !");
                    }
                    
                    
                    

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
    }
}
