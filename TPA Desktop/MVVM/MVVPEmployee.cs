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


    public class ModelViewEmployee
    {


        // yang ini yg di binidng
        public ModelEmployee modelEmployee;
        public ModelViewEmployeeResign modelEmployeeResign;

        public List<ModelEmployee> employeeList { get; set; }
        public List<ModelEmployeeResign> employeeResignList { get; set; }

        public ModelViewEmployee()
        {
            modelEmployee = new ModelEmployee();
            modelEmployeeResign = new ModelViewEmployeeResign();
            employeeList = modelEmployee.grabDatabase();
            employeeResignList = modelEmployeeResign.grabDatabase();
        }


        public List<ModelEmployee> grabDatabase()
        {
            employeeList = modelEmployee.grabDatabase();

            return employeeList;
        }

        public List<ModelEmployee> grabDatabase(String employeeID)
        {
            employeeList = modelEmployee.grabDatabaseWhereEmployee(employeeID);
            return employeeList;
        }

        


        public void insertNewStaffEmployee(String employeeName, String employeeEmail, String employeePhoneNumber)
        {
            String x = "STF";

            if (selectCountEmployeeSTF() < 10)
            {
                x += "00";
                x += (selectCountEmployeeSTF() + 1).ToString();
            }
            else if (selectCountEmployeeSTF() < 100)
            {
                x += "0";
                x += (selectCountEmployeeSTF() + 1).ToString();
            }
            else
            {
                x += (selectCountEmployeeSTF() + 1).ToString();
            }

            String password = "stf" + (selectCountEmployeeSTF()+1).ToString();


            modelEmployee.insertEmployee(x, employeeName, password, employeeEmail, employeePhoneNumber);
        }

        public int announcePosition(String position, String staffEmployeeID)
        {

            int returnValue = 0;
            String x = "";
            String password = "";

            if (position.Equals("teller") || position.Equals("Teller"))
            {
                x = "TLR";
                if (selectCountEmployeeTLR() < 10)
                {
                    x += "00";
                    x += (selectCountEmployeeTLR() + 1).ToString();
                }
                else if (selectCountEmployeeTLR() < 100)
                {
                    x += "0";
                    x += (selectCountEmployeeTLR() + 1).ToString();
                }
                else
                {
                    x += (selectCountEmployeeTLR() + 1).ToString();
                }

                password = "teller" + (selectCountEmployeeTLR() + 1).ToString();
            }
            else if (position.Equals("customer service") || position.Equals("Customer Service"))
            {
                x = "CSC";
                if (selectCountEmployeeTLR() < 10)
                {
                    x += "00";
                    x += (selectCountEmployeeTLR() + 1).ToString();
                }
                else if (selectCountEmployeeTLR() < 100)
                {
                    x += "0";
                    x += (selectCountEmployeeTLR() + 1).ToString();
                }
                else
                {
                    x += (selectCountEmployeeTLR() + 1).ToString();
                }

                password = "csc" + (selectCountEmployeeTLR() + 1).ToString();
            }
            else if (position.Equals("Security and Maintenance Team") || position.Equals("security and maintenance team"))
            {
                x = "SMT";
                if (selectCountEmployeeSMT() < 10)
                {
                    x += "00";
                    x += (selectCountEmployeeSMT() + 1).ToString();
                }
                else if (selectCountEmployeeSMT() < 100)
                {
                    x += "0";
                    x += (selectCountEmployeeSMT() + 1).ToString();
                }
                else
                {
                    x += (selectCountEmployeeSMT() + 1).ToString();
                }

                password = "smt" + (selectCountEmployeeSMT() + 1).ToString();
            }

            else if (position.Equals("Human Resource Management Team") || position.Equals("human resource management team"))
            {
                x = "HRM";
                if (selectCountEmployeeHRM() < 10)
                {
                    x += "00";
                    x += (selectCountEmployeeHRM() + 1).ToString();
                }
                else if (selectCountEmployeeHRM() < 100)
                {
                    x += "0";
                    x += (selectCountEmployeeHRM() + 1).ToString();
                }
                else
                {
                    x += (selectCountEmployeeHRM() + 1).ToString();
                }

                password = "hrm" + (selectCountEmployeeHRM() + 1).ToString();
            }
            else if (position.Equals("Finance Team") || position.Equals("finance team"))
            {
                x = "FIN";
                if (selectCountEmployeeFIN() < 10)
                {
                    x += "00";
                    x += (selectCountEmployeeFIN() + 1).ToString();
                }
                else if (selectCountEmployeeFIN() < 100)
                {
                    x += "0";
                    x += (selectCountEmployeeFIN() + 1).ToString();
                }
                else
                {
                    x += (selectCountEmployeeFIN() + 1).ToString();
                }

                password = "fin" + (selectCountEmployeeFIN() + 1).ToString();
            }


            returnValue = modelEmployee.updatePosition(x, password, staffEmployeeID);

            return returnValue;
        }



        public int selectCountEmployeeTLR()
        {
            int x = 0;
            x = modelEmployee.selectCountEmployeeTLR();
            return x;
        }

        public int selectCountEmployeeCSC()
        {
            int x = 0;
            x = modelEmployee.selectCountEmployeeCSC();
            return x;
        }

        public int selectCountEmployeeSMT()
        {
            int x = 0;
            x = modelEmployee.selectCountEmployeeSMT();
            return x;
        }

        public int selectCountEmployeeHRM()
        {
            int x = 0;
            x = modelEmployee.selectCountEmployeeHRM();
            return x;
        }

        public int selectCountEmployeeFIN()
        {
            int x = 0;
            x = modelEmployee.selectCountEmployeeFIN();
            return x;
        }

        public int selectCountEmployeeSTF()
        {
            int x = 0;
            x = modelEmployee.selectCountEmployeeSTF();
            return x;
        }

        public int validateEmployeeID(String employeeID)
        {
            int returnValue = 0;
            returnValue = modelEmployee.validateEmployeeID(employeeID);
            return returnValue;
        }

        public int updateSalary(String employeeID, String employeeSalary)
        {
            int returnValue = 0;
            returnValue = modelEmployee.updateSalary(employeeID, employeeSalary);
            return returnValue;
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

        public DataTable grabDatabaseDataTable()
        {
            return modelEmployee.grabDatabaseDataTable();

        }


    }





    public class ModelEmployee
    {

        public String employeeID { get; set; }
        public String employeeName { get; set; }
        public String employeePassword { get; set; }
        public String employeeEmail { get; set; }
        public String employeePhoneNumber { get; set; }

        DatabaseBuilder db;

        public List<ModelEmployee> listEmployee;

        public ModelEmployee()
        {
            db = new DatabaseBuilder();
        }

        public List<ModelEmployee> grabDatabase()
        {

            listEmployee = new List<ModelEmployee>();

            DataTable data = db.viewCustomerAccountData("SELECT employeeID, employeeName, employeePassword, employeeEmail, employeePhoneNumber FROM Employee");

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                listEmployee.Add(new ModelEmployee()
                {
                    employeeID = data.Rows[i][0].ToString(),
                    employeeName = data.Rows[i][1].ToString(),
                    employeePassword = data.Rows[i][2].ToString(),
                    employeeEmail = data.Rows[i][3].ToString(),
                    employeePhoneNumber = data.Rows[i][4].ToString()
                });
            }

            return listEmployee;
        }

        public DataTable grabDatabaseDataTable()
        {
            DataTable data = db.viewCustomerAccountData("SELECT employeeID, employeeName, employeePassword, employeeEmail, employeePhoneNumber FROM Employee");
            return data;

        }


        public int validateEmployeeID(String employeeID)
        {
            int returnValue = 0;

            returnValue = db.validateEmployeeID("SELECT COUNT(1) FROM Employee WHERE employeeID = @employeeID", employeeID);

            return returnValue;
        }


        public List<ModelEmployee> grabDatabaseWhereEmployee(String employeeID)
        {

            listEmployee = new List<ModelEmployee>();

            DataTable data = db.viewEmployeeData("SELECT employeeID, employeeName, employeePassword, employeeEmail, employeePhoneNumber FROM Employee WHERE employeeID = @employeeID", employeeID);

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                listEmployee.Add(new ModelEmployee()
                {
                    employeeID = data.Rows[i][0].ToString(),
                    employeeName = data.Rows[i][1].ToString(),
                    employeePassword = data.Rows[i][2].ToString(),
                    employeeEmail = data.Rows[i][3].ToString(),
                    employeePhoneNumber = data.Rows[i][4].ToString()
                });
            }

            return listEmployee;
        }

        public String returnEmployeeID(String employeeID)
        {
            DataTable data = db.viewEmployeeData("SELECT employeeID, employeeName, employeePassword, employeeEmail, employeePhoneNumber FROM Employee WHERE employeeID = @employeeID", employeeID);
            return data.Rows[0][0].ToString();
        }

        public String returnEmployeeName(String employeeID)
        {
            DataTable data = db.viewEmployeeData("SELECT employeeID, employeeName, employeePassword, employeeEmail, employeePhoneNumber FROM Employee WHERE employeeID = @employeeID", employeeID);
            return data.Rows[0][1].ToString();
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

        public int updateSalary(String employeeID, String employeeSalary)
        {
            String x = "UPDATE Employee SET employeeSalary = @employeeSalary WHERE employeeID = @employeeID";
            int y = 0;
            y = db.updateSalary(x, employeeID, Int32.Parse(employeeSalary));
            return y;
        }



        public int selectCountEmployeeTLR()
        {
            int x = 0;
            x = db.selectCount("SELECT Count(employeeID) FROM Employee WHERE employeeID LIKE 'TLR%'");
            return x;
        }

        public int selectCountEmployeeCSC()
        {
            int x = 0;
            x = db.selectCount("SELECT Count(employeeID) FROM Employee WHERE employeeID LIKE 'CSC%'");
            return x;
        }

        public int selectCountEmployeeSMT()
        {
            int x = 0;
            x = db.selectCount("SELECT Count(employeeID) FROM Employee WHERE employeeID LIKE 'SMT%'");
            return x;
        }

        public int selectCountEmployeeHRM()
        {
            int x = 0;
            x = db.selectCount("SELECT Count(employeeID) FROM Employee WHERE employeeID LIKE 'HRM%'");
            return x;
        }

        public int selectCountEmployeeFIN()
        {
            int x = 0;
            x = db.selectCount("SELECT Count(employeeID) FROM Employee WHERE employeeID LIKE 'FIN%'");
            return x;
        }

        public int selectCountEmployeeSTF()
        {
            int x = 0;
            x = db.selectCount("SELECT Count(employeeID) FROM Employee WHERE employeeID LIKE 'STF%'");
            return x;
        }

        public void deleteEmployee(String employeeID)
        {
            db.deleteEmployee("DELETE FROM Employee WHERE employeeID = @employeeID", employeeID);
        }



    }


}