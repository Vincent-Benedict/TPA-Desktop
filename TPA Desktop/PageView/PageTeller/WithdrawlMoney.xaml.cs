﻿using System;
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

namespace TPA_Desktop.PageView.PageTeller
{
    /// <summary>
    /// Interaction logic for WithdrawlMoney.xaml
    /// </summary>
    public partial class WithdrawlMoney : Page
    {

        public ModelViewCustomer customers1;
        public ModelViewCustomerTransaction customersTransaction1;
        public WithdrawlMoney()
        {
            InitializeComponent();

            customers1 = new ModelViewCustomer();
            customersTransaction1 = new ModelViewCustomerTransaction();
            DgUsers.ItemsSource = customers1.grabDatabase();

        }

        private void Button_Verify_Account(object sender, RoutedEventArgs e)
        {
            int res = customers1.validateCustomerAccountID(txtCustomerID.Text);

            if(res == 1)
            {
                Hidden1.Visibility = Visibility.Visible;
                Hidden2.Visibility = Visibility.Visible;
                Hidden3.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Customer Account doesn't exist !");
            }
            
        }

        private void Button_Withdrawl(object sender, RoutedEventArgs e)
        {
            int depositMoney = (Int32.Parse(Hidden2.Text)*(-1));
            int result = customers1.updateDepositCustomer(txtCustomerID.Text, depositMoney);


            if (result == 0)
            {
                MessageBox.Show("There is no Customer Account Like That !");
            }
            else
            {
                customersTransaction1.insertTransaction(txtCustomerID.Text, "Withdrawl", Hidden2.Text);
                MessageBox.Show("Withdrawl Transaction Success !");
            }


            DgUsers.ItemsSource = customers1.grabDatabase();



        }
    }
}