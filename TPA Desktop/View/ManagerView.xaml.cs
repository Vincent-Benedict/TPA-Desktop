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
using System.Windows.Shapes;
using TPA_Desktop.PageView.CustomerServiceTeller;
using TPA_Desktop.PageView.PageManager;

namespace TPA_Desktop.View
{
    /// <summary>
    /// Interaction logic for ManagerView.xaml
    /// </summary>
    public partial class ManagerView : Window
    {

        public Page currentPage;
        public MainWindow main;
        public ManagerView()
        {
            InitializeComponent();

            currentPage = new ManagerHome();

            pageManager.Content = currentPage;
        }

        private void Button_Home(object sender, RoutedEventArgs e)
        {
            currentPage = new ManagerHome();

            pageManager.Content = currentPage;
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Button_Request(object sender, RoutedEventArgs e)
        {
            currentPage = new RequestBroken();

            pageManager.Content = currentPage;
        }

        private void Button_View_Transaction(object sender, RoutedEventArgs e)
        {
            currentPage = new ViewTransaction();

            pageManager.Content = currentPage;
        }

        private void Button_Expenses(object sender, RoutedEventArgs e)
        {
            currentPage = new ExpensesRevenue();

            pageManager.Content = currentPage;
        }

        private void Button_Resign(object sender, RoutedEventArgs e)
        {
            currentPage = new ResignationEmployee();

            pageManager.Content = currentPage;
        }

        private void Button_Fire(object sender, RoutedEventArgs e)
        {
            currentPage = new FireEmployee();

            pageManager.Content = currentPage;
        }

        private void Button_HumanResource(object sender, RoutedEventArgs e)
        {
            currentPage = new ViewHumanResource();

            pageManager.Content = currentPage;
        }
    }
}
