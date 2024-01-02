using Presentation.Actions;
using Presentation.Helpers;
using Presentation.MenuOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Authentication
{
    public class RegistrationForm
    {
        private string NewEmail { get; set; }
        private string NewUsername { get; set; } 
        private string NewPassword { get; set; }

        public RegistrationForm() 
        {
            Console.Clear();
            Console.WriteLine("--- Registracija korisnika ---");

            // Username:
            Reader.ReadInput("Unesite korisničko ime: ", out var username);
            NewUsername = username;

            //Email address:
            do
            {
                NewEmail = Reader.ReadEmail("Unesite unikatnu i valjanu email adresu: ");
            } while (UsersActions.CheckIfEmailAlreadyExists(NewEmail));

            //Password: 
            while (true)
            {
                Reader.ReadInput("Unesite lozinku: ", out var password);
                Reader.ReadInput("Potvrdite lozinku: ", out var confirmPassword);

                if (PasswordsMatch(password, confirmPassword))
                {
                    NewPassword = password;
                    break;
                }
            }

            //CAPTCHA validation:
            if ( ConfirmCaptcha() )
                UsersActions.RegisterUser(NewUsername, NewEmail, NewPassword);
            Reader.PressAnyKeyToContinue();
            Program.OpenOpeningMenu();
        }

        public static bool PasswordsMatch (string password, string confirmationPassword)
        {
            if (password == confirmationPassword)
                return true;

            Console.WriteLine("\nLozinke se ne podudaraju! \n");
            return false;
        }

        public static string GenerateRandomCaptcha ()
        {
            var chars = "QWERTZUIOPASDFGHJKLYXCVBNMqwertzuiopasdfghjklyxcvbnm";
            var mix = "QWERTZUIOPASDFGHJKLYXCVBNMqwertzuiopasdfghjklyxcvbnm0123456789";

            var rnd = new Random();

            var randomChar = chars[rnd.Next(chars.Length)];
            var randomNumber = rnd.Next(1, 10);

            var randomCaptcha = (randomChar + randomNumber).ToString();

            while (randomCaptcha.Length != 8)
                randomCaptcha += mix[rnd.Next(mix.Length)];

            return randomCaptcha;
        }

        public static bool ConfirmCaptcha ()
        {
            Console.WriteLine("\nCAPTCHA potvrda da niste robot \n");

            var randomCaptcha = GenerateRandomCaptcha();
            Console.WriteLine("CAPTCHA KOD: " + randomCaptcha + "\n");
            
            while (true)
            {
                Reader.ReadInput("Molimo unesite generirani Captcha kod: ", out var userInput);

                if (userInput == randomCaptcha)
                    break;

                Console.WriteLine("Neuspješan pokušaj! Molimo da unesete identičan kod. \n");
            }
            return true;
        }
    }
}
