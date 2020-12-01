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
using TPA_Desktop.MVVM;
using Microsoft.Office.Interop.Excel;


namespace TPA_Desktop.PageView.PageManager
{
    /// <summary>
    /// Interaction logic for ViewTransaction.xaml
    /// </summary>
    public partial class ViewTransaction : System.Windows.Controls.Page
    {
        public ModelViewCustomerTransaction customerTransaction;
        public ViewTransaction()
        {
            InitializeComponent();
            customerTransaction = new ModelViewCustomerTransaction();
            
        }

        private void Button_View(object sender, RoutedEventArgs e)
        {

            System.Data.DataTable data = new System.Data.DataTable();

            data = customerTransaction.grabDatabaseDataTable();

            if(data.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcellApp = new Microsoft.Office.Interop.Excel.Application();
                xcellApp.Application.Workbooks.Add(Type.Missing);
                for(int i = 0; i < data.Rows.Count; i++)
                {
                    for(int j=0; j<data.Columns.Count; j++)
                    {
                        
                            xcellApp.Cells[i+1, j + 1] = data.Rows[i][j].ToString();
                    }
                }
                xcellApp.Columns.AutoFit();
                xcellApp.Visible = true;
            }
        }
    }
}
