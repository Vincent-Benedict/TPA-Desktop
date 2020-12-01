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


    public class ModelViewNewEmployee
    {


        // yang ini yg di binidng
        public ModelNewEmployee modelNewEmployee;
        public List<ModelNewEmployee> newEmployeeList;

        public ModelViewNewEmployee()
        {
            modelNewEmployee = new ModelNewEmployee();
            newEmployeeList = modelNewEmployee.grabDatabase();
        }


        public List<ModelNewEmployee> grabDatabase()
        {
            newEmployeeList = modelNewEmployee.grabDatabase();

            return newEmployeeList;
        }

        public List<ModelNewEmployee> grabDatabase(String newEmployeeID)
        {
            newEmployeeList = modelNewEmployee.grabDatabaseWhereNewEmployee(newEmployeeID);
            return newEmployeeList;
        }


        public void insertNewEmployeeRecruitment(String newEmployeeName, String newEmployeeEmail, String newEmployeePhone)
        {
            String x = "REC";

            if (newEmployeeList.Count() < 10)
            {
                x += "00";
                x += (newEmployeeList.Count()+1).ToString();
            }
            else if (newEmployeeList.Count() < 100)
            {
                x += "0";
                x += (newEmployeeList.Count() + 1).ToString();
            }
            else
            {
                x += (newEmployeeList.Count() + 1).ToString();
            }


            modelNewEmployee.insertNewEmployeeRecruitment(x, newEmployeeName, newEmployeeEmail, newEmployeePhone);
        }

        public void softDelete(String employeeCandidateID)
        {
            modelNewEmployee.softDelete(employeeCandidateID);
        }

        public DataTable grabDatabaseDataTable()
        {
            return modelNewEmployee.grabDatabaseDataTable(); 
        }



    }





    public class ModelNewEmployee
    {

        public String employeeCandidateID { get; set; }
        public String employeeCandidateName { get; set; }
        public String employeeCandidateEmail { get; set; }
        public String employeeCandidatePhoneNumber { get; set; }
        public String employeeCandidateStatus { get; set; }

        DatabaseBuilder db;

        public List<ModelNewEmployee> listNewEmployee;

        public ModelNewEmployee()
        {
            db = new DatabaseBuilder();
        }

        public List<ModelNewEmployee> grabDatabase()
        {

            listNewEmployee = new List<ModelNewEmployee>();

            DataTable data = db.viewCustomerAccountData("SELECT employeeCandidateID, employeeCandidateName, employeeCandidateEmail, employeeCandidatePhoneNumber, employeeCandidateStatus FROM EmployeeCandidate WHERE employeeCandidateStatus = 'active'");

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                listNewEmployee.Add(new ModelNewEmployee()
                {
                    employeeCandidateID = data.Rows[i][0].ToString(),
                    employeeCandidateName = data.Rows[i][1].ToString(),
                    employeeCandidateEmail = data.Rows[i][2].ToString(),
                    employeeCandidatePhoneNumber = data.Rows[i][3].ToString(),
                    employeeCandidateStatus = data.Rows[i][4].ToString()
                });
            }

            return listNewEmployee;
        }

        public DataTable grabDatabaseDataTable()
        {
            DataTable data = new DataTable();
            return data = db.viewCustomerAccountData("SELECT employeeCandidateID, employeeCandidateName, employeeCandidateEmail, employeeCandidatePhoneNumber, employeeCandidateStatus FROM EmployeeCandidate WHERE employeeCandidateStatus = 'active'");

        }


        public List<ModelNewEmployee> grabDatabaseWhereNewEmployee(String NewEmployeeID)
        {

            listNewEmployee = new List<ModelNewEmployee>();

            DataTable data = db.viewEmployeeCandidateData("SELECT employeeCandidateID, employeeCandidateName, employeeCandidateEmail, employeeCandidatePhoneNumber, employeeCandidateStatus FROM EmployeeCandidate WHERE employeeCandidateStatus = 'active' AND employeeCandidateID = @employeeCandidateID", NewEmployeeID);

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                listNewEmployee.Add(new ModelNewEmployee()
                {
                    employeeCandidateID = data.Rows[i][0].ToString(),
                    employeeCandidateName = data.Rows[i][1].ToString(),
                    employeeCandidateEmail = data.Rows[i][2].ToString(),
                    employeeCandidatePhoneNumber = data.Rows[i][3].ToString(),
                    employeeCandidateStatus = data.Rows[i][4].ToString()
                });
            }

            return listNewEmployee;
        }

        public void insertNewEmployeeRecruitment(String employeeCandidateID, String employeeCandidateName, String employeeCandidateEmail, String employeeCandidatePhoneNumber)
        {

            db.insertEmployeeRecruitment("INSERT INTO EmployeeCandidate (employeeCandidateID, employeeCandidateName, employeeCandidateEmail, employeeCandidatePhoneNumber) VALUES (@employeeCandidateID, @employeeCandidateName, @employeeCandidateEmail, @employeeCandidatePhoneNumber)",
                                employeeCandidateID, employeeCandidateName, employeeCandidateEmail, employeeCandidatePhoneNumber);
        }



        public void softDelete(String employeeCandidateID)
        {
            String x = "UPDATE EmployeeCandidate SET employeeCandidateStatus = 'non-active' WHERE employeeCandidateID = @employeeCandidateID";
            db.softDeleteNewEmployee(x, employeeCandidateID);
        }











    }


}