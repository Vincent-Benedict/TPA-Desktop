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

namespace TPA_Desktop.PageView.PageTeller
{
    public class ModelViewCustomer1
    {


        // yang ini yg di binidng
        public ModelCustomer1 customerModel;
        public List<ModelCustomer1> customers;



        public ModelViewCustomer1()
        {
            customerModel = new ModelCustomer1();
            customers = customerModel.grabDatabase();
        }

        public int validateCustomerAccountID(String txtCustomerID)
        {
            int returnValue = customerModel.validateCustomerAccountID(txtCustomerID);
            return returnValue;
        }

        public int updateDepositCustomer(String txtCustomerID, int depositMoney)
        {
            int returnValue = customerModel.depositMoney(txtCustomerID, depositMoney);
            return returnValue;
        }


        public int transferMoney(String txtCustomerID1, String txtCustomerID2, int transferMoney)
        {
            int returnValue = 0;

            returnValue = customerModel.depositMoney(txtCustomerID1, (transferMoney * -1));
            returnValue = customerModel.depositMoney(txtCustomerID2, transferMoney);

            return returnValue;
        }

        public List<ModelCustomer1> grabDatabase()
        {
            customers = customerModel.grabDatabase();

            return customers;
        }

        public void insertNewRegularCustomerAccount(String customerAccountID, String customerAccountName, String customerAccountBalanceInquiry,
            String customerAccountType)
        {
            customerModel.insertCustomerAccountID(customerAccountID, customerAccountName, customerAccountBalanceInquiry, customerAccountType);
        }

        public void insertNewRegularCustomerAccount(String customerAccountID, String customerAccountName, String customerAccountBalanceInquiry,
            String customerAccountType, String link)
        {
            customerModel.insertCustomerAccountID(customerAccountID, customerAccountName, customerAccountBalanceInquiry, customerAccountType, link);
        }

        public void blockedAccount(String customerAccountID)
        {
            customerModel.blockedAccount(customerAccountID);
        }

        public int validateBusinessAccount(String customerAccountID)
        {
            int x = customerModel.validateBusinessAccount(customerAccountID);

            return x;
        }




    }

    public class ModelCustomer1
    {


        public String customerAccountID { get; set; }
        public String customerAccountName { get; set; }
        public String customerAccountBalanceInquiry { get; set; }
        public String customerAccountType { get; set; }
        public String linkAccount { get; set; }

        DatabaseBuilder db;

        public List<ModelCustomer1> customers;

        public ModelCustomer1()
        {
            db = new DatabaseBuilder();
        }

        public List<ModelCustomer1> grabDatabase()
        {

            customers = new List<ModelCustomer1>();

            DataTable data = db.viewCustomerAccountData("SELECT [customerAccountID] ,[customerAccountName] ,[customerAccountBalanceInquiry], [customerAccountType], [linkAccount] FROM CustomerAccount WHERE active = 'active'");

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                customers.Add(new ModelCustomer1() { customerAccountID = data.Rows[i][0].ToString(), customerAccountName = data.Rows[i][1].ToString(), customerAccountBalanceInquiry = data.Rows[i][2].ToString(), customerAccountType=data.Rows[i][3].ToString(), linkAccount= data.Rows[i][4].ToString() });
            }

            return customers;

        }

        public int depositMoney(String txtCustomerID, int depositMoney)
        {
            int returnValue = 0;

            returnValue = db.updateMoneyTeller("UPDATE CustomerAccount SET customerAccountBalanceInquiry = customerAccountBalanceInquiry + @depositMoney WHERE customerAccountID = @customerAccountID", txtCustomerID, depositMoney);

            return returnValue;

        }

        public int validateCustomerAccountID(String txtCustomerID)
        {
            int returnValue = 0;

            returnValue = db.validateCustomerID("SELECT COUNT(1) FROM CustomerAccount WHERE customerAccountID = @customerAccountID", txtCustomerID);

            return returnValue;
        }

        public void insertCustomerAccountID(String customerAccountID, String customerAccountName, String customerAccountBalanceInquiry,
            String customerAccountType)
        {
            db.insertCustomerRegularAccount("INSERT INTO CustomerAccount(customerAccountID, customerAccountName, customerAccountBalanceInquiry, customerAccountType, active) VALUES(@customerAccountID, @customerAccountName, @customerAccountBalanceInquiry, @customerAccountType, 'active')",
                                       customerAccountID, customerAccountName, customerAccountBalanceInquiry, customerAccountType);
        }

        public void insertCustomerAccountID(String customerAccountID, String customerAccountName, String customerAccountBalanceInquiry,
            String customerAccountType, String link)
        {
            db.insertCustomerStudentAccount("INSERT INTO CustomerAccount VALUES(@customerAccountID, @customerAccountName, @customerAccountBalanceInquiry, @customerAccountType, @linkAccount, 'active')",
                                       customerAccountID, customerAccountName, customerAccountBalanceInquiry, customerAccountType, link);
        }


        public void blockedAccount(String customerAccountID)
        {
            db.setActiveAccount("DELETE FROM Customer WHERE customerAccountID = @customerAccountID", customerAccountID);
            db.setActiveAccount("DELETE FROM CustomerAccount WHERE customerAccountID = @customerAccountID", customerAccountID);
        }

        public int validateBusinessAccount(String customerAccountID)
        {
            int x = 0;

            customers = new List<ModelCustomer1>();

            DataTable data = db.viewCustomerAccountData("SELECT [customerAccountID] ,[customerAccountName] ,[customerAccountBalanceInquiry], [customerAccountType], [linkAccount] FROM CustomerAccount WHERE active = 'active' AND customerAccountID = @customerAccountID", customerAccountID);
            
            if(data.Rows[0][3].Equals("Business Account"))
            {
                x = 1;
            }

            return x;
        }


    }




}