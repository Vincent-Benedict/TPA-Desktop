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
    /// Interaction logic for AnnualRentalPrice.xaml
    /// </summary>
    public partial class AnnualRentalPrice : Page
    {

        public ModelViewAnnualRental annualRental;

        public AnnualRentalPrice()
        {
            InitializeComponent();
            annualRental = new ModelViewAnnualRental();
        }

        private void Button_View(object sender, RoutedEventArgs e)
        {
            DGAnnualRentalPrice.ItemsSource = annualRental.grabDatabase();

        }
    }
}
