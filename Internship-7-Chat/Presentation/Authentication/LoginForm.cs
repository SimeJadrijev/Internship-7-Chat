using Data.Entities.Models;
using Presentation.Actions;
using Presentation.Helpers;
using Presentation.MenuOptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Authentication
{
    public class LoginForm
    {
        private string Email { get; set; }
        private string Password { get; set; }
        private bool SuccessfullyLoggedIn { get; set; } = false;
        public LoginForm()
        {
            while (!SuccessfullyLoggedIn)
            {
                Console.Clear();
                Console.WriteLine("--- Prijava korisnika ---");

                Email = Reader.ReadEmail("Unesite svoju email adresu: ");

                var user = UsersActions.GetUserByEmail(Email);
                if (user is null)
                {
                    Reader.PressAnyKeyToContinue();
                    continue;
                }

                Reader.ReadInput("Unesite svoju lozinku: ", out var _password);
                Password = _password;

                if (ValidatePassword(user, Password))
                {
                    Reader.PressAnyKeyToContinue();
                    OpenRegularMenu(user);
                    SuccessfullyLoggedIn = true;
                }
                else
                    Reader.PressAnyKeyToContinue();
            };          
        }

        public LoginForm(bool successfullyLoggedIn)
        {
            
        }

        public bool ValidatePassword (User user, string password)
        {
            if (password != user.Password)
            {
                Console.WriteLine("\nPogrešna lozinka! \n");
                return false;
            }

            Console.WriteLine("\nUspješno ste se prijavili! \n");
            return true;

        }

        public void OpenRegularMenu(User user)
        {
            var mo = new MenuOptions.MenuOptions(user);
            var groupChatOptions = mo.GroupChatOptions();
            var privateMessageOptions = mo.PrivateMessageOptions();
            var userSettings = mo.UserSettings();
            var userManagment = mo.UserManagment();

            var regularOptions = new List<(string, Action)>()
            {
                ("Grupni kanali", () =>  new Menu("Grupni kanali", groupChatOptions).Execute()),
                ("Privatne poruke", () =>  new Menu("Private poruke", privateMessageOptions).Execute()),
                ("Postavke profila", () =>  new Menu("Postavke profila", groupChatOptions).Execute()),
                ("Odjava iz profila", () =>  Program.OpenOpeningMenu())

            };

            var adminOptions = new List<(string, Action)>()
            {
                ("Grupni kanali", () =>  new Menu("Grupni kanali", groupChatOptions).Execute()),
                ("Privatne poruke", () =>  new Menu("Private poruke", privateMessageOptions).Execute()),
                ("Upravljanje korisničkim profilima", () =>  new Menu("Upravljanje korisničkim profilima", userManagment).Execute()),
                ("Postavke profila", () =>  new Menu("Postavke profila", userSettings).Execute()),
                ("Odjava iz profila", () =>  Program.OpenOpeningMenu())

            };

            var adminMenu = new Menu($"Admin Menu", adminOptions);
            var regularMenu = new Menu($"Regular Menu", regularOptions);

            if (user.IsAdmin)
                adminMenu.Execute();
            else
                regularMenu.Execute();


        }
    }
}
