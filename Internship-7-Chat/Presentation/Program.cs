using Presentation.Authentication;
using Presentation.Helpers;
using Presentation.MenuOptions;
using System.Security.Cryptography.Xml;

class Program
{
    static void Main()
    {
        Console.Title = "CHAT APLIKACIJA   - Made by Šime Jadrijev -";
        Console.WriteLine("Dobrodošli u Chat aplikaciju! \n");
        Reader.PressAnyKeyToContinue();

        OpenOpeningMenu();
    }

    public static void OpenOpeningMenu()
    {
        var openingMenuOptions = new List<(string, Action)>()
        {
            ("Registracija novog korisnika", () => OpenRegistrationForm()),
            ("Prijava već postojećeg korisnika", () => OpenLoginForm()),
            ("Izlaz iz aplikacije", () => Environment.Exit(0))
        };
        var menu = new Menu("Početni Menu", openingMenuOptions);
        menu.Execute();
    }

    static void OpenRegistrationForm()
    {
        new RegistrationForm();
    }

    static void OpenLoginForm()
    {
        new LoginForm();
    }
}
