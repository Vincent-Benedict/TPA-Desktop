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


    public class ModelViewAnnualRental
    {


        // yang ini yg di binidng
        public ModelAnnualRental modelBills;
        public List<ModelAnnualRental> billList;


        public ModelViewAnnualRental()
        {
            modelBills = new ModelAnnualRental();
            billList = modelBills.grabDatabase();
        }

        public List<ModelAnnualRental> grabDatabase()
        {
            billList = modelBills.grabDatabase();

            return billList;
        }

    }





    public class ModelAnnualRental
    {

        public String annualRentalPriceID { get; set; }
        public String annualYear { get; set; }
        public String annualCost { get; set; }

        DatabaseBuilder db;

        public List<ModelAnnualRental> loans;

        public ModelAnnualRental()
        {
            db = new DatabaseBuilder();
        }

        public List<ModelAnnualRental> grabDatabase()
        {

            loans = new List<ModelAnnualRental>();

            DataTable data = db.viewCustomerAccountData("SELECT annualRentalPriceID, annualYear, annualCost FROM AnnualRentalPrice");

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                loans.Add(new ModelAnnualRental()
                {
                    annualRentalPriceID = data.Rows[i][0].ToString(),
                    annualYear = data.Rows[i][1].ToString(),
                    annualCost = data.Rows[i][2].ToString()
                });
            }

            return loans;

        }


    }


}