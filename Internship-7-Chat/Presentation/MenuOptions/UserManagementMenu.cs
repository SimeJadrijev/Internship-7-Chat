using Data.Entities.Models;
using Presentation.Actions;
using Presentation.Authentication;
using Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Presentation.MenuOptions
{
    public class UserManagementMenu
    {
        public User User { get; set; }

        public UserManagementMenu(User _user)
        {
            User = _user;
        }

        public static void ShowAllUsers()
        {
            var allUsers = UsersActions.GetAllUsers();

            if (allUsers is null)
                Reader.PressAnyKeyToContinue();
            else
            {
                var allUsersItems = new List<(string, Action)>();
                foreach (var user in allUsers)
                {
                    (string, Action) line = (user.Username, () => ShowUserManagementMenuOptions(user));
                    allUsersItems.Add(line);
                }

                var allUsersMenu = new Menu("Uđite u korisnika kojim želite upravljati.", allUsersItems);
                allUsersMenu.Execute();
            }
        }

        public static void ShowUserManagementMenuOptions(User user)
        {
            var mm = new MenuOptions(user);

            var options = new List<(string, Action)>()
                        {
                            ("Izbriši profil", () => Console.WriteLine()),
                            ("Izmjena email adrese", () => Console.WriteLine()),
                            ("Promoviraj u admina", () => Console.WriteLine()),
                            ("Povratak na prethodni Menu", () => mm.UserManagment())
                        };

            var userManagementMenu = new Menu("Odaberite jednu od ponuđenih opcija.", options);
            userManagementMenu.Execute();
        }
    }

}
