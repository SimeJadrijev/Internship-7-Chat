using Domain.Enums;
using Domain.Factories;
using Domain.Repositories;

namespace Presentation.Actions
{
    public class GroupUserActions
    {
        private static readonly GroupUserRepository _groupUserRepository = RepositoryFactory.Create<GroupUserRepository>();

        public static void Add(int userID, int groupID)
        {
            var responseResult = _groupUserRepository.Add(userID, groupID);
            if (responseResult == ResponseResultType.Success)
                Console.WriteLine($"Korisnik (ID: {userID}) je uspješno dodan u grupni kanal!");
            else
                Console.WriteLine($"Korisnik (ID: {userID}) nije dodan u grupni kanal!");
        }
    }
}
