using Data.Entities.Models;
using Domain.Factories;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Actions
{
    public static class UsersActions
    {
        private static UserRepository _userRepository = RepositoryFactory.Create<UserRepository>();

        public static void RegisterUser(string username, string email, string password)
        {
            User newUser = new User(username, email, password, false);
            var responseResult = _userRepository.Add(newUser);

            if (responseResult == Domain.Enums.ResponseResultType.Success)
                Console.WriteLine($"Korisnik {username} je uspješno registriran! \n");
            
        }

        public static void DeleteUser(int id)
        {
            var responseResult = _userRepository.Delete(id);
            if(responseResult == Domain.Enums.ResponseResultType.Success)
                Console.WriteLine($"Korisnik (ID: {id}) je uspješno izbrisan!");
            else
                Console.WriteLine($"Neuspjeh prilikom pokušaja brisanja korisnika (ID: {id}).");           
        }

        public static bool CheckIfEmailAlreadyExists(string email)
        {
            var user = _userRepository.GetbyEmail(email);

            if (user is not null)
                return true; //That email address already exists, abort the registration
            
            return false; //The email address is unique, allow the registration
        }

        public static User? GetUserByEmail(string email)
        {
            var user = _userRepository.GetbyEmail(email);

            if (user is null)
            {
                Console.WriteLine("Korisnik s unesenom email adresom nije registriran!");
                return null;

            }

            return user;
        }
        
        public static ICollection<User> GetAllUsers()
        {
            var allUsers = _userRepository.GetAll();
            
            if (allUsers is null)
            {
                Console.WriteLine("Ne postoji nijedan korisnik u aplikaciji.");
                return null;
            }

            return allUsers;

        }
    }
}
