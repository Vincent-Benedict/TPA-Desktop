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

namespace TPA_Desktop.PageView.PageSecurityAndMaintenance
{
    /// <summary>
    /// Interaction logic for SAMReqeustExpenses.xaml
    /// </summary>
    public partial class SAMReqeustExpenses : Page
    {

        public ModelViewRequestExpenses listRequest;

        public SAMReqeustExpenses()
        {
            InitializeComponent();
            listRequest = new ModelViewRequestExpenses();
            DGExpenses.ItemsSource = listRequest.grabDatabase();
        }

        private void Button_Insert(object sender, RoutedEventArgs e)
        {

            if (!txtRequestName.Text.Equals(""))
            {
                if (!txtRequestMoney.Text.Equals(""))
                {
                    listRequest.insertRequestExpenses(txtRequestName.Text, txtRequestMoney.Text);
                    DGExpenses.ItemsSource = listRequest.grabDatabase();
                    MessageBox.Show("Request Successfully Inserted !");
                }
                else
                {
                    MessageBox.Show("Please Input amount of money !");
                }


            }
            else
            {
                MessageBox.Show("Please Input Request Name");
            }


        }
    }
}
