using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class User
    {
        public User() { }
        public User(string username, string email, string password, bool isAdmin)
        {
            Username = username;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
        }
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public ICollection<GroupUser> GroupUsers { get; set; } = new List<GroupUser>();
        public ICollection<Group> Groups { get; set; } = new List<Group>();
        public ICollection<GroupMessage> SentGroupMessages { get; set; } = new List<GroupMessage>();
        public ICollection<PrivateMessage> SentPrivateMessages { get; set; } = new List<PrivateMessage>();
        public ICollection<PrivateMessage> ReceivedPrivateMessages { get; set; } = new List<PrivateMessage>();
    }
}
