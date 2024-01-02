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

            var responseResult = _groupRepository.Add(newGroupChannel);
            if (responseResult == ResponseResultType.Success)
                Console.WriteLine("Uspješno ste kreirali grupni kanal: " + groupName);

            return newGroupChannel.GroupID;
        }
    }
}
