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
    /// Interaction logic for AnnouncePosition.xaml
    /// </summary>
    public partial class AnnouncePosition : Page
    {

        public ModelViewEmployee employee;
        public AnnouncePosition()
        {
            InitializeComponent();
            employee = new ModelViewEmployee();
            DgEmployee.ItemsSource = employee.grabDatabase();
        }

        private void Button_Announce(object sender, ContextMenuEventArgs e)
        {
           
        }

        private void Annunce_Button(object sender, RoutedEventArgs e)
        {
            if (!txtEmployeeID.Text.Equals(""))
            {
                if (!txtPosition.Text.Equals(""))
                {
                    if (txtEmployeeID.Text.Substring(0, 3).Equals("STF"))
                    {
                        int res = employee.announcePosition(txtPosition.Text, txtEmployeeID.Text);
                        if (res == 1)
                        {
                            DgEmployee.ItemsSource = employee.grabDatabase();
                            MessageBox.Show("Congrats " + txtEmployeeID.Text);
                        }
                        else
                        {
                            MessageBox.Show("Invalid Position or Staff ID !");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Can't Update the Position");
                    }
                }
                else
                {
                    MessageBox.Show("Input Position !");
                }
            }
            else
            {
                MessageBox.Show("Input EmployeeID!");
            }
        }
    }
}
