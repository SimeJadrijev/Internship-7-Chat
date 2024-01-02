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
    public class GroupChannelMenu
    {
        public static void CreateGroupChannel (User user)
        {
            Console.Clear();
            Console.WriteLine("--- KREIRANJE NOVOG GRUPNOG KANALA --- \n");

            Reader.ReadInput("Odaberite ime vašeg novog grupnog kanala: ", out var groupChannelName);
            var groupID = GroupsActions.CreateGroupChat(groupChannelName, user.UserID);

            GroupUserActions.Add(user.UserID, groupID);
            Reader.PressAnyKeyToContinue();

            var menuOptions = new MenuOptions(user);
            var groupChatOptions = menuOptions.GroupChatOptions();

            var menu = new Menu("Grupni kanali", groupChatOptions);
            menu.Execute();

        }


    }
}
