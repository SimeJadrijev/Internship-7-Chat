namespace Presentation.Helpers
{
    public class Writer
    {
        void PrintMenu(List<string> menuOptions)
        {
            foreach (var item in menuOptions)
            {
                Console.WriteLine(item);
            }
        }

    }
}
