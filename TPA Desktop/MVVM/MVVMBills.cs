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


    public class ModelViewBills
    {


        // yang ini yg di binidng
        public ModelBills modelBills;
        public List<ModelBills> billList;


        public ModelViewBills()
        {
            modelBills = new ModelBills();
            billList = modelBills.grabDatabase();
        }

        public List<ModelBills> grabDatabase()
        {
            billList = modelBills.grabDatabase();

            return billList;
        }
       
    }





    public class ModelBills
    {

        public String bankBillsID { get; set; }
        public String bankBillsName { get; set; }
        public String bankBillsAmount { get; set; }
       
        DatabaseBuilder db;

        public List<ModelBills> loans;

        public ModelBills()
        {
            db = new DatabaseBuilder();
        }

        public List<ModelBills> grabDatabase()
        {

            loans = new List<ModelBills>();

            DataTable data = db.viewCustomerAccountData("SELECT bankBillsID, bankBillsName, bankBillsAmount FROM BankBills");

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                loans.Add(new ModelBills()
                {
                    bankBillsID = data.Rows[i][0].ToString(),
                    bankBillsName = data.Rows[i][1].ToString(),
                    bankBillsAmount = data.Rows[i][2].ToString()
                });
            }

            return loans;

        }


    }


}