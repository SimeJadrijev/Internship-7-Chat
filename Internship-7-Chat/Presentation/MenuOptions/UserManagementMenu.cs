using Data.Entities.Models;
using Presentation.Actions;
using Presentation.Authentication;
using Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Presentation.MenuOptions
{
    public class UserManagementMenu
    {
        public User User { get; set; }


        public static void ShowAllUsers(User user)
        {
            var allUsers = UsersActions.GetAllUsers();

            if (allUsers is null)
                Reader.PressAnyKeyToContinue();
            else
            {
                var helpVariable = new LoginForm(true);

                var allUsersItems = new List<(string, Action)>();
                foreach (var u in allUsers)
                {
                    if (u.UserID == user.UserID)
                        continue;

                    (string, Action) line = (u.Username, () => ShowUserManagementMenuOptions(user, u));
                    allUsersItems.Add(line);
                }

                (string, Action) returnLine = ("<-- POVRATAK", () => helpVariable.OpenRegularMenu(user) );
                allUsersItems.Add(returnLine);

                var allUsersMenu = new Menu("Uđite u korisnika kojim želite upravljati.", allUsersItems);
                allUsersMenu.Execute();
            }
        }

        public static void ShowUserManagementMenuOptions(User userMe, User userForOperation)
        {
            var helpVariable = new LoginForm(true);

            var options = new List<(string, Action)>()
                        {
                            ("Izbriši profil", () => DeleteUserProfile(userMe, userForOperation.UserID) ),
                            ("Izmjena email adrese", () => ChangeEmailAdress(userForOperation, userForOperation.UserID)),
                            ("Promoviraj u admina", () => PromoteToAdmin(userForOperation)),
                            ("Povratak na početak", () => helpVariable.OpenRegularMenu(userMe))
                        };

            var userManagementMenu = new Menu("Odaberite jednu od ponuđenih opcija.", options);
            userManagementMenu.Execute();
        }

        public static void DeleteUserProfile(User userMe, int userForDeleteID)
        {
            Console.Clear();
            Console.WriteLine("--- BRISANJE KORISNIČKOG PROFILA --- \n");

            UsersActions.DeleteUser(userForDeleteID);
            Reader.PressAnyKeyToContinue();

            var mm = new MenuOptions(userMe);
            mm.UserManagment();

        }

        public static void ChangeEmailAdress(User userForEdit, int userForEditID)
        {
            Console.Clear();
            Console.WriteLine("--- PROMJENA EMAIL ADRESE --- \n");

            Console.WriteLine("Trenutna email adresa: " + userForEdit.Email + "\n");
            var newEmailAddress = Reader.ReadEmail("Unesite novu email adresu: ");

            var user = UsersActions.ChangeEmailAddress(userForEdit, userForEditID, newEmailAddress);

            Reader.PressAnyKeyToContinue();
        }

        public static void PromoteToAdmin(User userForPromotion)
        {
            Console.Clear();
            Console.WriteLine("--- PROMOCIJA KORISNIKA U ADMINA --- \n");

            var user = UsersActions.PromoteToAdmin(userForPromotion);

            Reader.PressAnyKeyToContinue();
        }
    }

}
