using Data.Entities.Models;
using Presentation.Actions;
using Presentation.Authentication;
using Presentation.Helpers;

namespace Presentation.MenuOptions.SubMenu
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
            var returnToRegularMenu = new LoginForm(true);

            var allUsers = UsersActions.GetAllUsers();
            var allUsersItems = new List<(string, Action)>();

            if (allUsers.Count > 0)
            {
                foreach (var u in allUsers)
                {
                    if (u.UserID == user.UserID)
                        continue;

                    (string, Action) line = (u.Username, () => ShowPrivateChatWithUser(user, u));
                    allUsersItems.Add(line);

                    //Console.WriteLine($"ID: {u.UserID}  Korisnik: {u.Username}");
                }
            }
            (string, Action) lastLine = ("<-- POVRATAK", () => returnToRegularMenu.OpenRegularMenu(user));
            allUsersItems.Add(lastLine);

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
            Reader.ReadInput("Unesite vašu poruku (/exit za izlaz): ", out var messageContent);

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

        public static void ShowAllPrivateConversations(User user)
        {
            var usersWithPrivateMessages = PrivateMessagesActions.ShowAllPrivateConversations(user.UserID);

            if (usersWithPrivateMessages is null || usersWithPrivateMessages.Count < 1)
            {
                Console.Clear();
                Console.WriteLine("\nNemate privatnih poruka! \n");
                Reader.PressAnyKeyToContinue();
            }
            else
            {
                var allUsersItems = new List<(string, Action)>();

                foreach (var u in usersWithPrivateMessages)
                {
                    if (u.UserID == user.UserID)
                        continue;
                    (string, Action) line = (u.Username, () => ShowPrivateChatWithUser(user, u));
                    allUsersItems.Add(line);
                }




                var allUsersMenu = new Menu("Uđite u korisnika kojem želite poslati poruku.", allUsersItems);
                allUsersMenu.Execute();

            }
        }


    }
}
