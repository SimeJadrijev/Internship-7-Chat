using Presentation.Authentication;
using Presentation.Helpers;
using Presentation.MenuOptions;
using System.Security.Cryptography.Xml;

Console.Title = "CHAT APLIKACIJA   - Made by Šime Jadrijev -";
Console.WriteLine("Dobrodošli u Chat aplikaciju! \n");
Reader.PressAnyKeyToContinue();

var options = new List<(string, Action)>()
{
    ("Registracija novog korisnika", () => new RegistrationForm() ),
    ("Prijava već postojećeg korisnika", () => new RegistrationForm()),
    ("Izlaz iz aplikacije", () => Environment.Exit(0))
};
var menu = new Menu("OpeningMenu", options);
menu.Execute();