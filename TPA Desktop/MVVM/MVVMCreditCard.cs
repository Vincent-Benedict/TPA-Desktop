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


    public class ModelViewCreditCard
    {


        // yang ini yg di binidng
        public ModelCreditCard requestCreditCard;
        public List<ModelCreditCard> requestCreditCardList;




        public ModelViewCreditCard()
        {
            requestCreditCard = new ModelCreditCard();
            requestCreditCardList = requestCreditCard.grabDatabase();
        }

        //public void insertTransaction(String customerAccountID, String transaction, String amountMoney)
        //{
        //    requestCreditCard.insertTransaction(customerAccountID, transaction, amountMoney);
        //}

        public List<ModelCreditCard> grabDatabase()
        {
            requestCreditCardList = requestCreditCard.grabDatabase();

            return requestCreditCardList;
        }

        public String grabData(String requestCreditCardID)
        {
            String x = requestCreditCard.grabData(requestCreditCardID);

            return x;
        }

        public void insertCreditCard(String customerAccountID, String creditCardType)
        {
            String x = "CC";
            
            if(requestCreditCardList.Count() < 10)
            {
                x += "00";
                x += (requestCreditCardList.Count()+1).ToString();
            }
            else if (requestCreditCardList.Count() < 100)
            {
                x += "0";
                x += (requestCreditCardList.Count() + 1).ToString();
            }
            else
            {
                x += (requestCreditCardList.Count() + 1).ToString();
            }
            

            requestCreditCard.insertNewCreditCard(customerAccountID, x, creditCardType);
        }

        public int validateCreditCardRequestID(String creditCardRequestID)
        {
            int x = -1;
            x = requestCreditCard.validateCard(creditCardRequestID);
            return x;
        }


        public int validateCardInCreditCard(String customerAccountID)
        {
            int x = -1;
            x = requestCreditCard.validateCardInCreditCard(customerAccountID);
            return x;
        }

        public int validateCreditCardTransaction(String customerAccountID)
        {
            int x = 0;
            x = requestCreditCard.checkCreditCardTransaction(customerAccountID);
            return x;
        }




    }





    public class ModelCreditCard
    {

        public String customerAccountID { get; set; }
        public String CreditCardID { get; set; }
        public String CreditCardType { get; set; }

        DatabaseBuilder db;

        public List<ModelCreditCard> requestCreditCard;

        public ModelCreditCard()
        {
            db = new DatabaseBuilder();
        }

        //public void insertTransaction(String customerAccountID, String transaction, String amountMoney)
        //{
        //    db.insertTransactionCustomer("INSERT INTO CustomerTransaction VALUES(@customerAccountID, GETDATE(), @transaction, @amountMoney)", customerAccountID, transaction, Int32.Parse(amountMoney));
        //}

        public List<ModelCreditCard> grabDatabase()
        {

            requestCreditCard = new List<ModelCreditCard>();

            DataTable data = db.viewCustomerAccountData("SELECT [CustomerAccountID], [CreditCardID], [CreditCardType] FROM CreditCard WHERE active='active'");

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                requestCreditCard.Add(new ModelCreditCard() { customerAccountID = data.Rows[i][0].ToString(), CreditCardID = data.Rows[i][1].ToString(), CreditCardType = data.Rows[i][2].ToString()});
            }

            return requestCreditCard;

        }

        public int validateCard(String creditCardID)
        {
            int returnValue = -1;
                returnValue = db.validateCreditCard("SELECT COUNT(1) FROM RequestCreditCard WHERE approve='approved' AND active='active' AND requestCreditCardID = @creditCardID", creditCardID);
            return returnValue;
        }

        public int validateCardInCreditCard(String customerAccountID) 
        {
            int returnValue = -1;

            String query = "SELECT COUNT(1) FROM CreditCard WHERE customerAccountID = @customerAccountID";

            returnValue = db.validateCardInCreditCard(query, customerAccountID);


            return returnValue;
        }

        public String grabData(String customerAccountID)
        {
            List<ModelCreditCard> temp = new List<ModelCreditCard>();

            DataTable data = db.viewRequestCreditCard("SELECT [CustomerAccountID] FROM RequestCreditCard WHERE approve='approved' AND active='active' AND requestCreditCardID = @requestCreditCardID", customerAccountID);

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                temp.Add(new ModelCreditCard() { customerAccountID = data.Rows[i][0].ToString()});
            }

            String x = "No";
            x = data.Rows[0][0].ToString();

            return x;

        }

        public void insertNewCreditCard(String customerId, String creditCardID, String creditCardType)
        {
            db.insertCreditCard("INSERT INTO CreditCard(customerAccountID, creditCardID, creditCardType) VALUES(@customerAccountID, @creditCardID, @creditCardType)", customerId, creditCardID, creditCardType);
        }

        //public List<ModelRequestCreditCard> grabDatabaseWhere(String customerAccountID)
        //{
        //    customerTransactions = new List<ModelRequestCreditCard>();

        //    DataTable data = db.viewCustomerAccountData("SELECT ct.customerAccountID,ca.customerAccountName,ct.[transactionDate],ct.[transaction],ct.amountMoney " +
        //                                                "FROM CustomerTransaction " +
        //                                                "ct JOIN CustomerAccount ca " +
        //                                                "ON ct.customerAccountID = ca.customerAccountID " +
        //                                                "WHERE ct.customerAccountID = @customerAccountID and ca.active = 'active'", customerAccountID);

        //    for (int i = 0; i < data.Rows.Count; ++i)
        //    {
        //        customerTransactions.Add(new ModelRequestCreditCard() { customerAccountID = data.Rows[i][0].ToString(), customerAccountName = data.Rows[i][1].ToString(), transactionDate = data.Rows[i][2].ToString(), transaction = data.Rows[i][3].ToString(), amountMoney = data.Rows[i][4].ToString() });
        //    }

        //    return customerTransactions;
        //}


        public int checkCreditCardTransaction(String customerAccountID)
        {
            int x = 0;
            String query = "SELECT COUNT(1) FROM CreditCardPayment WHERE creditCardID = (SELECT creditCardID FROM CreditCard WHERE customerAccountID = @customerAccountID)";
            x = db.validateCreditCardTransaction(query, customerAccountID);
            return x;   
        }


    }


}