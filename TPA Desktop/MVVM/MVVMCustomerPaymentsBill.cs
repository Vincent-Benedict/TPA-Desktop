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

    public class ModelViewCustomerPaymentsBill
    {


        // yang ini yg di binidng
        public ModelCustomerPaymentsBill customerModel;
        public List<ModelCustomerPaymentsBill> customers;



        public ModelViewCustomerPaymentsBill()
        {
            customerModel = new ModelCustomerPaymentsBill();
            customers = customerModel.grabDatabase();
        }

        public List<ModelCustomerPaymentsBill> grabDatabase()
        {
            customers = customerModel.grabDatabase();

            return customers;
        }

        public int validateCustomerID(String txtCustomerID)
        {
            int returnValue = customerModel.validateCustomerAccountIDInPaymentsBill(txtCustomerID);

            return returnValue;
        }

        public int pay(String customerAccountID, String paymentsType, String depositMoney)
        {
            int returnValue = customerModel.payTheBill(customerAccountID, paymentsType, depositMoney);

            return returnValue;
        }

    }


    public class ModelCustomerPaymentsBill
    {


        public String customerAccountID { get; set; }
        public String customerAccountName { get; set; }
        public String paymentsType { get; set; }
        public String paymentsBill { get; set; }
        public String billPaid { get; set; }
       

        DatabaseBuilder db;

        public List<ModelCustomerPaymentsBill> customerPaymentsBill;

        public ModelCustomerPaymentsBill()
        {
            db = new DatabaseBuilder();
        }

        public List<ModelCustomerPaymentsBill> grabDatabase()
        {

            customerPaymentsBill = new List<ModelCustomerPaymentsBill>();

            softDeletedFromPaymentsBill();

            DataTable data = db.viewCustomerAccountData("SELECT cpb.customerAccountID ,ca.customerAccountName, cpb.paymentsType, cpb.paymentsBill, cpb.billPaid " +
                                                        "FROM CustomerPaymentsBill cpb JOIN CustomerAccount ca " +
                                                        "ON cpb.customerAccountID = ca.customerAccountID WHERE cpb.billPaid = 'Unpaid'");
            
            for (int i = 0; i < data.Rows.Count; ++i)
            {
                customerPaymentsBill.Add(new ModelCustomerPaymentsBill() { customerAccountID = data.Rows[i][0].ToString(), customerAccountName = data.Rows[i][1].ToString(), paymentsType = data.Rows[i][2].ToString(), paymentsBill = data.Rows[i][3].ToString(), billPaid = data.Rows[i][4].ToString()});
            }

            return customerPaymentsBill;

        }

        public int payTheBill(String customerAccountID, String paymentsType, String depositMoney)
        {
            int returnValue = 0;

            returnValue = db.updateMoneyTellerPayments("UPDATE CustomerPaymentsBill SET paymentsBill = paymentsBill - @depositMoney WHERE customerAccountID = @customerAccountID AND paymentsType = @paymentsType AND paymentsBill >= @depositMoney", customerAccountID, paymentsType, Int32.Parse(depositMoney));

            return returnValue;
        }


        public int validateCustomerAccountIDInPaymentsBill(String txtCustomerID)
        {
            int returnValue = 0;

            returnValue = db.validateCustomerID("SELECT COUNT(DISTINCT 1) FROM CustomerPaymentsBill WHERE customerAccountID = @customerAccountID", txtCustomerID);

            return returnValue;
        }

        public void softDeletedFromPaymentsBill()
        {
            db.softDeleteDataWhenTheValueIsZero("UPDATE CustomerPaymentsBill SET billPaid = 'Paid' WHERE paymentsBill <= 0");
        }
        
    }



}