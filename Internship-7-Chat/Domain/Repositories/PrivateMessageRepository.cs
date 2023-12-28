using Data.Entities;
using Data.Entities.Models;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class PrivateMessageRepository : BaseRepository
    {
        public PrivateMessageRepository(ChatAppDbContext dbContext) : base (dbContext) { }  

        public ResponseResultType Add (PrivateMessage privateMessage)
        {
            DbContext.PrivateMessages.Add(privateMessage);

            return SaveChanges();
        }
        public ResponseResultType Delete (int id)
        {
            var privateMessageForDelete = DbContext.PrivateMessages.Find(id);
            if (privateMessageForDelete is null)
                return ResponseResultType.NotFound;

            DbContext.PrivateMessages.Remove(privateMessageForDelete); 
            
            return SaveChanges();
        }

        public ResponseResultType Update (PrivateMessage privateMessage, int id)
        {
            var privateMessageForUpdate = DbContext.PrivateMessages.Find(id);
            if (privateMessageForUpdate is null)
                return ResponseResultType.NotFound;

            privateMessageForUpdate.PrivateMessageID = privateMessage.PrivateMessageID;
            privateMessageForUpdate.MessageTime = privateMessage.MessageTime;
            privateMessageForUpdate.UserReceiverID = privateMessage.UserReceiverID;
            privateMessageForUpdate.UserReceiver = privateMessage.UserReceiver;
            privateMessageForUpdate.Content = privateMessage.Content;
            privateMessageForUpdate.UserSender = privateMessage.UserSender;
            privateMessageForUpdate.UserSenderID = privateMessage.UserSenderID;

            return SaveChanges();
        }

        public PrivateMessage? GetById(int id) => DbContext.PrivateMessages.FirstOrDefault(pm => pm.PrivateMessageID == id);
        public ICollection<PrivateMessage> GetAll() => DbContext.PrivateMessages.ToList();
    }
}
