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

                (string, Action) line = (u.Username, () => Console.WriteLine());
                allUsersItems.Add(line);

                //Console.WriteLine($"ID: {u.UserID}  Korisnik: {u.Username}");
            }

            var allUsersMenu = new Menu("Uđite u korisnika kojem želite poslati poruku.", allUsersItems);
            allUsersMenu.Execute();            
        }
    }
}
