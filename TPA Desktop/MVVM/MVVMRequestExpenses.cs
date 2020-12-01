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

    public class ModelViewRequestExpenses
    {


        // yang ini yg di binidng
        public ModelRequestExpenses virtualAccountModel;
        public List<ModelRequestExpenses> listVirtualAccount;



        public ModelViewRequestExpenses()
        {
            virtualAccountModel = new ModelRequestExpenses();
            listVirtualAccount = virtualAccountModel.grabDatabase();
        }

        public List<ModelRequestExpenses> grabDatabase()
        {
            listVirtualAccount = virtualAccountModel.grabDatabase();

            return listVirtualAccount;
        }

        public void insertRequestExpenses(String requestExpensesName, String requestExpensesMoney)
        {
            String x = "RE";

            if (virtualAccountModel.grabDatabase().Count() < 10)
            {
                x += "00";
                x += (virtualAccountModel.grabDatabase().Count() + 1).ToString();
            }
            else if (virtualAccountModel.grabDatabase().Count() < 100)
            {
                x += "0";
                x += (virtualAccountModel.grabDatabase().Count() + 1).ToString();
            }
            else
            {
                x += (virtualAccountModel.grabDatabase().Count() + 1).ToString();
            }

            virtualAccountModel.insertRequestExpenses(x, requestExpensesName, requestExpensesMoney);

        }

        public int transferVirtualAccount(String virtualAccountID, String amountOfMoney)
        {
            int x = virtualAccountModel.updateBalance(virtualAccountID, amountOfMoney);

            return x;
        }

        public int updateRequestApprove(String requestExpensesID)
        {
            int x = 0;
            x = virtualAccountModel.updateRequestApprove(requestExpensesID);
            return x;
        }

        public int updateRequestReject(String requestExpensesID)
        {
            int x = 0;
            x = virtualAccountModel.updateRequestReject(requestExpensesID);
            return x;
        }

    }


    public class ModelRequestExpenses
    {

        public String requestExpensesID { get; set; }
        public String requestExpensesName { get; set; }
        public String requestExpensesMoney { get; set; }
        public String requestExpensesStatus { get; set; }


        DatabaseBuilder db;

        public List<ModelRequestExpenses> requestExpensesList;

        public ModelRequestExpenses()
        {
            db = new DatabaseBuilder();
        }

        public List<ModelRequestExpenses> grabDatabase()
        {

            requestExpensesList = new List<ModelRequestExpenses>();


            DataTable data = db.viewCustomerAccountData("SELECT requestExpensesID, requestExpensesName, requestExpensesMoney, requestExpensesStatus FROM RequestExpenses");

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                requestExpensesList.Add(new ModelRequestExpenses() { requestExpensesID = data.Rows[i][0].ToString(), requestExpensesName = data.Rows[i][1].ToString(), requestExpensesMoney = data.Rows[i][2].ToString(), requestExpensesStatus = data.Rows[i][3].ToString()});
            }

            return requestExpensesList;

        }

        public void insertRequestExpenses(String requestExpensesID, String requestExpensesName, String requestExpensesMoney)
        {
            String query = "INSERT INTO RequestExpenses (requestExpensesID, requestExpensesName, requestExpensesMoney) VALUES (@requestExpensesID, @requestExpensesName, @requestExpensesMoney)";

            db.insertRequestExpenses(query, requestExpensesID, requestExpensesName, Int32.Parse(requestExpensesMoney));

        }

        public int updateRequestApprove(String requestExpensesID)
        {
            int x = 0;
            String query = "UPDATE RequestExpenses SET requestExpensesStatus = 'approved' WHERE requestExpensesID = @requestExpensesID";
            x = db.updateRequestExpenses(query, requestExpensesID);
            return x;
        }

        public int updateRequestReject(String requestExpensesID)
        {
            int x = 0;
            String query = "UPDATE RequestExpenses SET requestExpensesStatus = 'rejected' WHERE requestExpensesID = @requestExpensesID";
            x = db.updateRequestExpenses(query, requestExpensesID);
            return x;
        }


        public int updateBalance(String virtualAccountID, String amountOfMoney)
        {
            String query = "UPDATE VirtualAccount SET virtualAccountBalanceInquiry += @amountOfMoney WHERE virtualAccountID = @virtualAccountID";

            int x = db.updateVirtualAccountBalanceInquiry(query, virtualAccountID, Int32.Parse(amountOfMoney));

            return x;
        }



    }



}