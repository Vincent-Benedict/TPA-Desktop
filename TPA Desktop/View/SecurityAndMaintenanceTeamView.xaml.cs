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
using TPA_Desktop.PageView.PageSecurityAndMaintenance;

namespace TPA_Desktop.View
{
    /// <summary>
    /// Interaction logic for SecurityAndMaintenanceTeamView.xaml
    /// </summary>
    public partial class SecurityAndMaintenanceTeamView : Window
    {

        public Page currentPage;
        public MainWindow main;


        public SecurityAndMaintenanceTeamView()
        {
            InitializeComponent();

            currentPage = new SAMHome();

            pageSAMTeam.Content = currentPage;
        }

        private void Button_Home(object sender, RoutedEventArgs e)
        {
            currentPage = new SAMHome();

            pageSAMTeam.Content = currentPage;
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Button_Manage(object sender, RoutedEventArgs e)
        {
            currentPage = new SAMManageBrokenItem();

            pageSAMTeam.Content = currentPage;
        }

        private void Button_Request(object sender, RoutedEventArgs e)
        {
            currentPage = new SAMReqeustExpenses();

            pageSAMTeam.Content = currentPage;
        }
    }
}
