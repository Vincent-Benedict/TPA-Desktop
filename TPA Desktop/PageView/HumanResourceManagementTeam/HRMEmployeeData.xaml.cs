using System;
using System.Collections.Generic;
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

namespace TPA_Desktop.PageView.HumanResourceManagementTeam
{
    /// <summary>
    /// Interaction logic for HRMEmployeeData.xaml
    /// </summary>
    public partial class HRMEmployeeData : Page
    {
        public ModelViewEmployee employee1;
        public HRMEmployeeData()
        {
            InitializeComponent();
            employee1 = new ModelViewEmployee();
            DgEmployee.ItemsSource = employee1.grabDatabase();
        }

        private void Button_Search(object sender, RoutedEventArgs e)
        {
            if (!txtEmployeeID.Text.Equals(""))
            {
                DgEmployee.ItemsSource = employee1.grabDatabase(txtEmployeeID.Text);
            }
            else
            {
                MessageBox.Show("Please Input Employee ID !");
            }
        }
    }
}
