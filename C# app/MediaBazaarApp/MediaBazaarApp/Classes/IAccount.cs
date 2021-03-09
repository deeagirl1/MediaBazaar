using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    interface IAccount
    {
        int ID { get; set; }
        string Login { get; set; }
        string Password { get; set; }
    }
}
