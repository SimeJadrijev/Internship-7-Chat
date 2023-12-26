using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class GroupMessage
    {
        public int GroupMessageID { get; set; }
        public int GroupID { get; set; }
        public int UserSenderID { get; set; }
        public string Content { get; set; }
        public DateTime MessageTime { get; set; }
        public Group Group { get; set; }
        public User UserSender { get; set; }
    }
}
