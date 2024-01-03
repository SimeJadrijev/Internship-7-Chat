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
    }
}
