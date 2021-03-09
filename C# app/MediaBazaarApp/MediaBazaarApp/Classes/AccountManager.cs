using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    class AccountManager
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
        public IAccount isValid(IAccount account)
        {
            foreach(IAccount a in this.accounts)
            {
                if(a.ID == account.ID &&
                    a.Password == account.Password)
                {
                    return a;
                }
            }
            return null;
        }
    }
}
