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

        public User? GetById(int id) => DbContext.Users.FirstOrDefault(u => u.UserID == id);
        public User? GetbyEmail(string email) => DbContext.Users.FirstOrDefault(u => u.Email == email);
        public ICollection<User> GetAll() => DbContext.Users.ToList();
    }
}
