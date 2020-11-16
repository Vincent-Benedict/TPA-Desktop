using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using TPA_Desktop.Facades;
using TPA_Desktop.View;
using TPA_Desktop.View.View_Strategy;

namespace TPA_Desktop
{

    public partial class MainWindow : Window
    {

        public viewFacades view;

        public MainWindow()
        {
            InitializeComponent();
            view = new viewFacades();
            

        }

        private void Login_Button(object sender, RoutedEventArgs e)
        {

            if(txtEmployeeID.Text.Equals("QM") || txtEmployeeID.Text.Equals("ATM"))
            {
                view.Facades(txtEmployeeID.Text);
                this.Close();
                return;
            }

            DatabaseBuilder db = new DatabaseBuilder();

            String query = "SELECT COUNT(1) FROM Employee WHERE employeeID = @employeeID AND employeePassword = @employeePassword";

            int count = db.validateEmployeeID(query, txtEmployeeID.Text, txtPassword.Password);

            if (count == 1)
            {
                String result = txtEmployeeID.Text.Substring(0, 3);
                view.Facades(result);
                this.Close();
            }
            else
            {
                MessageBox.Show("Username or password is incorrect");
            }

        }
           
    }

        #region logout
        //public void logout()
        //{
        //    home = new MainWindow();
        //    home.Show();
        //}
        #endregion

}
