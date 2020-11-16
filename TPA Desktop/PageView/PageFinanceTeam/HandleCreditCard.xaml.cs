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

namespace TPA_Desktop.PageView.PageFinanceTeam
{
    /// <summary>
    /// Interaction logic for HandleCreditCard.xaml
    /// </summary>
    public partial class HandleCreditCard : Page
    {
        public ModelViewCreditCardRequest creditCardRequest;
        
        public HandleCreditCard()
        {
            InitializeComponent();
            creditCardRequest = new ModelViewCreditCardRequest();
            DGRequestCreditCard.ItemsSource = creditCardRequest.grabDatabase();
        }

        private void approved(object sender, RoutedEventArgs e)
        {
            if (!txtCreditCardID.Text.Equals(""))
            {
                int res = 0; 
                res = creditCardRequest.updateRequestCreditCardID(txtCreditCardID.Text);
                if(res == 1)
                {
                    DGRequestCreditCard.ItemsSource = creditCardRequest.grabDatabase();
                    MessageBox.Show("Credit Card Approved !");
                }
                else
                {
                    MessageBox.Show("Invalid Request Credit Card ID");
                }


            }
            else
            {
                MessageBox.Show("Input Request Credit Card ID !");
            }
        }
    }
}
