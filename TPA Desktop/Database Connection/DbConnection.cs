using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA_Desktop.Database_Connection
{

    public class DbConnection
    {

        #region singleton
        private static SqlConnection sqlCon;

        public static SqlConnection getInstance()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(@"Data Source=LAPTOP-83O3L92G; Initial Catalog=Kong Bu Bank; Integrated Security=True;");
            }

            return sqlCon;

        }

        private DbConnection()
        {

        }

        #endregion


    }
}
