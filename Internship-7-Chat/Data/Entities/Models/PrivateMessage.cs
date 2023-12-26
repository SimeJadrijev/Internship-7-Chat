﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class PrivateMessage
    {
        public int PrivateMessageID { get; set; }
        public int UserSenderID { get; set; }
        public int UserReceiverID { get; set; }
        public string Content { get; set; }
        public DateTime MessageTime { get; set; }
        public User UserSender { get; set; }
        public User UserReceiver { get; set; }
    }
}
