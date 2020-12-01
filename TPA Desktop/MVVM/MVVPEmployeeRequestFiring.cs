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


    public class ModelViewEmployeeRequestFiring
    {


        // yang ini yg di binidng
        public ModelEmployeeRequestFiring modelEmployee;
        public List<ModelEmployeeRequestFiring> employeeList;

        public ModelViewEmployeeRequestFiring()
        {
            modelEmployee = new ModelEmployeeRequestFiring();
            employeeList = modelEmployee.grabDatabase();
        }


        public List<ModelEmployeeRequestFiring> grabDatabase()
        {
            employeeList = modelEmployee.grabDatabase();

            return employeeList;
        }

        public void insertRequest(String employeeID, String employeeName)
        {
            modelEmployee.insertRequest(employeeID, employeeName);
        }

        public void insert(String employeeID, String employeeName)
        {
            modelEmployee.insert(employeeID, employeeName);
        }

        public int validateEmployeeID(String employeeID)
        {
            int x = 0;
            x = modelEmployee.validateEmployeeID(employeeID);
            return x;
        }

        public String returnEmployeeID(String employeeID)
        {
            return modelEmployee.returnEmployeeID(employeeID);
        }

        public String returnEmployeeName(String employeeID)
        {
            return modelEmployee.returnEmployeeName(employeeID);
        }

        public void deleteEmployee(String employeeID)
        {
            modelEmployee.deleteEmployee(employeeID);
        }

        public int validateEmployeeIDFiredStatus(String employeeID)
        {
            int x = 0;
            x = modelEmployee.validateEmployeeIDFiredStatus(employeeID);
            return x;
        }

        public int updateRequestApprove(String employeeID)
        {
            int x = 0;
            x = modelEmployee.updateRequestApprove(employeeID);
            return x;
        }

    }





    public class ModelEmployeeRequestFiring
    {

        public String employeeID { get; set; }
        public String employeeName { get; set; }
        public String employeeRequestFiringStatus { get; set; }

        DatabaseBuilder db;

        public List<ModelEmployeeRequestFiring> listEmployee;

        public ModelEmployeeRequestFiring()
        {
            db = new DatabaseBuilder();
        }

        public List<ModelEmployeeRequestFiring> grabDatabase()
        {

            listEmployee = new List<ModelEmployeeRequestFiring>();

            DataTable data = db.viewCustomerAccountData("SELECT employeeID, employeeName, employeeRequestFiringStatus FROM EmployeeRequestFiring");

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                listEmployee.Add(new ModelEmployeeRequestFiring()
                {
                    employeeID = data.Rows[i][0].ToString(),
                    employeeName = data.Rows[i][1].ToString(),
                    employeeRequestFiringStatus = data.Rows[i][2].ToString()
        
                });
            }

            return listEmployee;
        }

        public int updateRequestApprove(String employeeID)
        {
            String query = "UPDATE EmployeeRequestFiring SET employeeRequestFiringStatus = 'approved' WHERE employeeID = @employeeID";
            int x = 0;
            x = db.updateFiringStatus(query, employeeID);
            return x;
        }


        public void insertRequest(String employeeID, String employeeName)
        {
            String query = "INSERT INTO EmployeeRequestFiring (employeeID, employeeName) VALUES (@employeeID, @employeeName)";
            db.insertRequestFiring(query, employeeID, employeeName);

        }

        public void insert(String employeeID, String employeeName)
        {
            String query = "INSERT INTO EmployeeRequestFiring VALUES (@employeeID, @employeeName, 'approved')";
            db.insertRequestFiring(query, employeeID, employeeName);
        }

        public int validateEmployeeID(String employeeID)
        {
            int returnValue = 0;

            returnValue = db.validateEmployeeID("SELECT COUNT(1) FROM EmployeeRequestFiring WHERE employeeID = @employeeID", employeeID);

            return returnValue;
        }

        public int validateEmployeeIDFiredStatus(String employeeID)
        {
            int returnValue = 0;

            returnValue = db.validateEmployeeID("SELECT COUNT(1) FROM EmployeeRequestFiring WHERE employeeID = @employeeID AND employeeRequestFiringStatus = 'approved'", employeeID);

            return returnValue;
        }

        public String returnEmployeeID(String employeeID)
        {
            DataTable data = db.viewEmployeeData("SELECT employeeID, employeeName FROM EmployeeRequestFiring WHERE employeeID = @employeeID", employeeID);
            return data.Rows[0][0].ToString();
        }

        public String returnEmployeeName(String employeeID)
        {
            DataTable data = db.viewEmployeeData("SELECT employeeID, employeeName FROM EmployeeRequestFiring WHERE employeeID = @employeeID", employeeID);
            return data.Rows[0][1].ToString();
        }


        public void deleteEmployee(String employeeID)
        {
            db.deleteEmployee("DELETE FROM EmployeeRequestFiring WHERE employeeID = @employeeID", employeeID);
        }



    }


}