using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class AccountManager
    {
        private List<IAccount> accounts;

        public AccountManager()
        {
            accounts = new List<IAccount>();
        }

        public bool Add(IAccount account)
        {
            if (this.exists(account))
                return false;
            this.accounts.Add(account);
            return true;
        }
        public bool Remove(IAccount account)
        {
            this.accounts.RemoveAll(a => a.ID == account.ID);
            return true;
        }

        private bool exists(IAccount account)
        {
            foreach(IAccount a in this.accounts)
            {
                if (a.ID == account.ID) { return true; }
            }
            return false;
        }
        public IAccount isValid(string login, string password)
        {
            foreach(IAccount a in this.accounts)
            {
                if(a.Login == login &&
                    a.Password == password)
                {
                    return a;
                }
            }
            return null;
        }

        public int changePassword(string login, string currentPass, string newPass, string newPassRepeat)
        {
            IAccount account = this.isValid(login, currentPass);
            if (this.isValid(login, currentPass) is Person)
            {
                if(newPass == newPassRepeat)
                {
                    account.Password = newPass;
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            else
            {
                return -1;
            }
            
        }
    }
}
