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
    public class GroupMessageRepository : BaseRepository
    {
        public GroupMessageRepository(ChatAppDbContext dbContext) : base(dbContext)
        {

        }

        public ResponseResultType Add(GroupMessage groupMessage)
        {
            DbContext.GroupMessages.Add(groupMessage);

            return SaveChanges();
        }

        public ResponseResultType Delete(int id)
        {
            var groupMessageForDelete = DbContext.GroupMessages.Find(id);
            if (groupMessageForDelete is null)
                return ResponseResultType.NotFound;

            DbContext.GroupMessages.Remove(groupMessageForDelete);

            return SaveChanges();
        }

        public ResponseResultType Update (GroupMessage groupMessage, int id)
        {
            var groupMessageForUpdate = DbContext.GroupMessages.Find(id);
            if (groupMessageForUpdate is null)
                return ResponseResultType.NotFound;

            groupMessageForUpdate.MessageTime = groupMessage.MessageTime;
            groupMessageForUpdate.GroupMessageID = groupMessage.GroupMessageID;
            groupMessageForUpdate.UserSender = groupMessage.UserSender;
            groupMessageForUpdate.UserSenderID = groupMessage.UserSenderID;
            groupMessageForUpdate.GroupID = groupMessage.GroupID;
            groupMessageForUpdate.Group = groupMessage.Group;
            groupMessageForUpdate.Content = groupMessage.Content;

            return SaveChanges();
        }

        public List<GroupMessage>? GetGroupMessagesFromThisChannel (int groupID)
        {
            var selectedGroup = GetById(groupID);
            if (selectedGroup is null) 
                return null;

            var groupMessages = DbContext.GroupMessages
                                .Where(gm => gm.GroupID == groupID)
                                .Include(gm => gm.UserSender)
                                .OrderByDescending(gm => gm.MessageTime)
                                .ToList();

            if (groupMessages is null)
                return null;

            return groupMessages;
        }
        public GroupMessage? GetById(int id) => DbContext.GroupMessages.FirstOrDefault(gm => gm.GroupMessageID == id);
        public ICollection<GroupMessage> GetAll() => DbContext.GroupMessages.ToList();
    }
}
