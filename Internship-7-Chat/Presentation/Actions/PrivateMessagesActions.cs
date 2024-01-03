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
    public class PrivateMessagesActions
    {
        private static readonly PrivateMessageRepository _privateMessageRepository = RepositoryFactory.Create<PrivateMessageRepository>();

        public static List<PrivateMessage> ShowMessagesFromThisChannel(int userSenderID, int userReceiverID)
        {
            var privateMessages = _privateMessageRepository.GetGroupMessagesFromThisChannel(userSenderID, userReceiverID);

            if (privateMessages is null)
            {
                Console.WriteLine("Ovaj kanal je prazan.");
                return null;
            }

            return privateMessages;
        }
    }
}
