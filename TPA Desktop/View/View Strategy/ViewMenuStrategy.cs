using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TPA_Desktop.View.View_Strategy
{
    public class ViewMenuStrategy
    {

        Window currWndow;

        public ViewMenuStrategy()
        {

        }

        public void setStrategyWindow(Window x)
        {
            currWndow = x;
            showMenu();
        }

        public void showMenu()
        {
            currWndow.Show();
        }

    }
}
