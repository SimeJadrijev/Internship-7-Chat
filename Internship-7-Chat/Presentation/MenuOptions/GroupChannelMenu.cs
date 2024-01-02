using Data.Entities.Models;
using Domain.Enums;
using Domain.Repositories;
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

            BackToGroupChannelMenu(user, true);

        }

        public static void JoinGroupChannel (User user)
        {
            Console.Clear();

            var newGroups = GroupsActions.GetNewGroups(user);
            
            if (newGroups != null)
            {
                foreach (var group in newGroups)
                    Console.WriteLine($"{group.GroupName} --> {group.GroupUsers.Count} članova"); //BROJ CLANOVA NE RADI!!!

                Console.WriteLine();

                Reader.ReadInput("Unesi ime grupnog kanala kojem se želite pridružiti: ", out var groupForJoin);

                var selectedGroup = newGroups.FirstOrDefault(g => g.GroupName.Equals(groupForJoin, StringComparison.OrdinalIgnoreCase));

                if (selectedGroup is null)  //User's selected group doesn't exist
                {
                    Console.WriteLine("Grupni kanal s tim imenom ne postoji!");
                    Reader.PressAnyKeyToContinue();
                    BackToGroupChannelMenu(user, true);

                }
                else   
                {
                    GroupUserActions.Add(user.UserID, selectedGroup.GroupID);
                    Reader.PressAnyKeyToContinue();
                    BackToGroupChannelMenu(user, true);
                }
            }
        }

        public static void BackToGroupChannelMenu(User user, bool returnToRegularMenu)
        {
            var menuOptions = new MenuOptions(user);
            var groupChatOptions = menuOptions.GroupChatOptions();

            var menu = new Menu("Grupni kanali", groupChatOptions);
            menu.Execute();
        }



    }
}
