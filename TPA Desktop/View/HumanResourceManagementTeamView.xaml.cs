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
using TPA_Desktop.PageView.HumanResourceManagementTeam;

namespace TPA_Desktop.View
{
    /// <summary>
    /// Interaction logic for HumanResourceManagementTeamView.xaml
    /// </summary>
    public partial class HumanResourceManagementTeamView : Window
    {

        public Page currentPage;
        public MainWindow main;

        public HumanResourceManagementTeamView()
        {
            InitializeComponent();
            currentPage = new HRMHome();
            pageHRMTeam.Content = currentPage;
        }

        private void Button_Home(object sender, RoutedEventArgs e)
        {
            currentPage = new HRMHome();
            pageHRMTeam.Content = currentPage;
        }

        private void Button_LogOut(object sender, RoutedEventArgs e)
        {
            main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Button_Employee_Data(object sender, RoutedEventArgs e)
        {
            currentPage = new HRMEmployeeData();
            pageHRMTeam.Content = currentPage;
        }

        private void Button_Employee_Recruitment(object sender, RoutedEventArgs e)
        {
            currentPage = new EmployeeRecruitement();
            pageHRMTeam.Content = currentPage;
        }

        private void Button_Position(object sender, RoutedEventArgs e)
        {
            currentPage = new AnnouncePosition();
            pageHRMTeam.Content = currentPage;
        }

        private void Button_Request(object sender, RoutedEventArgs e)
        {
            currentPage = new RequestBroken();
            pageHRMTeam.Content = currentPage;
        }
    }
}
