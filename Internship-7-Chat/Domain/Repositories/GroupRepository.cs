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
    public class GroupRepository : BaseRepository
    {
        public GroupRepository(ChatAppDbContext dbContext) : base(dbContext)
        {

        }

        public ResponseResultType Add(Group group)
        {
            DbContext.Groups.Add(group);

            return SaveChanges();
        }

        public ResponseResultType Update(Group group, int id)
        {
            var groupForUpdate = DbContext.Groups.Find(id);
            if (groupForUpdate is null)
            {
                return ResponseResultType.NotFound;
            }

            groupForUpdate.User = group.User;
            groupForUpdate.GroupName = group.GroupName;
            groupForUpdate.GroupMessages = group.GroupMessages;
            groupForUpdate.UserCreatorID = group.UserCreatorID;
            groupForUpdate.GroupID = group.GroupID;

            return SaveChanges();
        }

        public Group? GetById(int id) => DbContext.Groups.FirstOrDefault(c => c.GroupID == id);
        public ICollection<Group> GetAll() => DbContext.Groups.ToList();


    }
}
