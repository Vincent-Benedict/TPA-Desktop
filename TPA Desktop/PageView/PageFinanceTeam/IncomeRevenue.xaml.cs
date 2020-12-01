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
    /// Interaction logic for IncomeRevenue.xaml
    /// </summary>
    public partial class IncomeRevenue : Page
    {

        public ModelViewIncomeRevenue incomeRevenue;
        public IncomeRevenue()
        {
            InitializeComponent();
            incomeRevenue = new ModelViewIncomeRevenue();
        }

        private void Button_Track(object sender, RoutedEventArgs e)
        {
            DGTrack.ItemsSource = incomeRevenue.grabDatabase();
            MessageBox.Show("Track Income Revenue Success !");
        }
    }
}
