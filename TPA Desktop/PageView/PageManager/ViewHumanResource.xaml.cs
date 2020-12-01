using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ViewHumanResource.xaml
    /// </summary>
    public partial class ViewHumanResource : Page
    {
        public ModelViewNewEmployee newEmployee;
        public ModelViewEmployee employee;
        public ModelViewEmployeeFired employeeFired;
        public ModelViewEmployeeLeavingPermit employeeLeavingPermit;
        public ModelViewEmployeeResign employeeResign;
        public ModelViewCustomerDepositInterest customerDepositInterest;
        public ViewHumanResource()
        {
            InitializeComponent();
            newEmployee = new ModelViewNewEmployee();
            employee = new ModelViewEmployee();
            employeeFired = new ModelViewEmployeeFired();
            employeeLeavingPermit = new ModelViewEmployeeLeavingPermit();
            employeeResign = new ModelViewEmployeeResign();
            customerDepositInterest = new ModelViewCustomerDepositInterest();
        }

        private void Button_EmpRec(object sender, RoutedEventArgs e)
        {
            DataTable data = new System.Data.DataTable();

            data = newEmployee.grabDatabaseDataTable();

            writeExcel(data);

            
        }

        private void Button_EmpProm(object sender, RoutedEventArgs e)
        {
            DataTable data = new System.Data.DataTable();

            data = employee.grabDatabaseDataTable();

            writeExcel(data);
        }

        private void Button_EmpFired(object sender, RoutedEventArgs e)
        {
            DataTable data = new System.Data.DataTable();

            data = employeeFired.grabDatabaseDataTable();

            writeExcel(data);
        }

        private void Button_LeavReq(object sender, RoutedEventArgs e)
        {
            DataTable data = new System.Data.DataTable();

            data = employeeLeavingPermit.grabDatabaseDataTable();

            writeExcel(data);
        }

        private void Button_EmpResign(object sender, RoutedEventArgs e)
        {
            DataTable data = new System.Data.DataTable();

            data = employeeResign.grabDatabaseDataTable();

            writeExcel(data);
        }

        private void Button_GrowthRate(object sender, RoutedEventArgs e)
        {
            DataTable data = new System.Data.DataTable();

            data = customerDepositInterest.grabDatabaseDataTable();

            writeExcel(data);
        }

        private void writeExcel(DataTable data)
        {
            if (data.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcellApp = new Microsoft.Office.Interop.Excel.Application();
                xcellApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    for (int j = 0; j < data.Columns.Count; j++)
                    {

                        xcellApp.Cells[i + 1, j + 1] = data.Rows[i][j].ToString();
                    }
                }
                xcellApp.Columns.AutoFit();
                xcellApp.Visible = true;
            }
        }
    }
}
