using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class GroupMessage
    {
        public GroupMessage(string content, DateTime messageTime, int groupID, int userSenderID)
        {
            Content = content;
            MessageTime = messageTime;
            GroupID = groupID;
            UserSenderID = userSenderID;
        }
        public int GroupMessageID { get; set; }
        public int GroupID { get; set; }
        public int UserSenderID { get; set; }
        public string Content { get; set; }
        public DateTime MessageTime { get; set; }
        public Group Group { get; set; }
        public User UserSender { get; set; }
    }
}
