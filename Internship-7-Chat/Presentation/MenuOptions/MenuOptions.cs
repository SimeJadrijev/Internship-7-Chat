using Data.Entities.Models;
using Presentation.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Presentation.MenuOptions
{
    public class MenuOptions
    {
        public User User { get; set; }

        public MenuOptions(User _user)
        {
            User = _user;
        }

        public List<(string, Action)> GroupChatOptions()
        {
            var returnToRegularMenu = new LoginForm(true); //auxiliary variable

            var options = new List<(string, Action)>()
            {
                ("Kreiranje novog grupnog kanala", () => GroupChannelMenu.CreateGroupChannel(User) ),
                ("Ulazak u grupni kanal", () => GroupChannelMenu.JoinGroupChannel(User) ),
                ("Ispis svih grupnih", () => Console.WriteLine("Work in progress...")),
                ("Povratak na prethodni Menu", () => returnToRegularMenu.OpenRegularMenu(User))
            };

            return options;
        }

        public List<(string, Action)> PrivateMessageOptions()
        {
            var options = new List<(string, Action)>()
            {
                ("Nova poruka", () => Console.WriteLine("Work in progress...")),
                ("Ispis svih privatnih poruka", () => Console.WriteLine("Work in progress...")),
                ("Povratak na prethodni Menu", () => Console.WriteLine("Work in progress..."))

            };

            return options;
        }

        public List<(string, Action)> UserManagment()
        {
            var options = new List<(string, Action)>() { ("UserManagament", () => Console.WriteLine("Work in progress...")) };
            return options;
        }

        public List<(string, Action)> UserSettings()
        {
            var options = new List<(string, Action)>()
            {
                ("Promjena email adrese", () => Console.WriteLine("Work in progress...")),
                ("Promjena lozinke", () => Console.WriteLine("Work in progress...")),
                ("Povratak na prethodni Menu", () => Console.WriteLine("Work in progress..."))

            };

            return options;
        }
    }
}
