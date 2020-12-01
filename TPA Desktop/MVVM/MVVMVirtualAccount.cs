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

namespace TPA_Desktop.MVVM
{

    public class ModelViewVirtualAccount
    {


        // yang ini yg di binidng
        public ModelVirtualAccount virtualAccountModel;
        public List<ModelVirtualAccount> listVirtualAccount;



        public ModelViewVirtualAccount()
        {
            virtualAccountModel = new ModelVirtualAccount();
            listVirtualAccount = virtualAccountModel.grabDatabase();
        }

        public List<ModelVirtualAccount> grabDatabase()
        {
            listVirtualAccount = virtualAccountModel.grabDatabase();

            return listVirtualAccount;
        }

        public void insertVirtualAccount(String customerAccountID, String virtualAccountName, String virtualAccountNumber)
        {
            String x = "VA";

            if(virtualAccountModel.grabDatabase().Count() < 10)
            {
                x += "00";
                x += (virtualAccountModel.grabDatabase().Count() + 1).ToString();
            }
            else if(virtualAccountModel.grabDatabase().Count() < 100)
            {
                x += "0";
                x += (virtualAccountModel.grabDatabase().Count() + 1).ToString();
            }
            else
            {
                x += (virtualAccountModel.grabDatabase().Count() + 1).ToString();
            }

            virtualAccountModel.insertVirtualAccount(x, customerAccountID, virtualAccountName, virtualAccountNumber);

        }

        //public int validateCustomerID(String txtCustomerID)
        //{
        //    int returnValue = customerModel.validateCustomerAccountIDInPaymentsBill(txtCustomerID);

        //    return returnValue;
        //}

        //public int pay(String customerAccountID, String paymentsType, String depositMoney)
        //{
        //    int returnValue = customerModel.payTheBill(customerAccountID, paymentsType, depositMoney);

        //    return returnValue;
        //}

        public int transferVirtualAccount(String virtualAccountID, String amountOfMoney)
        {
            int x = virtualAccountModel.updateBalance(virtualAccountID, amountOfMoney);

            return x;
        }

    }


    public class ModelVirtualAccount
    {

        public String virtualAccountID { get; set; }
        public String customerAccountID { get; set; }
        public String virtualAccountName { get; set; }
        public String virtualAccountNumber { get; set; }
        public String virtualAccountInquiry { get; set; }

        DatabaseBuilder db;

        public List<ModelVirtualAccount> virtualAccountList;

        public ModelVirtualAccount()
        {
            db = new DatabaseBuilder();
        }

        public List<ModelVirtualAccount> grabDatabase()
        {

            virtualAccountList = new List<ModelVirtualAccount>();


            DataTable data = db.viewCustomerAccountData("SELECT virtualAccountID, customerAccountID, virtualAccountName, virtualAccountNumber, virtualAccountBalanceInquiry FROM VirtualAccount");

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                virtualAccountList.Add(new ModelVirtualAccount() { virtualAccountID = data.Rows[i][0].ToString(), customerAccountID = data.Rows[i][1].ToString(), virtualAccountName = data.Rows[i][2].ToString(), virtualAccountNumber = data.Rows[i][3].ToString(), virtualAccountInquiry = data.Rows[i][4].ToString() });
            }

            return virtualAccountList;

        }

        //public int payTheBill(String customerAccountID, String paymentsType, String depositMoney)
        //{
        //    int returnValue = 0;

        //    returnValue = db.updateMoneyTellerPayments("UPDATE CustomerPaymentsBill SET paymentsBill = paymentsBill - @depositMoney WHERE customerAccountID = @customerAccountID AND paymentsType = @paymentsType AND paymentsBill >= @depositMoney", customerAccountID, paymentsType, Int32.Parse(depositMoney));

        //    return returnValue;
        //}


        //public int validateCustomerAccountIDInPaymentsBill(String txtCustomerID)
        //{
        //    int returnValue = 0;

        //    returnValue = db.validateCustomerID("SELECT COUNT(DISTINCT 1) FROM CustomerPaymentsBill WHERE customerAccountID = @customerAccountID", txtCustomerID);

        //    return returnValue;
        //}

        //public void softDeletedFromPaymentsBill()
        //{
        //    db.softDeleteDataWhenTheValueIsZero("UPDATE CustomerPaymentsBill SET billPaid = 'Paid' WHERE paymentsBill <= 0");
        //}


        public void insertVirtualAccount(String virtualAccountID, String customerAccountID, String virtualAccountName, String virtualAccountNumber)
        {
            String query = "INSERT INTO VirtualAccount (virtualAccountID, customerAccountID, virtualAccountName, virtualAccountNumber) VALUES (@virtualAccountID, @customerAccountID, @virtualAccountName, @virtualAccountNumber)";

            db.insertVirtualAccount(query, virtualAccountID, customerAccountID, virtualAccountName, virtualAccountNumber);

        }


        public int updateBalance(String virtualAccountID, String amountOfMoney)
        {
            String query = "UPDATE VirtualAccount SET virtualAccountBalanceInquiry += @amountOfMoney WHERE virtualAccountID = @virtualAccountID";

            int x = db.updateVirtualAccountBalanceInquiry(query, virtualAccountID, Int32.Parse(amountOfMoney));

            return x;
        }



    }



}