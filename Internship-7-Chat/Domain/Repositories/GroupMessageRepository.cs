﻿using Data.Entities;
using Data.Entities.Models;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

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
                                .OrderBy(gm => gm.MessageTime)
                                .ToList();

            if (groupMessages is null)
                return null;

            return groupMessages;
        }

        public int NumberOfSentMessagesTotal()
        {
            var number = DbContext.GroupMessages.Count();
            return number;
        }

        public int NumberOfSentMessagesInLastMonth()
        {
            var lastMonth = DateTime.UtcNow.AddMonths(-1);

            var number = DbContext.GroupMessages
                        .Where(gm => gm.MessageTime >= lastMonth)
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

        public GroupMessage? GetById(int id) => DbContext.GroupMessages.FirstOrDefault(gm => gm.GroupMessageID == id);
        public ICollection<GroupMessage> GetAll() => DbContext.GroupMessages.ToList();
    }
}
