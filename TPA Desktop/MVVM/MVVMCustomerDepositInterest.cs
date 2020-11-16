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


    public class ModelViewCustomerDepositInterest
    {


        // yang ini yg di binidng
        public ModelCustomerDepositInterest modelCustomerDepositInterest;
        public List<ModelCustomerDepositInterest> customerDepositInterestBills;


        public ModelViewCustomerDepositInterest()
        {
            modelCustomerDepositInterest = new ModelCustomerDepositInterest();
            customerDepositInterestBills = modelCustomerDepositInterest.grabDatabase();
        }

        public List<ModelCustomerDepositInterest> grabDatabase()
        {
            customerDepositInterestBills = modelCustomerDepositInterest.grabDatabase();

            return customerDepositInterestBills;
        }

    }





    public class ModelCustomerDepositInterest
    {

        public String customerDepositInterestID { get; set; }
        public String customerID { get; set; }
        public String customerDepositInterestPercent { get; set; }

        DatabaseBuilder db;

        public List<ModelCustomerDepositInterest> loans;

        public ModelCustomerDepositInterest()
        {
            db = new DatabaseBuilder();
        }

        public List<ModelCustomerDepositInterest> grabDatabase()
        {

            loans = new List<ModelCustomerDepositInterest>();

            DataTable data = db.viewCustomerAccountData("SELECT customerDepositInterestID, customerID, customerDepositInterestPercent from CustomerDepositInterest");

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                loans.Add(new ModelCustomerDepositInterest()
                {
                    customerDepositInterestID = data.Rows[i][0].ToString(),
                    customerID = data.Rows[i][1].ToString(),
                    customerDepositInterestPercent = data.Rows[i][2].ToString()
                });
            }

            return loans;

        }


    }


}