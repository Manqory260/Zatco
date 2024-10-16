using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatco
{
    class SqlHelper
    {
        SqlConnection con;
        public SqlHelper (string sqlConnction)
        {
            con = new SqlConnection(sqlConnction);
        }

        public bool Isconnection
        {
            get
            {
                if (con.State==System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                return true;
            }
        }
    }
}
