using Data.Entities;
using Data.Entities.Models;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class GroupUserRepository : BaseRepository
    {
        public GroupUserRepository(ChatAppDbContext dbContext) : base(dbContext)
        {

        }

        public ResponseResultType Add (int userID, int groupID)
        {
            var group = DbContext.Groups.Find(groupID);
            if (group is null)
                return ResponseResultType.NotFound;

            var existingGroupUser = DbContext.GroupUsers
                                    .FirstOrDefault(gu => gu.UserID == userID && gu.GroupID == groupID);

            if (existingGroupUser != null)
                return ResponseResultType.AlreadyExists; 


            var groupUser = new GroupUser 
            {
                UserID = userID,
                GroupID = groupID
            };

            DbContext.GroupUsers.Add(groupUser);

            return SaveChanges();
        }

    }
}
