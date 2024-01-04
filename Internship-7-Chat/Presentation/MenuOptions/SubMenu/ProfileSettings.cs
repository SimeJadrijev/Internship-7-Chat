using Data.Entities.Models;
using Presentation.Actions;
using Presentation.Helpers;

namespace Presentation.MenuOptions.SubMenu
{
    public class ProfileSettings
    {
        User User { get; set; }

        public static void ChangeMyEmailAddress(User userForEdit, int userForEditID)
        {
            {
                Console.Clear();
                Console.WriteLine("--- PROMJENA EMAIL ADRESE --- \n");

                Console.WriteLine("Trenutna email adresa: " + userForEdit.Email + "\n");
                var newEmailAddress = Reader.ReadEmail("Unesite novu email adresu: ");

                if (ConfirmCaptcha())
                {
                    var user = UsersActions.ChangeEmailAddress(userForEdit, userForEditID, newEmailAddress);
                    Reader.PressAnyKeyToContinue();
                }
                else
                    Reader.PressAnyKeyToContinue();

            }
        }

        public static void ChangeMyPassword(User userForEdit, int userForEditID)
        {
            Console.Clear();
            Console.WriteLine("--- PROMJENA LOZINKE --- \n");

            Reader.ReadInput("Unesite novu lozinku: ", out var newPassword);
            Reader.ReadInput("Unesite novu lozinku: ", out var confirmationPassword);

            var passwordsMatch = PasswordsMatch(newPassword, confirmationPassword);


            if (passwordsMatch)
            {
                if (ConfirmCaptcha())
                {
                    var user = UsersActions.ChangePassword(userForEdit, newPassword);
                    Reader.PressAnyKeyToContinue();
                }

            }
            else
                Reader.PressAnyKeyToContinue();
        }

        public static bool PasswordsMatch(string password, string confirmationPassword)
        {
            if (password == confirmationPassword)
                return true;

            Console.WriteLine("\nLozinke se ne podudaraju! \n");
            return false;
        }

        public static string GenerateRandomCaptcha()
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

        public static bool ConfirmCaptcha()
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
