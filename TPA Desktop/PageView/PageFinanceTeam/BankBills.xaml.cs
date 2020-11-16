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
    /// Interaction logic for BankBills.xaml
    /// </summary>
    public partial class BankBills : Page
    {
        public ModelViewBills bills;
        public BankBills()
        {
            InitializeComponent();
            bills = new ModelViewBills();
        }

        private void Button_View(object sender, RoutedEventArgs e)
        {
            DGBills.ItemsSource = bills.grabDatabase();
        }
    }
}
