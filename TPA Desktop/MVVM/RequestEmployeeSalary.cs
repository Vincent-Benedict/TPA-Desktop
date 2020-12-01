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


    public class ModelViewEmployeeSalaryRequest
    {
        // yang ini yg di binidng
        public ModelEmployeeSalaryRequest modelEmployee;
        public List<ModelEmployeeSalaryRequest> employeeList;

        public ModelViewEmployeeSalaryRequest()
        {
            modelEmployee = new ModelEmployeeSalaryRequest();
            employeeList = modelEmployee.grabDatabase();
        }

        public List<ModelEmployeeSalaryRequest> grabDatabase()
        {
            employeeList = modelEmployee.grabDatabase();

            return employeeList;
        }

        public void insertSalaryRequest(String employeeID, String employeeUpdatedMoney)
        {
            modelEmployee.insertEmployeeSalaryRequest(employeeID, employeeUpdatedMoney);
        }

        public int validateRequestSalary(String employeeID)
        {
            int returnValue = 0;

            return returnValue = modelEmployee.validateRequestSalary(employeeID);
        }

        public String returnEmployeeIDRequest(String employeeID)
        {
            return modelEmployee.returnEmployeeIDRequest(employeeID);
        }

        public int returnEmployeeSalaryRequest(String employeeID)
        {
            return Int32.Parse(modelEmployee.returnEmployeeSalaryRuquest(employeeID));
        }

        public int returnEmployeeSalaryStatus(String employeeID)
        {
            return modelEmployee.returnEmployeeSalaryStatus(employeeID);
        }

        public int updateStatus(String employeeID)
        {
            int returnValue = 0;

            returnValue = modelEmployee.updateStatus(employeeID);

            return returnValue;
        }

        public int updateSalaryApprove(String employeeID)
        {
            int x = 0;
            x = modelEmployee.updateSalaryApprove(employeeID);
            return x;
        }

        public int updateSalaryReject(String employeeID)
        {
            int x = 0;
            x = modelEmployee.updateSalaryReject(employeeID);
            return x;
        }

    }





    public class ModelEmployeeSalaryRequest
    {

        public String employeeID { get; set; }
        public String employeeUpdatedMoney { get; set; }
        public String requestEmployeeSalaryStatus { get; set; }

        DatabaseBuilder db;

        public List<ModelEmployeeSalaryRequest> listEmployee;

        public ModelEmployeeSalaryRequest()
        {
            db = new DatabaseBuilder();
        }

        public List<ModelEmployeeSalaryRequest> grabDatabase()
        {

            listEmployee = new List<ModelEmployeeSalaryRequest>();

            DataTable data = db.viewCustomerAccountData("SELECT employeeID, employeeUpdatedMoney, requestEmployeeSalaryStatus FROM requestSalaryRaised WHERE requestEmployeeSalaryUpdateStatus = 'not-updated'");

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                listEmployee.Add(new ModelEmployeeSalaryRequest()
                {
                    employeeID = data.Rows[i][0].ToString(),
                    employeeUpdatedMoney = data.Rows[i][1].ToString(),
                    requestEmployeeSalaryStatus = data.Rows[i][2].ToString(),
                });
            }

            return listEmployee;
        }

        public List<ModelEmployeeSalaryRequest> grabData(String employeeID)
        {

            listEmployee = new List<ModelEmployeeSalaryRequest>();

            DataTable data = db.viewEmployeeData("SELECT employeeID, employeeUpdatedMoney, requestEmployeeSalaryStatus FROM requestSalaryRaised WHERE employeeID = @employeeID", employeeID);

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                listEmployee.Add(new ModelEmployeeSalaryRequest()
                {
                    employeeID = data.Rows[i][0].ToString(),
                    employeeUpdatedMoney = data.Rows[i][1].ToString(),
                    requestEmployeeSalaryStatus = data.Rows[i][2].ToString(),
                });
            }

            return listEmployee;
        }



        public int returnEmployeeSalaryStatus(String employeeID)
        {
            DataTable data = db.viewEmployeeData("SELECT employeeID, employeeUpdatedMoney, requestEmployeeSalaryStatus FROM requestSalaryRaised WHERE employeeID = @employeeID and requestEmployeeSalaryUpdateStatus = 'not-updated'", employeeID);

            if (data.Rows[0][2].ToString().Equals("approved")) return 1;
            else return 0;
        }

        public String returnEmployeeIDRequest(String employeeID)
        {
            DataTable data = db.viewEmployeeData("SELECT employeeID, employeeUpdatedMoney, requestEmployeeSalaryStatus FROM requestSalaryRaised WHERE employeeID = @employeeID AND requestEmployeeSalaryStatus = 'approved' and requestEmployeeSalaryUpdateStatus = 'not-updated'", employeeID);

            return data.Rows[0][0].ToString();
        }

        public String returnEmployeeSalaryRuquest(String employeeID)
        {
            DataTable data = db.viewEmployeeData("SELECT employeeID, employeeUpdatedMoney, requestEmployeeSalaryStatus FROM requestSalaryRaised WHERE employeeID = @employeeID AND requestEmployeeSalaryStatus = 'approved' and requestEmployeeSalaryUpdateStatus = 'not-updated'", employeeID);

            return data.Rows[0][1].ToString();
        }


        public void insertEmployeeSalaryRequest(String employeeID, String employeeUpdatedMoney)
        {

            String query = "INSERT INTO requestSalaryRaised (employeeID, employeeUpdatedMoney) VALUES (@employeeID, @employeeUpdatedMoney)";
            db.insertRequestEmployeeSalary(query, employeeID, employeeUpdatedMoney);
        }

        public int updatePosition(String employeeID, String employeePassword, String staffEmployeeID)
        {
            String x = "UPDATE Employee SET employeeID = @employeeID, employeePassword = @employeePassword WHERE employeeID = @staffEmployeeID";
            int y = 0;
            y = db.updatePosition(x, employeeID, employeePassword, staffEmployeeID);
            return y;
        }

        public int validateRequestSalary(String employeeID)
        {
            int returnValue = 0;

            returnValue = db.validateEmployeeID("SELECT COUNT(1) FROM requestSalaryRaised WHERE employeeID = @employeeID", employeeID);

            return returnValue;
        }


        public int updateStatus(String employeeID)
        {
            int returnValue = 0;

            returnValue = db.validateEmployeeID("UPDATE requestSalaryRaised SET requestEmployeeSalaryUpdateStatus = 'updated' WHERE employeeID = @employeeID", employeeID);

            return returnValue;
        }

        public int updateSalaryApprove(String employeeID)
        {
            int x = 0;

            String query = "UPDATE requestSalaryRaised SET requestEmployeeSalaryStatus = 'approved' WHERE employeeID = @employeeID";

            x = db.validateEmployeeID(query, employeeID);

            return x;
        }

        public int updateSalaryReject(String employeeID)
        {
            int x = 0;

            String query = "UPDATE requestSalaryRaised SET requestEmployeeSalaryStatus = 'rejected' WHERE employeeID = @employeeID";

            x = db.validateEmployeeID(query, employeeID);

            return x;
        }



    }


}