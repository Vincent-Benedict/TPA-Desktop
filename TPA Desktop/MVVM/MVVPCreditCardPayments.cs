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


    public class ModelViewCreditCardPayments
    {


        // yang ini yg di binidng
        public ModelCreditCardPayments requestCreditCard;
        public List<ModelCreditCardPayments> requestCreditCardList;




        public ModelViewCreditCardPayments()
        {
            requestCreditCard = new ModelCreditCardPayments();
            requestCreditCardList = requestCreditCard.grabDatabase();
        }

        public List<ModelCreditCardPayments> grabDatabase()
        {
            requestCreditCard.softDelete();
            requestCreditCardList = requestCreditCard.grabDatabase();
            return requestCreditCardList;
        }

        public List<ModelCreditCardPayments> grabDatabaseWhere(String x)
        {
            requestCreditCard.softDelete();
            requestCreditCardList = requestCreditCard.grabDatabaseWhere(x);
            return requestCreditCardList;
        }

        //public void insertCreditCard(String customerAccountID, String creditCardType)
        //{
        //    String x = "CC";

        //    if (requestCreditCardList.Count() < 10)
        //    {
        //        x += "00";
        //        x += requestCreditCardList.Count().ToString();
        //    }
        //    else if (requestCreditCardList.Count() < 100)
        //    {
        //        x += "0";
        //        x += requestCreditCardList.Count().ToString();
        //    }
        //    else
        //    {
        //        x += requestCreditCardList.Count().ToString();
        //    }


        //    requestCreditCard.insertNewCreditCard(customerAccountID, x, creditCardType);
        //}

        public int validateCreditCardID(String creditCardRequestID)
        {
            int x = -1;
            x = requestCreditCard.validateCreditCard(creditCardRequestID);
            return x;
        }

        public int validateCreditCardIDPayments(String creditCardRequestID)
        {
            int x = -1;
            x = requestCreditCard.validateCreditCardPayments(creditCardRequestID);
            return x;
        }

        public int pay(String creditCardPaymentsID, String amountMoney)
        {
            int x = 0;

            x = requestCreditCard.payCreditCard(creditCardPaymentsID, amountMoney);

            return x;
        }

        public int payTransfer(int amountOfMoney, String creditCardID)
        {
            int x = 0;

            x = requestCreditCard.updateCreditCardTransfer(amountOfMoney, creditCardID);

            return x;
        }

        public String selectSingleCustomerID(String creditCardID)
        {
            String x = requestCreditCard.selectSingleCustomerID(creditCardID);

            return x;
        }


    }





    public class ModelCreditCardPayments
    {
        public String creditCardPaymentsID { get; set; }
        public String creditCardID { get; set; }
        public String creditCardDetail { get; set; }
        public String creditCardPaymentsBill { get; set; }

        DatabaseBuilder db;

        public List<ModelCreditCardPayments> requestCreditCard;

        public ModelCreditCardPayments()
        {
            db = new DatabaseBuilder();
        }

        public List<ModelCreditCardPayments> grabDatabase()
        {

            requestCreditCard = new List<ModelCreditCardPayments>();

            DataTable data = db.viewCustomerAccountData("SELECT DISTINCT creditCardPaymentsID, ccp.creditCardID, creditCardDetail, creditCardPaymentsBill, ccp.active FROM CreditCardPayment ccp, CreditCard cc WHERE ccp.active = 'active'");

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                requestCreditCard.Add(new ModelCreditCardPayments() { creditCardPaymentsID = data.Rows[i][0].ToString(), creditCardID = data.Rows[i][1].ToString(), creditCardDetail = data.Rows[i][2].ToString(), creditCardPaymentsBill = data.Rows[i][3].ToString() });
            }

            return requestCreditCard;

        }

        public List<ModelCreditCardPayments> grabDatabaseWhere(String creditCardID)
        {
            requestCreditCard = new List<ModelCreditCardPayments>();

            DataTable data = db.viewCreditCardID("SELECT DISTINCT creditCardPaymentsID, ccp.creditCardID, creditCardDetail, creditCardPaymentsBill, ccp.active FROM CreditCardPayment ccp, CreditCard cc WHERE ccp.active = 'active' AND ccp.creditCardID = @creditCardID", creditCardID);

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                requestCreditCard.Add(new ModelCreditCardPayments() { creditCardPaymentsID = data.Rows[i][0].ToString(), creditCardID = data.Rows[i][1].ToString(), creditCardDetail = data.Rows[i][2].ToString(), creditCardPaymentsBill = data.Rows[i][3].ToString() });
            }

            return requestCreditCard;
        }

        public int validateCreditCard(String creditCardID)
        {
            int returnValue = -1;
            returnValue = db.validateCreditCard("SELECT COUNT(1) FROM CreditCard WHERE active='active' AND creditCardID = @creditCardID", creditCardID);
            return returnValue;
        }

        public int validateCreditCardPayments(String creditCardID)
        {
            int returnValue = -1;
            returnValue = db.validateCreditCard("SELECT COUNT(1) FROM CreditCardPayments WHERE active='active' AND creditCardID = @creditCardID", creditCardID);
            return returnValue;
        }

        public int payCreditCard(String creditCardPaymentsID,String amountMoney)
        {
            int returnValue = 0;

            returnValue = db.creditCardPayments("UPDATE CreditCardPayment SET creditCardPaymentsBill = creditCardPaymentsBill - @amountMoney WHERE creditCardPaymentsID = @creditCardPaymentsID", Int32.Parse(amountMoney), creditCardPaymentsID);

            return returnValue;
        }

        public int updateCreditCardTransfer(int amountOfMoney, String creditCardID)
        {
            int returnValue = 0;
            returnValue = db.creditCardPaymentsTransfer("UPDATE CustomerAccount SET customerAccountBalanceInquiry = customerAccountBalanceInquiry - @amountOfMoney FROM CustomerAccount ca, CreditCard cc WHERE ca.customerAccountID = cc.customerAccountID AND cc.customerAccountID = (SELECT customerAccountID FROM CreditCard WHERE creditCardID = @creditCardID)", amountOfMoney, creditCardID);
            return returnValue;
        }

        public void softDelete()
        {
            db.softDeleteDataWhenTheValueIsZero("UPDATE CreditCardPayment SET active = 'non-active' WHERE creditCardPaymentsBill <= 0");
        }

        public String selectSingleCustomerID(string creditCardID)
        {
            DataTable x = db.viewCustomerAccountID("SELECT customerAccountID FROM CreditCard WHERE creditCardID = @creditCardID", creditCardID);

            String y = x.Rows[0][0].ToString();

            return y;
        }

        //public void insertNewCreditCard(String customerId, String creditCardID, String creditCardType)
        //{
        //    db.insertCreditCard("INSERT INTO CreditCard(customerAccountID, creditCardID, creditCardType) VALUES(@customerAccountID, @creditCardID, @creditCardType)", customerId, creditCardID, creditCardType);
        //}

    }


}