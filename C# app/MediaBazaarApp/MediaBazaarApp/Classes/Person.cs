using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class Person : IAccount 
    {
        private int id;
        private string firstName;
        private string lastName;
        private string email;

        public string GetLogin()
        {
            throw new NotImplementedException();
        }

        public string GetPassword()
        {
            throw new NotImplementedException();
        }

        public void SetLogin(string login)
        {
            throw new NotImplementedException();
        }

        public void SetPassword(string password)
        {
            throw new NotImplementedException();
        }

        public override string ToString() => firstName + " " + lastName;
    }
}
