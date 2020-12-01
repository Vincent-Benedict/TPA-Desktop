using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPA_Desktop.View.View_Strategy;
using TPA_Desktop.View;

namespace TPA_Desktop.Facades
{
    public class viewFacades
    {
        public ViewMenuStrategy viewMenu;
        public viewFacades()
        {
            viewMenu = new ViewMenuStrategy();

        }

        public void Facades(String x)
        {
            if (x.Equals("TLR"))
            {
                viewMenu.setStrategyWindow(new TellerView());
            }
            else if (x.Equals("CSC"))
            {
                viewMenu.setStrategyWindow(new CustomerServiceView());
            }
            else if (x.Equals("SMT"))
            {
                viewMenu.setStrategyWindow(new SecurityAndMaintenanceTeamView());
            }
            else if (x.Equals("HRM"))
            {
                viewMenu.setStrategyWindow(new HumanResourceManagementTeamView());
            }
            else if (x.Equals("FIN"))
            {
                viewMenu.setStrategyWindow(new FinanceTeamView());
            }
            else if (x.Equals("MGR"))
            {
                viewMenu.setStrategyWindow(new ManagerView());
            }
            else if (x.Equals("QM"))
            {
                viewMenu.setStrategyWindow(new QueueMachine());
            }
            else if (x.Equals("ATM"))
            {
                viewMenu.setStrategyWindow(new ATMMachine());
            }
            
        }




    }
}
