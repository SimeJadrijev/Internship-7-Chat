using Data.Entities;
using Domain.Repositories;
using Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Actions
{
    public class RegistrationForm : BaseRepository 
    {
        public RegistrationForm (ChatAppDbContext dbContext) : base(dbContext) { }
        private readonly UserRepository _userRepository;
        private readonly ChatAppDbContext _dbContext;

        public void Execute()
        {
            var newUser = new Data.Entities.Models.User();

            Reader.ReadInput("Unesite korisničko ime: ", out var newUsername);
            newUser.Username = newUsername;
            
            while (true) 
            {
                Reader.ReadInput("Unesite unikatni i valjani email: ", out var newEmail);

                if (!CheckIfEmailAlreadyExists(newEmail, DbContext) || IsValidEmail(newEmail))
                {
                    newUser.Email = newEmail;
                    break;
                }    
                
                if (newEmail == "izlaz")
                    break;
            }

            Reader.ReadInput("Unesite lozinku: ", out var newPassword);

            while (true)
            {
                Reader.ReadInput("Potvrdite istu lozinku: ", out var confirmationPassword);
                if (confirmationPassword == newPassword)
                {
                    newUser.Password = newPassword;
                }

                Console.WriteLine("Za odustajanje, unesite 'izlaz'.");

                if (confirmationPassword == "izlaz")
                    break;
            }

            var responseResult = _userRepository.Add(newUser);
            
        }

        static bool IsValidEmail (string email)
        {
            if (!email.Contains("@"))
                return false;

            var parts = email.Split('@');

            if (parts.Length != 2)
                return false;

            if (!parts[1].Contains('.'))
                return false;

            var username = parts[0];
            var remainder = parts[1].Split('.');

            if (remainder.Length != 2)
                return false;

            if (username.Length < 1 || remainder[0].Length < 2 || remainder[1].Length < 3)
                return false;

            return true;
        }

        static bool CheckIfEmailAlreadyExists (string email, ChatAppDbContext context)
        {
            return context.Users.Any(u => u.Email == email);
        }
    }
}
