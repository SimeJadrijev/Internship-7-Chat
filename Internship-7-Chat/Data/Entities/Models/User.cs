using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public List<Group> Groups { get; set; }
        public List<GroupMessage> SentGroupMessages { get; set; }
        public List<PrivateMessage> SentPrivateMessages { get; set; }
        public List<PrivateMessage> ReceivedPrivateMessages { get; set; }
    }
}
