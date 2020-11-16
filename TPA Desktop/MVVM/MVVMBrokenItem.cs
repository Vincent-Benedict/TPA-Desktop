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


    public class ModelViewBrokenItem
    {


        // yang ini yg di binidng
        public ModelBrokenItem brokenItemModel;
        public List<ModelBrokenItem> brokenItemList;




        public ModelViewBrokenItem()
        {
            brokenItemModel = new ModelBrokenItem();
            brokenItemList = brokenItemModel.grabDatabase();
        }
        public List<ModelBrokenItem> grabDatabase()
        {
            brokenItemList = brokenItemModel.grabDatabase();

            return brokenItemList;
        }


        public void insertBrokenItem(String brokenItemName, String brokenItemLocation)
        {
            String x = "BR";

            if(brokenItemModel.grabDatabase().Count < 10)
            {
                x += "00";
                x += (brokenItemModel.grabDatabase().Count + 1).ToString();
            }
            else if (brokenItemModel.grabDatabase().Count < 100)
            {
                x += "0";
                x += (brokenItemModel.grabDatabase().Count + 1).ToString();
            }
            else
            {
                x += (brokenItemModel.grabDatabase().Count + 1).ToString();
            }

            brokenItemModel.insertBrokenItem(x, brokenItemName, brokenItemLocation);


        }

        public void softDeleteBrokenItem(String brokenItemID)
        {
            brokenItemModel.softDelete(brokenItemID);
        }

    }





    public class ModelBrokenItem
    {

        public String brokenItemID { get; set; }
        public String brokenItemName { get; set; }
        public String brokenItemLocation { get; set; }
        public String brokenItemStatus { get; set; }

        DatabaseBuilder db;

        public List<ModelBrokenItem> brokenItemList;

        public ModelBrokenItem()
        {
            db = new DatabaseBuilder();
        }
        public List<ModelBrokenItem> grabDatabase()
        {

            brokenItemList = new List<ModelBrokenItem>();

            DataTable data = db.viewCustomerAccountData("SELECT brokenItemID, brokenItemName, brokenItemLocation, brokenItemStatus FROM BrokenItem WHERE brokenItemStatus = 'Not-Fixed'");

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                brokenItemList.Add(new ModelBrokenItem() { brokenItemID = data.Rows[i][0].ToString(), brokenItemName = data.Rows[i][1].ToString(), 
                                                            brokenItemLocation = data.Rows[i][2].ToString(), brokenItemStatus = data.Rows[i][3].ToString() });
            }

            return brokenItemList;

        }

        public void insertBrokenItem(String x, String brokenItemName, String brokenItemLocation)
        {
            String query = "INSERT INTO BrokenItem (brokenItemID, brokenItemName, brokenItemLocation) VALUES (@brokenItemID, @brokenItemName, @brokenItemLocation)";

            db.insertBrokenItem(query, x, brokenItemName, brokenItemLocation);
        
        }

        public void softDelete(String brokenItemID)
        {
            String query = "UPDATE BrokenItem SET brokenItemStatus = 'Fixed' WHERE brokenItemID = @brokenItemID";

            db.softDeleteBrokenItem(query, brokenItemID);
        }


    }


}