using Data.Entities.Models;
using Presentation.Authentication;

namespace Presentation.MenuOptions
{
    public class MenuOptions
    {
        public User User { get; set; }

        public MenuOptions(User _user)
        {
            User = _user;
        }
        public MenuOptions()
        { }

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
            var statsMenu = new Menu("Statistika", Stats());
            var options = new List<(string, Action)>() 
            { 
                ("Upravljanje korisnicima", () => UserManagementMenu.ShowAllUsers(User) ),
                ("Statistika", () => statsMenu.Execute() )
            };
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

        public List<(string, Action)> Stats()
        {
            var returnToRegularMenu = new LoginForm(true); //auxiliary variable

            var options = new List<(string, Action)>()
            {
                ("Broj poslanih poruka", () => Presentation.MenuOptions.Stats.NumberOfSentMessages(User) ),
                ("Prosječni broj poruka po korisniku", () => Presentation.MenuOptions.Stats.AverageNumberOfMessagesPerUser(User) ),
                ("Prosječni broj poruka po kanalu", () =>  Console.WriteLine() ),
                ("Top 3 korisnika s najviše poruka", () =>  Presentation.MenuOptions.Stats.TopThreeUsers(User) ),
                ("Povratak na početak", () => returnToRegularMenu.OpenRegularMenu(User) )

            };

            return options;
        }
    }
}
