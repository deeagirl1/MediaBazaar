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
            server = "localhost";
            dbi = "MediaBazaar";
            uid = "root";
            password = "";
        }

        //public DataBase()
        //{
        //    server = "studmysql01.fhict.local";
        //    dbi = "dbi453277";
        //    uid = "dbi453277";
        //    password = "lazytown";
        //}

        public override string ToString()
        {
            return $"server={server};database={dbi};uid={uid};password={password}; Allow User Variables=True; ";
        }
    }
}
