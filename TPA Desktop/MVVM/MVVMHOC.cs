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


    public class ModelViewHOC
    {


        // yang ini yg di binidng
        public ModelHOC modelHOC;
        public List<ModelHOC> HOCList;

        public ModelViewHOC()
        {
            modelHOC = new ModelHOC();
            HOCList = modelHOC.grabDatabase();
        }


        public List<ModelHOC> grabDatabase()
        {
            HOCList = modelHOC.grabDatabase();

            return HOCList;
        }


        public void insertNewHOC(String customerAccountID, String grossIncomeDocumentID, String HOCTypes)
        {
            String x = "HOC";

            if (HOCList.Count() < 10)
            {
                x += "00";
                x += HOCList.Count().ToString();
            }
            else if (HOCList.Count() < 100)
            {
                x += "0";
                x += HOCList.Count().ToString();
            }
            else
            {
                x += HOCList.Count().ToString();
            }


            modelHOC.insertNewHOC(x, customerAccountID, grossIncomeDocumentID, HOCTypes);
        }



    }





    public class ModelHOC
    {

        public String HOCID { get; set; }
        public String customerAccountID { get; set; }
        public String grossIncomeDocumentID { get; set; }
        public String HOCTypes { get; set; }

        DatabaseBuilder db;

        public List<ModelHOC> loans;

        public ModelHOC()
        {
            db = new DatabaseBuilder();
        }

        public List<ModelHOC> grabDatabase()
        {

            loans = new List<ModelHOC>();

            DataTable data = db.viewCustomerAccountData("SELECT HOCID, customerAccountID, grossIncomeDocumentID, HOCTypes FROM HOC");

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                loans.Add(new ModelHOC()
                {
                    HOCID = data.Rows[i][0].ToString(),
                    customerAccountID = data.Rows[i][1].ToString(),
                    grossIncomeDocumentID = data.Rows[i][2].ToString(),
                    HOCTypes = data.Rows[i][3].ToString()
                });
            }

            return loans;

        }

        public void insertNewHOC(String HOCID, String customerAccountID, String grossIncomeDocumentID, String HOCTypes)
        {

            db.insertHOC("INSERT INTO HOC VALUES (@HOCID, @customerAccountID, @grossIncomeDocumentID, @HOCTypes)", HOCID, customerAccountID, grossIncomeDocumentID, HOCTypes);
        }


    }


}