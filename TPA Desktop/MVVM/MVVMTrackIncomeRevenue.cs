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

    public class ModelViewIncomeRevenue
    {


        // yang ini yg di binidng
        public ModelIncomeRevenue virtualAccountModel;
        public List<ModelIncomeRevenue> listVirtualAccount;



        public ModelViewIncomeRevenue()
        {
            virtualAccountModel = new ModelIncomeRevenue();
            listVirtualAccount = virtualAccountModel.grabDatabase();
        }

        public List<ModelIncomeRevenue> grabDatabase()
        {
            listVirtualAccount = virtualAccountModel.grabDatabase();

            return listVirtualAccount;
        }

        public DataTable grabDatabaseDataTable()
        {
            DataTable data = new DataTable();
            data = virtualAccountModel.grabDatabaseDataTable();
            return data;
        }

    }


    public class ModelIncomeRevenue
    {

        public String incomeRevenueID { get; set; }
        public String customerID { get; set; }
        public String incomeRevenueName { get; set; }
        public String incomeRevenueMoney { get; set; }

        DatabaseBuilder db;

        public List<ModelIncomeRevenue> virtualAccountList;

        public ModelIncomeRevenue()
        {
            db = new DatabaseBuilder();
        }

        public List<ModelIncomeRevenue> grabDatabase()
        {

            virtualAccountList = new List<ModelIncomeRevenue>();


            DataTable data = db.viewCustomerAccountData("SELECT incomeRevenueID, customerID, incomeRevenueName, incomeRevenueMoney FROM IncomeRevenue");

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                virtualAccountList.Add(new ModelIncomeRevenue() { incomeRevenueID = data.Rows[i][0].ToString(), customerID = data.Rows[i][1].ToString(), incomeRevenueName = data.Rows[i][2].ToString(), incomeRevenueMoney = data.Rows[i][3].ToString()});
            }

            return virtualAccountList;

        }


        
        public DataTable grabDatabaseDataTable()
        {
            DataTable data = new DataTable();

            data = db.viewCustomerAccountData("SELECT incomeRevenueID, customerID, incomeRevenueName, incomeRevenueMoney FROM IncomeRevenue");

            return data;
        }
        




    }



}