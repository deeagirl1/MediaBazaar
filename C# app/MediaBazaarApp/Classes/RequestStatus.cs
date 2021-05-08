using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class RequestStatus
    {
        public RequestStatus(int ID, string name)
        {
            this.Name = name;
            this.ID = ID;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        


    }
}
