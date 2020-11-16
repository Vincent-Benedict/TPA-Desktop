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


    public class ModelViewLoans
    {


        // yang ini yg di binidng
        public ModelLoans modelLoans;
        public List<ModelLoans> loansList;




        public ModelViewLoans()
        {
            modelLoans = new ModelLoans();
            loansList = modelLoans.grabDatabase();
        }

        //public void insertTransaction(String customerAccountID, String transaction, String amountMoney)
        //{
        //    requestCreditCard.insertTransaction(customerAccountID, transaction, amountMoney);
        //}

        public List<ModelLoans> grabDatabase()
        {
            loansList = modelLoans.grabDatabase();

            return loansList;
        }

        //public String grabData(String requestCreditCardID)
        //{
        //    String x = requestCreditCard.grabData(requestCreditCardID);

        //    return x;
        //}

        public void insertLoans(String customerAccountID, String guaranteeDocument, String reason, String typeLoan, String loansMoney)
        {
            String x = "LO";

            if (loansList.Count() < 10)
            {
                x += "00";
                x += loansList.Count().ToString();
            }
            else if (loansList.Count() < 100)
            {
                x += "0";
                x += loansList.Count().ToString();
            }
            else
            {
                x += loansList.Count().ToString();
            }


            modelLoans.insertNewLoans(x, customerAccountID, guaranteeDocument, reason, typeLoan, loansMoney);
        }

        //public int validateCreditCardRequestID(String creditCardRequestID)
        //{
        //    int x = -1;
        //    x = requestCreditCard.validateCard(creditCardRequestID);
        //    return x;
        //}


    }





    public class ModelLoans
    {

        public String loansID { get; set; }
        public String customerAccountID { get; set; }
        public String guaranteeDocument { get; set; }
        public String reason { get; set; }
        public String typeLoan { get; set; }
        public String loansMoney { get; set; }

        DatabaseBuilder db;

        public List<ModelLoans> loans;

        public ModelLoans()
        {
            db = new DatabaseBuilder();
        }

        public List<ModelLoans> grabDatabase()
        {

            loans = new List<ModelLoans>();

            DataTable data = db.viewCustomerAccountData("SELECT loansID, customerAccountID, guaranteeDocument, reason, typeLoan, loansMoney FROM Loans");

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                loans.Add(new ModelLoans() { loansID = data.Rows[i][0].ToString(), customerAccountID = data.Rows[i][1].ToString(), guaranteeDocument = data.Rows[i][2].ToString(),
                                            reason = data.Rows[i][3].ToString(), typeLoan = data.Rows[i][4].ToString(), loansMoney = data.Rows[i][5].ToString()
                });
            }

            return loans;

        }

        //public int validateCard(String creditCardID)
        //{
        //    int returnValue = -1;
        //    returnValue = db.validateCreditCard("SELECT COUNT(1) FROM RequestCreditCard WHERE approve='approved' AND active='active' AND requestCreditCardID = @creditCardID", creditCardID);
        //    return returnValue;
        //}

        //public String grabData(String customerAccountID)
        //{
        //    List<ModelLoans> temp = new List<ModelLoans>();

        //    DataTable data = db.viewRequestCreditCard("SELECT [CustomerAccountID] FROM RequestCreditCard WHERE approve='approved' AND active='active' AND requestCreditCardID = @requestCreditCardID", customerAccountID);

        //    for (int i = 0; i < data.Rows.Count; ++i)
        //    {
        //        temp.Add(new ModelLoans() { customerAccountID = data.Rows[i][0].ToString() });
        //    }

        //    String x = "No";
        //    x = data.Rows[0][0].ToString();

        //    return x;

        //}

        public void insertNewLoans(String loansID, String customerId, String guaranteeDocument, String reason, String typeLoan, String loansMoney)
        {
            
            db.insertLoans("INSERT INTO Loans VALUES (@loansID, @customerAccountID, @guaranteeDocument, @reason, @typeLoan, @loansMoney)", loansID, customerId, guaranteeDocument, reason, typeLoan, loansMoney);
        }


    }


}