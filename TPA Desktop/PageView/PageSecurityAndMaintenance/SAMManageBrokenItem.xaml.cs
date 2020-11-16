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

namespace TPA_Desktop.PageView.PageSecurityAndMaintenance
{
    /// <summary>
    /// Interaction logic for SAMManageBrokenItem.xaml
    /// </summary>
    public partial class SAMManageBrokenItem : Page
    {

        public ModelViewBrokenItem brokenItem1;

        public SAMManageBrokenItem()
        {
            InitializeComponent();
            brokenItem1 = new ModelViewBrokenItem();
            DGBrokeItem.ItemsSource = brokenItem1.grabDatabase();
        }

        private void Button_Insert(object sender, RoutedEventArgs e)
        {
            if (!txtBrokenItem.Text.Equals(""))
            {
                if (!txtLocation.Text.Equals(""))
                {
                    brokenItem1.insertBrokenItem(txtBrokenItem.Text, txtLocation.Text);
                    DGBrokeItem.ItemsSource = brokenItem1.grabDatabase();
                    MessageBox.Show("Inserted Successfully !");
                }
                else
                {
                    MessageBox.Show("Please Insert Location !");
                }


            }
            else
            {
                MessageBox.Show("Please Insert Broken Item Name !");
            }


        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            if (!txtBrokenID.Text.Equals(""))
            {
                brokenItem1.softDeleteBrokenItem(txtBrokenID.Text);
                MessageBox.Show("Sucessfully soft delete Data !");
                DGBrokeItem.ItemsSource = brokenItem1.grabDatabase();

            }
            else
            {
                MessageBox.Show("Please Insert Broken Item ID !");
            }

        }
    }
}