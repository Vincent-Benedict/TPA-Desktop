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


    public class ModelViewCreditCardRequest
    {


        // yang ini yg di binidng
        public ModelCreditCardRequest requestCreditCard;
        public List<ModelCreditCardRequest> requestCreditCardList;




        public ModelViewCreditCardRequest()
        {
            requestCreditCard = new ModelCreditCardRequest();
            requestCreditCardList = requestCreditCard.grabDatabase();
        }

        //public void insertTransaction(String customerAccountID, String transaction, String amountMoney)
        //{
        //    requestCreditCard.insertTransaction(customerAccountID, transaction, amountMoney);
        //}

        public void insertCreditCardRequest(String customerAccountID, String familyCardID, String identityCardID)
        {
            String x = "RC";
            if(requestCreditCard.grabDatabase().Count < 10)
            {
                x += "00";
                x += (requestCreditCard.grabDatabase().Count + 1).ToString();
            }
            else if(requestCreditCard.grabDatabase().Count < 100)
            {
                x += "0";
                x += (requestCreditCard.grabDatabase().Count + 1).ToString();

            }
            else
            {
                x += (requestCreditCard.grabDatabase().Count + 1).ToString();
            }

            requestCreditCard.insertRequestCreditCard(customerAccountID, x, familyCardID, identityCardID);

        }

        public List<ModelCreditCardRequest> grabDatabase()
        {
            requestCreditCardList = requestCreditCard.grabDatabase();

            return requestCreditCardList;
        }

        public void updateActiveAccount(String requestCreditCardID)
        {
            requestCreditCard.updateActiveAccount(requestCreditCardID);
        }

        public int updateRequestCreditCardID(String requestCreditCardID)
        {
            int returnValue = 0;
            returnValue = requestCreditCard.updateRequestCreditCardApproved(requestCreditCardID);
            return returnValue;
        }

   

    }





    public class ModelCreditCardRequest
    {

        public String customerAccountID { get; set; }
        public String requestCreditCardID{ get; set; }
        public String familyCardID { get; set; }
        public String identityCardID { get; set; }
        public String approve { get; set; }

        DatabaseBuilder db;

        public List<ModelCreditCardRequest> requestCreditCard;

        public ModelCreditCardRequest()
        {
            db = new DatabaseBuilder();
        }

        public void insertRequestCreditCard(String customerAccountID, String reqeustCreditCardID, String familyCardID, String identityCardID)
        {
            db.insertRequestCreditCardRequest("INSERT INTO RequestCreditCard (customerAccountID, requestCreditCardID, familyCardID, identityCardID) VALUES(@customerAccountID, @requestCreditCardID, @familyCardID, @identityCardID)", customerAccountID, reqeustCreditCardID, familyCardID, identityCardID);
        }

        public List<ModelCreditCardRequest> grabDatabase()
        {

            requestCreditCard = new List<ModelCreditCardRequest>();

            DataTable data = db.viewCustomerAccountData("SELECT [CustomerAccountID], [requestCreditCardID], [familyCardID], [identityCardID], [approve] FROM RequestCreditCard WHERE active = 'active'");

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                requestCreditCard.Add(new ModelCreditCardRequest() { customerAccountID = data.Rows[i][0].ToString(), requestCreditCardID = data.Rows[i][1].ToString(), familyCardID = data.Rows[i][2].ToString(), identityCardID = data.Rows[i][3].ToString(), approve = data.Rows[i][4].ToString() });
            }

            return requestCreditCard;

        }

        public void updateActiveAccount(String requestCreditCardID)
        {
            db.softDeleteDataWhenTheValueIsZero("UPDATE RequestCreditCard SET active = 'not-active' WHERE requestCreditCardID = @requestCreditCardID", requestCreditCardID);
        }

        public int updateRequestCreditCardApproved(String requestCreditCardID)
        {
            int returnValue = 0;
            returnValue = db.updateRequestCreditCard("UPDATE RequestCreditCard SET approve = 'approved' WHERE requestCreditCardID = @requestCreditCardID", requestCreditCardID);
            return returnValue;
        }

    }


}