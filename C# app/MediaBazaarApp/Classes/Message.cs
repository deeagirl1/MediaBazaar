using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class Message
    {
        public int ID { get; }
        public Person Sender { get; set; }
        public string Topic { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public Message(int ID, Person Sender, string Topic, string Text, DateTime dateTime)
        {
            this.ID = ID;
            this.Sender = Sender;
            this.Topic = Topic;
            this.Text = Text;
            this.DateTime = dateTime;
        }

    }
}
