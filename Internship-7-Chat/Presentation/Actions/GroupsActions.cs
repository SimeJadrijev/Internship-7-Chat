using Data.Entities.Models;
using Domain.Enums;
using Domain.Factories;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Actions
{
    public class GroupsActions
    {
        private static readonly GroupRepository _groupRepository = RepositoryFactory.Create<GroupRepository>();

        public static int CreateGroupChat(string groupName, int userCreatorID)
        {
            var newGroupChannel = new Group(groupName)
            {
                UserCreatorID = userCreatorID
            };

            newGroupChannel.GroupUsers.Add(new GroupUser { UserID = userCreatorID });

            var responseResult = _groupRepository.Add(newGroupChannel);
            if (responseResult == ResponseResultType.Success)
                Console.WriteLine("Uspješno ste kreirali grupni kanal: " + groupName);

            return newGroupChannel.GroupID;
        }

        public static List<Group>? GetNewGroups(User user)
        {
            var newGroups = _groupRepository.GetNewGroups(user);

            if(newGroups is null)
            {
                Console.WriteLine("Nema novih grupnih kanala!");
                return null;
            }

            return newGroups;
        }
    }
}
