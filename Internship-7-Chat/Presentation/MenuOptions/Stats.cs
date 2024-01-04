using Data.Entities.Models;
using Presentation.Actions;
using Presentation.Authentication;
using Presentation.Helpers;

namespace Presentation.MenuOptions
{
    public class Stats
    {
        public static void ReturnToRegularMenu(User user)
        {
            var returnToRegularMenu = new LoginForm(true);
            returnToRegularMenu.OpenRegularMenu(user);
        }

        public static void NumberOfSentMessages(User user)
        {
            Console.Clear();
            Console.WriteLine("--- BROJ POSLANIH PORUKA ---\n");

            var allMessagesTotal = PrivateMessagesActions.NumberOfSentMessagesTotal() + GroupMessagesActions.NumberOfSentMessagesTotal();
            var allMessagesLastMonth = PrivateMessagesActions.NumberOfSentMessagesInLastMonth() + GroupMessagesActions.NumberOfSentMessagesInLastMonth();
            var allMessagesToday = PrivateMessagesActions.NumberOfSentMessagesToday() + GroupMessagesActions.NumberOfSentMessagesToday();

            Console.WriteLine("Ukupni broj poruka: " + allMessagesTotal);
            Console.WriteLine("Ukupni broj poruka u zadnjih mjesec dana: " + allMessagesLastMonth);
            Console.WriteLine("Ukupni broj poruka danas: " + allMessagesToday);

            Console.WriteLine();
            Reader.PressAnyKeyToContinue();

            ReturnToRegularMenu(user);
        }

        public static void AverageNumberOfMessagesPerUser(User user)
        {
            Console.Clear();
            Console.WriteLine("--- PROSJEČNI BROJ POSLANIH PORUKA PO KORISNIKU ---\n");

            var allMessagesTotal = PrivateMessagesActions.NumberOfSentMessagesTotal() + GroupMessagesActions.NumberOfSentMessagesTotal();
            var allMessagesLastMonth = PrivateMessagesActions.NumberOfSentMessagesInLastMonth() + GroupMessagesActions.NumberOfSentMessagesInLastMonth();
            var allMessagesToday = PrivateMessagesActions.NumberOfSentMessagesToday() + GroupMessagesActions.NumberOfSentMessagesToday();

            var numberOfUsers = UsersActions.GetNumberOfUsers();

            var averageNumberOfMessagesPerUserTotal = Math.Round(allMessagesTotal / (double)numberOfUsers, 2);
            var averageNumberOfMessagesPerUserLastMonth = Math.Round(allMessagesLastMonth / (double)numberOfUsers, 2);
            var averageNumberOfMessagesPerUserToday = Math.Round(allMessagesToday / (double)numberOfUsers, 2);


            Console.WriteLine("Prosječni broj poruka po korisniku: " + averageNumberOfMessagesPerUserTotal);
            Console.WriteLine("Prosječni broj poruka po korisniku u zadnjih mjesec dana: " + averageNumberOfMessagesPerUserLastMonth);
            Console.WriteLine("Prosječni broj poruka po korisniku danas: " + averageNumberOfMessagesPerUserToday);

            Console.WriteLine();
            Reader.PressAnyKeyToContinue();

            ReturnToRegularMenu(user);
        }

        public static void TopThreeUsers(User user)
        {
            Console.Clear();
            Console.WriteLine("--- TOP 3 KORISNIKA S NAJVIŠE PORUKA ---\n");

            var usersTotal = UsersActions.TopThreeUsersWithMostSentMessagesTotal();
            var usersLastMonth = UsersActions.TopThreeUsersWithMostSentMessagesLastMonth();
            var usersToday = UsersActions.TopThreeUsersWithMostSentMessagesToday();


            Console.WriteLine("\nUKUPNO: \n");
            if (usersTotal is null)
                Reader.PressAnyKeyToContinue();
            else
            {
                for (var i = 0; i < usersTotal.Count; i++)
                    Console.WriteLine(i + 1 + " - " + usersTotal[i].Username);

            }

            // -------------------------------------

            Console.WriteLine("\nU ZADNJIH MJESEC DANA: \n");
            if (usersLastMonth is null)
                Reader.PressAnyKeyToContinue();
            else
            {
                for (var i = 0; i < usersLastMonth.Count; i++)
                    Console.WriteLine(i + 1 + " - " + usersLastMonth[i].Username);

            }


            // -------------------------------------

            Console.WriteLine("\nDANAS: \n");
            if (usersToday is null)
                Reader.PressAnyKeyToContinue();
            else
            {
                for (var i = 0; i < usersToday.Count; i++)
                    Console.WriteLine(i + 1 + " - " + usersToday[i].Username);

            }

            Reader.PressAnyKeyToContinue();
            ReturnToRegularMenu(user);
        }

        public static void AverageNumberOfGroupMessages(User user)
        {
            Console.Clear();
            Console.WriteLine("--- PROSJEČNI BROJ PORUKA PO DANU U GRUPNIM KANALIMA ---\n");

            Console.WriteLine("");

            Reader.PressAnyKeyToContinue();
            ReturnToRegularMenu(user);


        }
    }
}
