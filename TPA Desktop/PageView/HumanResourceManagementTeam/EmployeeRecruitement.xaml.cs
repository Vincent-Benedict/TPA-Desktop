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
    /// Interaction logic for EmployeeRecruitement.xaml
    /// </summary>
    public partial class EmployeeRecruitement : Page
    {
        public ModelViewNewEmployee newEmployee;
        public ModelViewEmployee employee;

        public EmployeeRecruitement()
        {
            InitializeComponent();
            newEmployee = new ModelViewNewEmployee();
            DGNewEmployee.ItemsSource = newEmployee.grabDatabase();
            employee = new ModelViewEmployee();
        }

        private void Button_Insert(object sender, RoutedEventArgs e)
        {
            if (!txtName.Text.Equals(""))
            {
                if (!txtEmail.Text.Equals(""))
                {
                    if (!txtPhone.Text.Equals(""))
                    {
                        newEmployee.insertNewEmployeeRecruitment(txtName.Text, txtEmail.Text, txtPhone.Text);
                        DGNewEmployee.ItemsSource = newEmployee.grabDatabase();
                        MessageBox.Show("Insert Success !");
                    }
                    else
                    {
                        MessageBox.Show("Fill the Phone !");
                    }
                }
                else
                {
                    MessageBox.Show("Fill the Email !");
                }
            }
            else
            {
                MessageBox.Show("Fill the Name !");
            }

        }

        private void Button_Welcome(object sender, RoutedEventArgs e)
        {
            if (!txtRecruitmentID.Text.Equals(""))
            {

                List<ModelNewEmployee> newEmployeeData = newEmployee.grabDatabase(txtRecruitmentID.Text);
                employee.insertNewStaffEmployee(newEmployeeData[0].employeeCandidateName, newEmployeeData[0].employeeCandidateEmail, newEmployeeData[0].employeeCandidatePhoneNumber);
                newEmployee.softDelete(txtRecruitmentID.Text);
                DGNewEmployee.ItemsSource = newEmployee.grabDatabase();
            }
            else
            {
                MessageBox.Show("Please Input Text RecruitmentID");
            }
        }

        private void Button_Cut(object sender, RoutedEventArgs e)
        {
            if (!txtRecruitmentID.Text.Equals(""))
            {
                newEmployee.softDelete(txtRecruitmentID.Text);
                DGNewEmployee.ItemsSource = newEmployee.grabDatabase();
                MessageBox.Show("Cut Success !");
            }
            else
            {
                MessageBox.Show("Please Input Text RecruitmentID");
            }
        }
    }
}
