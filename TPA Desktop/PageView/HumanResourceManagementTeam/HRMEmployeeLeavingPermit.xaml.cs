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
    /// Interaction logic for HRMEmployeeLeavingPermit.xaml
    /// </summary>
    public partial class HRMEmployeeLeavingPermit : Page
    {

        public ModelViewEmployeeLeavingPermit leavingPermit;
        public HRMEmployeeLeavingPermit()
        {
            InitializeComponent();
            leavingPermit = new ModelViewEmployeeLeavingPermit();
            DGEmployeeLeavingPermit.ItemsSource = leavingPermit.grabDatabase();
        }

        private void Button_Approved(object sender, RoutedEventArgs e)
        {
            if (!txtNumber.Text.Equals(""))
            {
                try
                {
                    if (!(Int32.Parse(txtNumber.Text) < 1 || Int32.Parse(txtNumber.Text) > leavingPermit.grabDatabase().Count()))
                    {
                        leavingPermit.updateStatusToApproved(txtNumber.Text);
                        DGEmployeeLeavingPermit.ItemsSource = leavingPermit.grabDatabase();
                        MessageBox.Show("Approved Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Please Input Valid Leaving Permit Number");
                        return;
                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Your Input not a number !");
                }
    
            }
            else
            {
                MessageBox.Show("Please Insert Leaving Permit Number");
            }
        }

        private void Button_Reject(object sender, RoutedEventArgs e)
        {
            if (!txtNumber.Text.Equals(""))
            {
                try
                {
                    if (!(Int32.Parse(txtNumber.Text) < 1 || Int32.Parse(txtNumber.Text) > leavingPermit.grabDatabase().Count()))
                    {
                        leavingPermit.updateStatusToReject(txtNumber.Text);
                        DGEmployeeLeavingPermit.ItemsSource = leavingPermit.grabDatabase();
                        MessageBox.Show("Reject Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Please Input Valid Leaving Permit Number");
                        return;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Your Input not a number !");
                }

            }
            else
            {
                MessageBox.Show("Please Insert Leaving Permit Number");
            }
        }
    }
}
