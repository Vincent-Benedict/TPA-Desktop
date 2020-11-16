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

namespace TPA_Desktop.PageView.PageTeller
{
    public class ModelViewCustomerDetail
    {


        // yang ini yg di binidng
        public ModelCustomerDetail customerModel;
        public List<ModelCustomerDetail> customers;



        public ModelViewCustomerDetail()
        {
            customerModel = new ModelCustomerDetail();
            customers = customerModel.grabDatabase();
        }

        public List<ModelCustomerDetail> grabDatabase()
        {
            customers = customerModel.grabDatabase();

            return customers;
        }

        public void insertCustomerDetail(String customerName, String customerEmail, String customerPhoneNumber, String customerAddress, String customerAccountID)
        {
            int x = customers.Count()+1;
            customerModel.insertCustomerDetail(x, customerName, customerEmail, customerPhoneNumber, customerAddress, customerAccountID);
        }

    }

    public class ModelCustomerDetail
    {


        public String customerID { get; set; }
        public String customerName { get; set; }
        public String customerEmail { get; set; }
        public String customerPhoneNumber { get; set; }
        public String customerAddress { get; set; }
        public String customerAccountID{ get; set; }

        DatabaseBuilder db;

        public List<ModelCustomerDetail> customers;

        public ModelCustomerDetail()
        {
            db = new DatabaseBuilder();
        }

        public List<ModelCustomerDetail> grabDatabase()
        {

            customers = new List<ModelCustomerDetail>();

            DataTable data = db.viewCustomerAccountData("SELECT [customerID] ,[customerName] ,[customerEmail], [customerPhoneNumber], [customerAddress], [customerAccountID] FROM Customer");

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                customers.Add(new ModelCustomerDetail() { customerID = data.Rows[i][0].ToString(), customerName = data.Rows[i][1].ToString(), customerEmail = data.Rows[i][2].ToString(), customerPhoneNumber = data.Rows[i][3].ToString(), customerAddress = data.Rows[i][4].ToString(), customerAccountID = data.Rows[i][5].ToString() });
            }

            return customers;

        }

        public void insertCustomerDetail(int customerID, String customerName, String customerEmail, String customerPhoneNumber, String customerAddress, String customerAccountID)
        {
            db.insertCustomer("INSERT INTO Customer VALUES(@customerID, @customerName, @customerEmail, @customerPhoneNumber, @customerAddress, @customerAccountID)", customerID, customerName, customerEmail, customerPhoneNumber, customerAddress, customerAccountID);
        }

    }




}