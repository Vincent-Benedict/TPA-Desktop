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


    public class ModelViewEmployeeLeavingPermit
    {


        // yang ini yg di binidng
        public ModelEmployeeLeavingPermit modelEmployee;
        public List<ModelEmployeeLeavingPermit> employeeList;

        public ModelViewEmployeeLeavingPermit()
        {
            modelEmployee = new ModelEmployeeLeavingPermit();
            employeeList = modelEmployee.grabDatabase();
        }


        public List<ModelEmployeeLeavingPermit> grabDatabase()
        {
            employeeList = modelEmployee.grabDatabase();

            return employeeList;
        }

        public int updateStatusToApproved(String leavingPermitNumber)
        {
            int x = 0;
            x = modelEmployee.updateStatusToApproved(leavingPermitNumber);
            return x;
        }

        public int updateStatusToReject(String leavingPermitNumber)
        {
            int x = 0;
            x = modelEmployee.updateStatusToReject(leavingPermitNumber);
            return x;
        }

        public DataTable grabDatabaseDataTable()
        {
            return modelEmployee.grabDatabaseDataTable();
        }



    }





    public class ModelEmployeeLeavingPermit
    {

        public String leavingPermitNumber { get; set; }
        public String employeeID { get; set; }
        public String employeeName { get; set; }
        public String permitReason { get; set; }
        public String permitStatus { get; set; }

        DatabaseBuilder db;

        public List<ModelEmployeeLeavingPermit> listEmployee;

        public ModelEmployeeLeavingPermit()
        {
            db = new DatabaseBuilder();
        }

        public List<ModelEmployeeLeavingPermit> grabDatabase()
        {

            listEmployee = new List<ModelEmployeeLeavingPermit>();

            DataTable data = db.viewCustomerAccountData("SELECT leavingPermitNumber, employeeID, employeeName, permitReason, permitStatus FROM EmployeeLeavingPermit");

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                listEmployee.Add(new ModelEmployeeLeavingPermit()
                {
                    leavingPermitNumber = data.Rows[i][0].ToString(),
                    employeeID = data.Rows[i][1].ToString(),
                    employeeName = data.Rows[i][2].ToString(),
                    permitReason = data.Rows[i][3].ToString(),
                    permitStatus = data.Rows[i][4].ToString()

                });
            }

            return listEmployee;
        }

        public DataTable grabDatabaseDataTable()
        {
            DataTable data = db.viewCustomerAccountData("SELECT leavingPermitNumber, employeeID, employeeName, permitReason, permitStatus FROM EmployeeLeavingPermit");

            return data;
        }


        public int updateStatusToApproved(String leavingPermitNumber)
        {
            int x = 0;
            String query = "UPDATE EmployeeLeavingPermit SET permitStatus = 'approved' WHERE leavingPermitNumber = @leavingPermitNumber";
            x = db.updatePermitStatus(query, Int32.Parse(leavingPermitNumber));

            return x;
        }

        public int updateStatusToReject(String leavingPermitNumber)
        {
            int x = 0;
            String query = "UPDATE EmployeeLeavingPermit SET permitStatus = 'reject' WHERE leavingPermitNumber = @leavingPermitNumber";
            x = db.updatePermitStatus(query, Int32.Parse(leavingPermitNumber));

            return x;
        }



    }


}