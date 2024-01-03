using Data.Entities.Models;
using Presentation.Actions;
using Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.MenuOptions
{
    public class PrivateChatsMenu
    {
        public static void NewPrivateMessage(User user)
        {
            Console.Clear();
            Console.WriteLine("--- NOVA PRIVATNA PORUKA --- \n");

            Console.WriteLine("Svi korisnici: \n");
            ShowAllUsers(user);
            Reader.PressAnyKeyToContinue();

        }

        public static void ShowAllUsers(User user)
        {
            var allUsers = UsersActions.GetAllUsers();

            var allUsersItems = new List<(string, Action)>();
            foreach (var u in allUsers)
            {
                if (u.UserID == user.UserID)
                    continue;

                (string, Action) line = (u.Username, () => ShowPrivateChatWithUser(user, u));
                allUsersItems.Add(line);

                //Console.WriteLine($"ID: {u.UserID}  Korisnik: {u.Username}");
            }

            var allUsersMenu = new Menu("Uđite u korisnika kojem želite poslati poruku.", allUsersItems);
            allUsersMenu.Execute();
        }

        public static void ShowPrivateChatWithUser(User userSender, User userReceiver)
        {
            Console.Clear();
            var privateMessages = PrivateMessagesActions.ShowMessagesFromThisChannel(userSender.UserID, userReceiver.UserID);

            if (privateMessages is null)
                Reader.PressAnyKeyToContinue();
            else
            {
                foreach (var message in privateMessages)
                {
                    Console.WriteLine($"{message.UserSender.Username}  -  {message.MessageTime} \n" +
                                      $"{message.Content} \n");
                }

                SendPrivateMessage(userSender, userReceiver);
                Reader.PressAnyKeyToContinue();
                Console.Clear();
                ShowPrivateChatWithUser(userSender, userReceiver);
            }


        }

        public static void SendPrivateMessage(User userSender, User userReceiver)
        {
            Reader.ReadInput("Unesite vašu poruku: ", out var messageContent);

            if (messageContent.ToLower() == "/exit")
                BackToPrivateChatsMenu(userSender);

            var newPrivateMessage = PrivateMessagesActions.SendPrivateMessage(messageContent, userSender.UserID, userReceiver.UserID);

            if (newPrivateMessage is not null)
                Console.WriteLine("Poruka uspješno poslana!");
        }

        public static void BackToPrivateChatsMenu(User user)
        {
            {
                var menuOptions = new MenuOptions(user);
                var privateChatOptions = menuOptions.PrivateMessageOptions();

                var menu = new Menu("Privatne poruke", privateChatOptions);
                menu.Execute();

            }
        }
    }
}
