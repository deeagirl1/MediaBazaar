using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class Announcement
    {
        public int ID { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostDate
        {
            get;
        }
        public Announcement(int ID, string title, string description, DateTime postDate )
        {
            this.ID = ID;
            this.Title = title;
            this.Description = description;
            this.PostDate = postDate;

        }
        public Announcement(string title, string description)
        {
          
            this.Title = title;
            this.Description = description;
         

        }
    }
}
