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
    public class ModelViewCustomer
    {


        // yang ini yg di binidng
        public ModelCustomer customerModel;
        public List<ModelCustomer> customers;


        public ModelViewCustomer()
        {
            customerModel = new ModelCustomer();
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

        public List<ModelCustomer> grabDatabase()
        {
            customers = customerModel.grabDatabase();

            return customers;
        }



    }

    public class ModelCustomer
    {


        public String customerAccountID { get; set; }
        public String customerAccountName { get; set; }
        public String customerAccountBalanceInquiry { get; set; }

        DatabaseBuilder db;

        public List<ModelCustomer> customers;

        public ModelCustomer()
        {
            db = new DatabaseBuilder();
        }

        public List<ModelCustomer> grabDatabase()
        {

            customers = new List<ModelCustomer>();

            DataTable data = db.viewCustomerAccountData("SELECT [customerAccountID] ,[customerAccountName] ,[customerAccountBalanceInquiry] FROM CustomerAccount");

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                customers.Add(new ModelCustomer() { customerAccountID = data.Rows[i][0].ToString(), customerAccountName = data.Rows[i][1].ToString(), customerAccountBalanceInquiry = data.Rows[i][2].ToString() });
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

    }




}