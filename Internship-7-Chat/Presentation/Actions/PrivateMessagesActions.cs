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

        public static PrivateMessage? SendPrivateMessage(string messageContent, int userSenderID, int userReceiverID)
        {
            var newPrivateMessage = new PrivateMessage(messageContent, DateTime.UtcNow.AddHours(1), userReceiverID, userSenderID);
            var responseResult = _privateMessageRepository.Add(newPrivateMessage);

            if (responseResult == Domain.Enums.ResponseResultType.Success)
                return newPrivateMessage;
            else
            {
                Console.WriteLine("Greška!");
                return null;
            }
        }

        public static List<User> ShowAllPrivateConversations (int userID)
        {
            var usersWithPrivateMessages = _privateMessageRepository.ShowAllPrivateConversations(userID);

            if (usersWithPrivateMessages is null)
            {
                Console.WriteLine("Nema privatnih poruka!");
                return null;
            }

            return usersWithPrivateMessages;
        }

        public static int NumberOfSentMessagesTotal()
        {
            var number = _privateMessageRepository.NumberOfSentMessagesTotal();

            return number;
        }

        public static int NumberOfSentMessagesInLastMonth()
        {
            var number = _privateMessageRepository.NumberOfSentMessagesInLastMonth();

            return number;
        }

        public static int NumberOfSentMessagesToday()
        {
            var number = _privateMessageRepository.NumberOfSentMessagesToday();

            return number;
        }
    }
}
