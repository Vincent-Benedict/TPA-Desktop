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


    public class ModelViewEmployeeResign
    {


        // yang ini yg di binidng
        public ModelEmployeeResign modelEmployee;
        public List<ModelEmployeeResign> employeeList { get; set; }

        public ModelViewEmployeeResign()
        {
            modelEmployee = new ModelEmployeeResign();
            employeeList = modelEmployee.grabDatabase();
        }


        public List<ModelEmployeeResign> grabDatabase()
        {
            employeeList = modelEmployee.grabDatabase();

            return employeeList;
        }

        public void insertIntoList(String employeeID, String employeeName)
        {
            modelEmployee.insertIntoList(employeeID, employeeName);
        }

        public DataTable grabDatabaseDataTable()
        {
            return modelEmployee.grabDatabaseDataTable();
        }
    }





    public class ModelEmployeeResign
    {

        public String employeeID { get; set; }
        public String employeeName { get; set; }
        public String employeeResignStatus { get; set; }

        DatabaseBuilder db;

        public List<ModelEmployeeResign> listEmployee;

        public ModelEmployeeResign()
        {
            db = new DatabaseBuilder();
        }

        public List<ModelEmployeeResign> grabDatabase()
        {

            listEmployee = new List<ModelEmployeeResign>();

            DataTable data = db.viewCustomerAccountData("SELECT employeeID, employeeName, employeeResignStatus FROM EmployeeResignList");

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                listEmployee.Add(new ModelEmployeeResign()
                {
                    employeeID = data.Rows[i][0].ToString(),
                    employeeName = data.Rows[i][1].ToString(),
                    employeeResignStatus = data.Rows[i][2].ToString(),
                    
                });
            }

            return listEmployee;
        }

        public DataTable grabDatabaseDataTable()
        {
            DataTable data = db.viewCustomerAccountData("SELECT employeeID, employeeName, employeeResignStatus FROM EmployeeResignList");
            return data;
        }

        public void insertIntoList(String employeeID, String employeeName)
        {
            String query = "Insert Into EmployeeResignList (employeeID, employeeName) VALUES (@employeeID, @employeeName)";

            db.insertEmployeeResignList(query, employeeID, employeeName);
        }


    }


}