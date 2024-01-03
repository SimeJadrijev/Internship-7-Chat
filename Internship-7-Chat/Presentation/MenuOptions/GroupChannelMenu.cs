using Data.Entities.Models;
using Domain.Enums;
using Domain.Repositories;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;
using Presentation.Actions;
using Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Common;
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

            //GroupUserActions.Add(user.UserID, groupID);
            Reader.PressAnyKeyToContinue();

            BackToGroupChannelMenu(user, true);

        }

        public static void JoinGroupChannel (User user)
        {
            Console.Clear();
            Console.WriteLine("--- ULAZAK U GRUPNI KANAL --- \n");

            var newGroups = GroupsActions.GetNewGroups(user);
            
            if (newGroups != null)
            {
                foreach (var group in newGroups)
                {
                    var numberOfMembers = GroupsActions.GetNumberOfMembersInGroup(group.GroupID);
                    Console.WriteLine($"{group.GroupName} --> {numberOfMembers} članova"); //BROJ CLANOVA NE RADI!!!
                }

                Console.WriteLine();

                Reader.ReadInput("Unesi ime grupnog kanala kojem se želite pridružiti (za izlaz unijeti bilo šta drugo): ", out var groupForJoin);

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

        public static void GetMyGroupChannels(User user)
        {
            Console.Clear();
            Console.WriteLine("--- MOJI GRUPNI KANALI --- \n");

            var myGroups = GroupsActions.GetMyGroups(user);

            if (myGroups is not null)
            {
                foreach (var group in myGroups)
                    Console.WriteLine("   " + group.GroupID + " - " + group.GroupName);

                Console.WriteLine();

                Reader.TryReadInt("Unesite ID grupe koju želite pregledati (za izlaz unijeti bilo šta drugo): ", out var groupForView);
                if (groupForView == 0)
                    BackToGroupChannelMenu(user, true);
                
                var selectedGroup = myGroups.FirstOrDefault(g => g.GroupID == groupForView);

                //Reader.ReadInput("Unesite ime grupnog kanala koji želite pregledati (za izlaz unijeti bilo šta drugo): ", out var groupForView);
                //var selectedGroup = myGroups.FirstOrDefault(g => g.GroupName.Equals(groupForView, StringComparison.OrdinalIgnoreCase));

                if (selectedGroup is null)
                {
                    Console.WriteLine("Grupni kanal s tim ID ne postoji!");
                    Reader.PressAnyKeyToContinue();
                    BackToGroupChannelMenu(user, true);
                }
                else
                {
                    Console.Clear();
                    EnterGroupChat(user, selectedGroup.GroupID);
                }
            }
        }

        public static void EnterGroupChat(User user, int groupID)
        {
            var groupMessages = GroupMessagesActions.ShowMessagesFromThisChannel(groupID);
            if (groupMessages is null)
                Reader.PressAnyKeyToContinue();

            else
                foreach (var message in groupMessages)
                    Console.WriteLine($"{message.UserSender.Username}  -  {message.MessageTime} \n" +
                                      $"{message.Content} \n");

            Reader.ReadInput("Unesite vašu poruku: ", out var messageContent);

            if (messageContent.ToLower() == "/exit")
                BackToGroupChannelMenu(user, true);
            else
            {
                SendNewGroupMessage(messageContent, user, groupID);
                Reader.PressAnyKeyToContinue();
                Console.Clear();
                EnterGroupChat(user, groupID);
            }

            Reader.PressAnyKeyToContinue();

        }

        public static void SendNewGroupMessage(string messageContent, User user, int groupID)
        {
            var newMessage = GroupMessagesActions.SendNewGroupMessage(messageContent, user, groupID);
            if (newMessage is not null)
                Console.WriteLine("Poruka uspješno poslana!");
        }

    }
}
