using Data.Entities;
using Data.Entities.Models;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
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
        public List<PrivateMessage> GetGroupMessagesFromThisChannel(int userSender, int userReceiver)
        {
            var privateMessages = DbContext.PrivateMessages
                                .Where(pm => (pm.UserReceiverID == userReceiver && pm.UserSenderID == userSender)
                                              || (pm.UserReceiverID == userSender && pm.UserSenderID == userReceiver))
                                .OrderBy(pm => pm.MessageTime)
                                .Include(pm => pm.UserSender)
                                .Include(pm => pm.UserReceiver)
                                .ToList();

            if (privateMessages is null)
                return null;

            return privateMessages;

        }

        public List<User> ShowAllPrivateConversations (int userID)
        {
            var usersWithPrivateMessages = DbContext.PrivateMessages
                                    .Where(pm => (pm.UserSenderID == userID || pm.UserReceiverID == userID) && pm.UserSenderID != pm.UserReceiverID)
                                    .OrderBy(pm => pm.MessageTime)
                                    .Include(pm => pm.UserSender)
                                    .Include(pm => pm.UserReceiver)
                                    .AsEnumerable()
                                    .SelectMany(pm => new[] { pm.UserSender, pm.UserReceiver })
                                    .Distinct()
                                    .ToList();

            if (usersWithPrivateMessages is null)
                return null;

            return usersWithPrivateMessages;

        }

        public int NumberOfSentMessagesTotal ()
        {
            var number = DbContext.PrivateMessages.Count();
            return number;
        }

        public int NumberOfSentMessagesInLastMonth()
        {
            var lastMonth = DateTime.UtcNow.AddMonths(-1);

            var number = DbContext.PrivateMessages
                        .Where(pm => pm.MessageTime >= lastMonth)
                        .Count();

            return number;
        }

        public int NumberOfSentMessagesToday()
        {
            var today = DateTime.UtcNow.Date;

            var number = DbContext.PrivateMessages
                    .Where(pm => pm.MessageTime.ToUniversalTime().Date == today)
                    .Count();

            return number;
        }
        public PrivateMessage? GetById(int id) => DbContext.PrivateMessages.FirstOrDefault(pm => pm.PrivateMessageID == id);
        public ICollection<PrivateMessage> GetAll() => DbContext.PrivateMessages.ToList();
    }
}
