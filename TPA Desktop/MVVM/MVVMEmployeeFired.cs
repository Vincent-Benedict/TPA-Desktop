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


    public class ModelViewEmployeeFired
    {


        // yang ini yg di binidng
        public ModelEmployeeFired modelEmployee;
        public List<ModelEmployeeFired> employeeList;

        public ModelViewEmployeeFired()
        {
            modelEmployee = new ModelEmployeeFired();
            employeeList = modelEmployee.grabDatabase();
        }


        public List<ModelEmployeeFired> grabDatabase()
        {
            employeeList = modelEmployee.grabDatabase();

            return employeeList;
        }


        public void insertEmployeeFired(String employeeID, String employeeName)
        {
            modelEmployee.insertEmployeeFired(employeeID, employeeName);
        }


        public DataTable grabDatabaseDataTable()
        {
            return modelEmployee.grabDatabaseDataTable();
        }

    }





    public class ModelEmployeeFired
    {

        public String employeeID { get; set; }
        public String employeeName { get; set; }
        public String employeeFiredStatus { get; set; }

        DatabaseBuilder db;

        public List<ModelEmployeeFired> listEmployee;

        public ModelEmployeeFired()
        {
            db = new DatabaseBuilder();
        }

        public List<ModelEmployeeFired> grabDatabase()
        {

            listEmployee = new List<ModelEmployeeFired>();

            DataTable data = db.viewCustomerAccountData("SELECT employeeID, employeeName, employeeFiredStatus FROM EmployeeFired");

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                listEmployee.Add(new ModelEmployeeFired()
                {
                    employeeID = data.Rows[i][0].ToString(),
                    employeeName = data.Rows[i][1].ToString(),
                    employeeFiredStatus = data.Rows[i][2].ToString()

                });
            }

            return listEmployee;
        }

        public DataTable grabDatabaseDataTable()
        {
            DataTable data = db.viewCustomerAccountData("SELECT employeeID, employeeName, employeeFiredStatus FROM EmployeeFired");
            return data;
        }

        public void insertEmployeeFired(String employeeID, String employeeName)
        {
            String query = "INSERT INTO EmployeeFired (employeeID, employeeName) VALUES (@employeeID, @employeeName)";
            db.insertFiredEmployee(query, employeeID, employeeName);
        }


    }


}

