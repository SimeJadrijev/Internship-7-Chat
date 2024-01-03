using Data.Entities.Models;
using Domain.Factories;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Actions
{
    public class GroupMessagesActions
    {
        private static readonly GroupMessageRepository _groupMessageRepository = RepositoryFactory.Create<GroupMessageRepository>();

        public static List<GroupMessage> ShowMessagesFromThisChannel(int groupID)
        {
            var groupMessages = _groupMessageRepository.GetGroupMessagesFromThisChannel(groupID);

            if (groupMessages is null)
            {
                Console.WriteLine("Ovaj kanal je prazan.");
                return null;
            }

            return groupMessages;
        }

        public static GroupMessage? SendNewGroupMessage(string messageContent, User user, int groupID)
        {
            var newMessage = new GroupMessage(messageContent, DateTime.UtcNow.AddHours(1), groupID, user.UserID);
            var responseResult = _groupMessageRepository.Add(newMessage);
                
            if (responseResult == Domain.Enums.ResponseResultType.Success)
                return newMessage;
            else
            {
                Console.WriteLine("Greška!");
                return null;
            }
        }
    }
}

