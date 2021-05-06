using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class AnnouncementCollection : DBmanager
    {
        
        public List<Announcement> ToList()
        {
            string sql = $"SELECT * FROM annoucements";

            MySqlCommand cmd = new MySqlCommand(sql, this.GetConnection());
            MySqlDataReader reader = null;
            List<Announcement> announcements = new List<Announcement>();
            try
            {
                reader = this.OpenExecuteReader(cmd);
                while (reader.Read())
                {
                    Announcement announcement
                         = new Announcement(Convert.ToInt32(reader["ID"]),
                               Convert.ToString(reader["Title"]),
                               Convert.ToString(reader["Description"]),
                               Convert.ToDateTime(reader["PostDate"]));
                    announcements.Add(announcement);
                }
            }
            finally
            {
                this.CloseExecuteReader(reader);
            }
            return announcements;
        }

        public void AddAnnouncement(Announcement announcement)
        {
            string sql = "INSERT INTO annoucements(Title,Description) VALUES (@Title, @Description)";
            MySqlParameter[] prms = new MySqlParameter[2];
            prms[0] = new MySqlParameter("@Title", announcement.Title);
            prms[1] = new MySqlParameter("@Description", announcement.Description);
            this.ExecuteQuery(sql, prms);
        }

        public void EditAnnouncement(Announcement announcement)
        {
            string sql = "UPDATE annoucements SET Title=@Title, Description = @Description WHERE ID = @ID";

            MySqlParameter[] prms = new MySqlParameter[3];
            prms[0] = new MySqlParameter("@ID", announcement.ID);
            prms[1] = new MySqlParameter("@Title", announcement.Title);
            prms[2] = new MySqlParameter("@Description", announcement.Description);

            this.ExecuteQuery(sql, prms);
        }
    }
}
