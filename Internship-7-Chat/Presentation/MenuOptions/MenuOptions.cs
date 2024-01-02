using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var options = new List<(string, Action)>()
            {
                ("Kreiranje novog grupnog chata", () => Console.WriteLine("Work in progress...")),
                ("Ulazak u grupni chat", () => Console.WriteLine("Work in progress...")),
                ("Ispis svih grupnih", () => Console.WriteLine("Work in progress...")),
                ("Povratak na prethodni Menu", () => Console.WriteLine("Work in progress..."))

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
