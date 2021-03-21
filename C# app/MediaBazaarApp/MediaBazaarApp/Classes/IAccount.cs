using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public interface IAccount
    {
        int ID { get; set; }
        int AccessLevel { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        
    }
}
