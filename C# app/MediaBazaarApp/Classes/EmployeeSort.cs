using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaBazaarApp.Classes;
namespace MediaBazaarApp
{
    public class EmployeeSort : IComparer<ShopWorker>
    {
        public int Compare(ShopWorker x, ShopWorker y)
        {
            return x.FirstName.CompareTo(y.FirstName);
        }
    }
}
