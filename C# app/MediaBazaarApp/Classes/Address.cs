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
        public string Addition { get; set; }
        public Address(string country, string city, string street, string streetNr, string zipCode, string Addition)
        {
            this.Country = country;
            this.City = city;
            this.Street = street;
            this.StreetNumber = streetNr;
            this.ZipCode = zipCode;
            this.Addition = Addition;
        }
        public override string ToString()
        {
            return $"{this.Country}, {this.City}, {this.Street}, {this.StreetNumber}, {this.ZipCode}, {this.Addition}";
        }

    }
}
