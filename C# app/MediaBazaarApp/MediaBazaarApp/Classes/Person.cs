using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    abstract class Person : IAccount 
    {
        private int id;
        private string firstName;
        private string lastName;
        private string email;
        private string password;

        //Id generation will be added to constructor later after we settle how to handle it
        

        //Create person from first name and lastname
        public Person(string firstName, string lastName)
        {

        }

        public int GetId()
        {
            throw new NotImplementedException();
        }

        public string GetLogin()
        {
            throw new NotImplementedException();
        }

        public string GetPassword()
        {
            throw new NotImplementedException();
        }

        public void SetId(int id)
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
