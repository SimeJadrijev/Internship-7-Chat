using Data.Entities;
using Data.Entities.Models;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class UserRepository : BaseRepository
    {
        public UserRepository (ChatAppDbContext dbContext) : base (dbContext) { }

        public ResponseResultType Add (User user)
        {
            DbContext.Users.Add(user);

            return SaveChanges();
        }
        public ResponseResultType Delete (int id)
        {
            var userForDelete = DbContext.Users.Find(id);
            if (userForDelete is null)
                return ResponseResultType.NotFound;

            DbContext.Users.Remove(userForDelete);

            return SaveChanges();
        }

        public ResponseResultType Update(User user, int id)
        {
            var userForUpdate = DbContext.Users.Find(id);
            if (userForUpdate is null)
                return ResponseResultType.NotFound;

            userForUpdate.UserID = user.UserID;
            userForUpdate.Username = user.Username;
            userForUpdate.Password = user.Password;
            userForUpdate.IsAdmin = user.IsAdmin;
            userForUpdate.Email = user.Email;

            return SaveChanges();

        }
        public int GetNumberOfUsers()
        {
            var number = DbContext.Users.Count();

            return number;
        }

        public List<User>? TopThreeUsersWithMostSentMessagesTotal()
        {
            var topUsers = DbContext.Users
                            .OrderByDescending(u =>
                                u.SentPrivateMessages.Count + u.SentGroupMessages.Count(gm => gm.UserSenderID == u.UserID))
                            .Take(3)
                            .ToList();

            if (topUsers is null)
                return null;

            return topUsers;
        }


        public List<User>? TopThreeUsersWithMostSentMessagesLastMonth()
        {
            var lastMonth = DateTime.UtcNow.AddMonths(-1);

            var topUsers = DbContext.Users
                            .OrderByDescending(u =>
                                u.SentPrivateMessages.Count(pm => pm.MessageTime >= lastMonth) +
                                u.SentGroupMessages.Count(gm => gm.UserSenderID == u.UserID && gm.MessageTime >= lastMonth))
                            .Take(3)
                            .ToList();

            if (topUsers is null)
                return null;

            return topUsers;
        }

        public List<User>? TopThreeUsersWithMostSentMessagesToday()
        {
            var todayUtc = DateTime.Now.ToUniversalTime().Date;

            var topUsers = DbContext.Users
                .OrderByDescending(u =>
                    u.SentPrivateMessages.Count(pm => pm.MessageTime.ToUniversalTime().Date == todayUtc) +
                    u.SentGroupMessages.Count(gm => gm.UserSenderID == u.UserID && gm.MessageTime.ToUniversalTime().Date == todayUtc))
                .Take(3)
                .ToList();


            if (topUsers is null)
                return null;

            return topUsers;
        }


        public User? GetById(int id) => DbContext.Users.FirstOrDefault(u => u.UserID == id);
        public User? GetbyEmail(string email) => DbContext.Users.FirstOrDefault(u => u.Email == email);
        public ICollection<User> GetAll() => DbContext.Users.ToList();
    }
}
