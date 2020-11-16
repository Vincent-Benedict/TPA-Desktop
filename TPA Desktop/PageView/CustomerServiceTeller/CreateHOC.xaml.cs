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
using TPA_Desktop.PageView.PageTeller;

namespace TPA_Desktop.PageView.CustomerServiceTeller
{
    /// <summary>
    /// Interaction logic for CreateHOC.xaml
    /// </summary>
    public partial class CreateHOC : Page
    {

        public ModelViewCustomer1 customers1;
        public ModelViewHOC hoc1;
        public CreateHOC()
        {
            InitializeComponent();
            customers1 = new ModelViewCustomer1();
            hoc1 = new ModelViewHOC();
            DGHOC.ItemsSource = hoc1.grabDatabase();
        }

        private void Button_Verify(object sender, RoutedEventArgs e)
        {
            int res = customers1.validateCustomerAccountID(txtCustomerID.Text);

            if (res == 1)
            {
                Hidden1.Visibility = Visibility.Visible;
                txtGrossIncomeDocument.Visibility = Visibility.Visible;
                Hidden2.Visibility = Visibility.Visible;
                txtHOCType.Visibility = Visibility.Visible;
                Hidden3.Visibility = Visibility.Visible; 

            }
            else
            {
                MessageBox.Show("Customer ID Invalid !");
            }

        }

        private void Button_Create(object sender, RoutedEventArgs e)
        {
            if (!txtGrossIncomeDocument.Text.Equals(""))
            {
                if(txtHOCType.Text.Equals("Flexible") || txtHOCType.Text.Equals("Non-Flexible"))
                {
                    hoc1.insertNewHOC(txtCustomerID.Text, txtGrossIncomeDocument.Text, txtHOCType.Text);
                    DGHOC.ItemsSource = hoc1.grabDatabase();
                    MessageBox.Show("Input HOC Success !");
                }
                else
                {
                    MessageBox.Show("Fill HOC Types with Flexible / Non-Flexible");
                }


            }
            else
            {
                MessageBox.Show("Fill Gross Income Document !");
            }
        }
    }
}
