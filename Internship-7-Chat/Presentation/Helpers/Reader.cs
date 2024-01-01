using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Helpers
{
    public class Reader
    {
        public static void ReadInput (string message, out string input)
        {
            Console.Write(message);
            input = Console.ReadLine() ?? string.Empty;
        }

        public static bool IsValidEmail (string email)
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

        public static string ReadEmail (string message)
        {
            while (true)
            {
                ReadInput(message, out var input);

                if (IsValidEmail(input))
                    return input;
            }
        }
        public static void PressAnyKeyToContinue()
        {
            Console.WriteLine("Pritisnite bilo koju tipku za nastavak...");
            Console.ReadKey();
        }

    }
}
