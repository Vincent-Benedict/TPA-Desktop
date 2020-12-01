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
using TPA_Desktop.Database_Connection;
using TPA_Desktop.PageView.PageTeller;

namespace TPA_Desktop.MVVM
{


    public class ModelViewEmployeeSalary
    {


        // yang ini yg di binidng
        public ModelEmployeeSalary modelEmployee;
        public List<ModelEmployeeSalary> employeeList;

        public ModelViewEmployeeSalary()
        {
            modelEmployee = new ModelEmployeeSalary();
            employeeList = modelEmployee.grabDatabase();
        }


        public List<ModelEmployeeSalary> grabDatabase()
        {
            employeeList = modelEmployee.grabDatabase();

            return employeeList;
        }

    }





    public class ModelEmployeeSalary
    {

        public String employeeID { get; set; }
        public String employeeName { get; set; }
        public String employeePhoneNumber { get; set; }
        public String employeeSalary { get; set; }

        DatabaseBuilder db;

        public List<ModelEmployeeSalary> listEmployee;

        public ModelEmployeeSalary()
        {
            db = new DatabaseBuilder();
        }

        public List<ModelEmployeeSalary> grabDatabase()
        {

            listEmployee = new List<ModelEmployeeSalary>();

            DataTable data = db.viewCustomerAccountData("SELECT employeeID, employeeName, employeePhoneNumber, employeeSalary FROM Employee");

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                listEmployee.Add(new ModelEmployeeSalary()
                {
                    employeeID = data.Rows[i][0].ToString(),
                    employeeName = data.Rows[i][1].ToString(),
                    employeePhoneNumber = data.Rows[i][2].ToString(),
                    employeeSalary = data.Rows[i][3].ToString()
                });
            }

            return listEmployee;
        }


        public void insertEmployee(String employeeID, String employeeName, String employeePassword, String employeeEmail, String employeePhoneNumber)
        {

            db.insertEmployee("INSERT INTO Employee VALUES (@employeeID, @employeeName, @employeePassword, @employeeEmail, @employeePhoneNumber)", employeeID, employeeName, employeePassword, employeeEmail, employeePhoneNumber);
        }

        public int updatePosition(String employeeID, String employeePassword, String staffEmployeeID)
        {
            String x = "UPDATE Employee SET employeeID = @employeeID, employeePassword = @employeePassword WHERE employeeID = @staffEmployeeID";
            int y = 0;
            y = db.updatePosition(x, employeeID, employeePassword, staffEmployeeID);
            return y;
        }



    }


}