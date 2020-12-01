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


    public class ModelViewCreditCardTransaction
    {


        // yang ini yg di binidng
        public ModelCreditCardTransaction requestCreditCard;
        public List<ModelCreditCardTransaction> requestCreditCardList;

        public ModelViewCreditCardTransaction()
        {
            requestCreditCard = new ModelCreditCardTransaction();
            
        }

        public List<ModelCreditCardTransaction> grabDatabase(String customerAccountID)
        {
            requestCreditCardList = requestCreditCard.grabDatabase(customerAccountID);

            return requestCreditCardList;
        }

      


    }





    public class ModelCreditCardTransaction
    {

        public String customerAccountID { get; set; }
        public String creditCardID { get; set; }
        public String creditCardDetail { get; set; }
        public String creditCardPaymentsBill { get; set; }

        DatabaseBuilder db;

        public List<ModelCreditCardTransaction> requestCreditCard;

        public ModelCreditCardTransaction()
        {
            db = new DatabaseBuilder();
        }

        public List<ModelCreditCardTransaction> grabDatabase(String customerAccountID)
        {

            requestCreditCard = new List<ModelCreditCardTransaction>();

            DataTable data = db.viewCustomerAccountDataSpecific("SELECT customerAccountID, ccp.creditCardID, ccp.creditCardDetail, ccp.creditCardPaymentsBill FROM CreditCard cc JOIN CreditCardPayment ccp ON cc.creditCardID = ccp.creditCardID WHERE ccp.creditCardPaymentsBill > 0 AND customerAccountID = @customerAccountID", customerAccountID);

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                requestCreditCard.Add(new ModelCreditCardTransaction() { customerAccountID = data.Rows[i][0].ToString(), creditCardID = data.Rows[i][1].ToString(), creditCardDetail = data.Rows[i][2].ToString(), creditCardPaymentsBill = data.Rows[i][3].ToString() });
            }

            return requestCreditCard;

        }
       


    }


}