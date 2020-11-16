using System;
using System.Collections.Generic;
using System.Data;
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
using TPA_Desktop.Database_Connection;
using TPA_Desktop.PageView.PageTeller;

namespace TPA_Desktop.MVVM
{


    public class ModelViewQueue
    {


        // yang ini yg di binidng
        public ModelQueue queueModel;
        public List<ModelQueue> queueList;




        public ModelViewQueue()
        {
            queueModel = new ModelQueue();
            queueList = queueModel.grabDatabase();
        }
        public List<ModelQueue> grabDatabase()
        {
            queueList = queueModel.grabDatabase();

            return queueList;
        }


        public void insertQueue(String x, String queueName)
        {
            


            queueModel.insertQueue(x, queueName);
        }

    }





    public class ModelQueue
    {

        public String queueNumber { get; set; }
        public String queueName { get; set; }

        DatabaseBuilder db;

        public List<ModelQueue> queueList;

        public ModelQueue()
        {
            db = new DatabaseBuilder();
        }
        public List<ModelQueue> grabDatabase()
        {

            queueList = new List<ModelQueue>();

            DataTable data = db.viewCustomerAccountData("SELECT [queueNumber], [queueName] FROM [Queue]");

            for (int i = 0; i < data.Rows.Count; ++i)
            {
                queueList.Add(new ModelQueue() { queueNumber = data.Rows[i][0].ToString(), queueName = data.Rows[i][1].ToString()});
            }

            return queueList;

        }

        public void insertQueue(String x, String queueName)
        {
            db.insertQueue("INSERT INTO [Queue] VALUES(@queueNumber, @queueName)", x, queueName);
        }
    }


}