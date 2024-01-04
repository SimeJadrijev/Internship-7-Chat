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
                ("Ispis svih grupnih kanala", () => GroupChannelMenu.GetMyGroupChannels(User)),
                ("Povratak na prethodni Menu", () => returnToRegularMenu.OpenRegularMenu(User))
            };

            return options;
        }

        public List<(string, Action)> PrivateMessageOptions()
        {
            var returnToRegularMenu = new LoginForm(true); //auxiliary variable

            var options = new List<(string, Action)>()
            {
                ("Nova poruka", () => PrivateChatsMenu.NewPrivateMessage(User) ),
                ("Ispis svih privatnih poruka", () => PrivateChatsMenu.ShowAllPrivateConversations(User) ),
                ("Povratak na prethodni Menu", () => returnToRegularMenu.OpenRegularMenu(User))

            };

            return options;
        }

        public List<(string, Action)> UserManagment()
        {
            var options = new List<(string, Action)>() { ("Upravljanje korisnicima", () => UserManagementMenu.ShowAllUsers(User) ) };
            return options;
        }

        public List<(string, Action)> UserSettings()
        {
            var returnToRegularMenu = new LoginForm(true); //auxiliary variable

            var options = new List<(string, Action)>()
            {
                ("Promjena email adrese", () => ProfileSettings.ChangeMyEmailAddress(User, User.UserID) ),
                ("Promjena lozinke", () => ProfileSettings.ChangeMyPassword(User, User.UserID) ),
                ("Povratak na prethodni Menu", () => returnToRegularMenu.OpenRegularMenu(User) )

            };

            return options;
        }
    }
}
