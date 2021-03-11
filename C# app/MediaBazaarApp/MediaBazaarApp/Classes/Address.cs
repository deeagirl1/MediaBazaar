using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class Address
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string ZipCode { get; set; }


        public override string ToString()
        {
            return $"{this.Country}, {this.City}, {this.Street}, {this.StreetNumber}, {this.ZipCode}";
        }

    }
}
