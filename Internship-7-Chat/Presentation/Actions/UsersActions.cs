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

        public static User? ChangeEmailAddress(User userForEdit, int userID, string newEmailAddress)
        {
            if (userForEdit.Email == newEmailAddress)
            {
                Console.WriteLine("Unijeli ste istu email adresu. Nema promjena!");
                return null;
            }
            else
            {
                userForEdit.Email = newEmailAddress;
                var responseResult = _userRepository.Update(userForEdit, userID);

                if (responseResult == Domain.Enums.ResponseResultType.Success)
                {
                    Console.WriteLine("Uspješno izmijenjena email adresa!");
                    return userForEdit;
                }
                else
                {
                    Console.WriteLine("Greška! Korisniku nije promijenjena email adresa!");
                    return null;
                }
            }
        }

        public static User? PromoteToAdmin(User userForPromotion)
        {
            if (userForPromotion.IsAdmin == true)
            {
                Console.WriteLine("Korisnik je već admin!");
                return null;
            }
            else
            {
                userForPromotion.IsAdmin = true;
                var responseResult = _userRepository.Update(userForPromotion, userForPromotion.UserID);

                if (responseResult == Domain.Enums.ResponseResultType.Success)
                {
                    Console.WriteLine("Korisnik je uspješno promoviran u admina!");
                    return userForPromotion;
                }
                else
                {
                    Console.WriteLine("Greška! Korisnik NIJE promoviran u admina!");
                    return null;
                }
            }
        }

        public static User? ChangePassword(User userForEdit, string newPassword)
        {
            userForEdit.Password = newPassword;

            var user = _userRepository.Update(userForEdit, userForEdit.UserID);

            if (user == Domain.Enums.ResponseResultType.Success)
            {
                Console.WriteLine("Uspješno promijenjena lozinka!");
                return userForEdit;
            }
            else
            {
                Console.WriteLine("Greška! Nema promjena!");
                return null;
            }
        }

        public static int GetNumberOfUsers()
        {
            var number = _userRepository.GetNumberOfUsers();

            return number;
        }

        public static List<User> TopThreeUsersWithMostSentMessagesTotal()
        {
            var number = _userRepository.TopThreeUsersWithMostSentMessagesTotal();

            if (number is null)
            {
                Console.WriteLine("U bazi podataka nema nijednog korisnika!");
                return null;
            }

            return number;
        }
        public static List<User> TopThreeUsersWithMostSentMessagesLastMonth()
        {
            var number = _userRepository.TopThreeUsersWithMostSentMessagesLastMonth();

            if (number is null)
            {
                Console.WriteLine("U bazi podataka nema nijednog korisnika!");
                return null;
            }

            return number;
        }
        public static List<User> TopThreeUsersWithMostSentMessagesToday()
        {
            var number = _userRepository.TopThreeUsersWithMostSentMessagesToday();

            if (number is null)
            {
                Console.WriteLine("U bazi podataka nema nijednog korisnika!");
                return null;
            }

            return number;
        }
    }
}
