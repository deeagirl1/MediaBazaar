using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp
{
    public class DataBase
    {
        private string server;
        private string dbi;
        private string uid;
        private string password;

        public DataBase()
        {
            server = "remotemysql.com";
            dbi = "MLH3bTxlO7";
            uid = "MLH3bTxlO7";
            password = "JIOJd7bNCZ";
        }

        public override string ToString()
        {
            return $"server={server};database={dbi};uid={uid};password={password};port=3306";
        }
    }
}
