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
    /// Interaction logic for ResignationEmployee.xaml
    /// </summary>
    public partial class ResignationEmployee : Page
    {

        public ModelViewEmployee employee;
        public ModelViewEmployeeResign employeeResign;
        public ResignationEmployee()
        {
            InitializeComponent();

            employee = new ModelViewEmployee();
            employeeResign = new ModelViewEmployeeResign();

            DGEmployee.ItemsSource = employee.grabDatabase();
            DGEmployeeResign.ItemsSource = employeeResign.grabDatabase();
        }

        private void Button_Resign(object sender, RoutedEventArgs e)
        {
            if (!txtEmployeeID.Text.Equals(""))
            {
                int res = employee.validateEmployeeID(txtEmployeeID.Text);

                if (res == 1)
                {
                    employeeResign.insertIntoList(employee.returnEmployeeID(txtEmployeeID.Text), employee.returnEmployeeName(txtEmployeeID.Text));
                    employee.deleteEmployee(txtEmployeeID.Text);
                    DGEmployee.ItemsSource = employee.grabDatabase();
                    DGEmployeeResign.ItemsSource = employeeResign.grabDatabase();
                    MessageBox.Show("Successfully Resign !");
                }
                else
                {
                    MessageBox.Show("Invalid EmployeeID");
                }

            }
            else
            {
                MessageBox.Show("Please Fill EmployeeID");
            }
        }
    }
}
