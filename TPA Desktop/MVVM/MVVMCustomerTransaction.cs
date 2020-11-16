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


    public class ModelViewCustomerTransaction
    {


        // yang ini yg di binidng
        public ModelCustomerTransaction customerModel;
        public List<ModelCustomerTransaction> customers;
        



        public ModelViewCustomerTransaction()
        {
            customerModel = new ModelCustomerTransaction();
            customers = customerModel.grabDatabase();
        }

        public void insertTransaction(String customerAccountID, String transaction, String amountMoney)
        {
            customerModel.insertTransaction(customerAccountID, transaction, amountMoney);
        }

        public List<ModelCustomerTransaction> grabDatabase()
        {
            customers = customerModel.grabDatabase();

            return customers;
        }

        public List<ModelCustomerTransaction> grabDatabase(String customerAccountID)
        {
            customers = customerModel.grabDatabaseWhere(customerAccountID);

            return customers;
        }

        public DataTable grabDatabaseDataTable()
        {
            DataTable data = new DataTable();
            data = customerModel.grabDatabaseDataTable();
            return data;
        }

    }





    public class ModelCustomerTransaction
    {


        public String customerAccountID { get; set; }
        public String customerAccountName { get; set; }
        public String transactionDate { get; set; }
        public String transaction { get; set; }
        public String amountMoney { get; set; }

        DatabaseBuilder db;

        public List<ModelCustomerTransaction> customerTransactions;

        public ModelCustomerTransaction()
        {
            db = new DatabaseBuilder();
        }

        public void insertTransaction(String customerAccountID, String transaction, String amountMoney)
        {
            db.insertTransactionCustomer("INSERT INTO CustomerTransaction VALUES(@customerAccountID, GETDATE(), @transaction, @amountMoney)", customerAccountID, transaction, Int32.Parse(amountMoney));
        }

        public List<ModelCustomerTransaction> grabDatabase()
        {

            customerTransactions = new List<ModelCustomerTransaction>();

            DataTable data = db.viewCustomerAccountData("SELECT ct.customerAccountID,ca.customerAccountName,ct.[transactionDate],ct.[transaction],ct.amountMoney " +
                                                        "FROM CustomerTransaction " +
                                                        "ct JOIN CustomerAccount ca " +
                                                        "ON ct.customerAccountID = ca.customerAccountID WHERE ca.active = 'active'");

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                customerTransactions.Add(new ModelCustomerTransaction() { customerAccountID = data.Rows[i][0].ToString(), customerAccountName=data.Rows[i][1].ToString(), transactionDate = data.Rows[i][2].ToString(), transaction = data.Rows[i][3].ToString(), amountMoney = data.Rows[i][4].ToString() });
            }

            return customerTransactions;

        }

        public List<ModelCustomerTransaction> grabDatabaseWhere(String customerAccountID)
        {
            customerTransactions = new List<ModelCustomerTransaction>();

            DataTable data = db.viewCustomerAccountData("SELECT ct.customerAccountID,ca.customerAccountName,ct.[transactionDate],ct.[transaction],ct.amountMoney " +
                                                        "FROM CustomerTransaction " +
                                                        "ct JOIN CustomerAccount ca " +
                                                        "ON ct.customerAccountID = ca.customerAccountID " +
                                                        "WHERE ct.customerAccountID = @customerAccountID and ca.active = 'active'", customerAccountID);

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                customerTransactions.Add(new ModelCustomerTransaction() { customerAccountID = data.Rows[i][0].ToString(), customerAccountName = data.Rows[i][1].ToString(), transactionDate = data.Rows[i][2].ToString(), transaction = data.Rows[i][3].ToString(), amountMoney = data.Rows[i][4].ToString() });
            }

            return customerTransactions;
        }

        public DataTable grabDatabaseDataTable()
        {
            DataTable data = new DataTable();
                
            data = db.viewCustomerAccountData("SELECT ct.customerAccountID,ca.customerAccountName,ct.[transactionDate],ct.[transaction],ct.amountMoney " +
                                                        "FROM CustomerTransaction " +
                                                        "ct JOIN CustomerAccount ca " +
                                                        "ON ct.customerAccountID = ca.customerAccountID WHERE ca.active = 'active'");

            return data;
        }

    }


}