using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.MenuOptions
{
    public class Menu
    {
        private List<(string, Action)> Options;
        private int SelectedOption = 0;
        private string MenuName;
        private bool ExitMenu = false;
        private bool DeleteOption = false;
        
        public Menu(string menuName, List<(string, Action)> options)
        {
            MenuName = menuName;
            Options = options;
        }

        public Menu(string menuName, List<(string, Action)> options, bool deleteOption)
        {
            MenuName = menuName;
            Options = options;
            DeleteOption = deleteOption;
        }

        public void Execute()
        {
            PrintMenu();
            while (!ExitMenu)
            {
                SelectedOption = SetCurrentOption();
                PrintMenu();
            }
        }

        public void PrintMenu ()
        {
            Console.Clear();
            Console.WriteLine(MenuName + "\n");

            for (var i = 0; i < Options.Count; ++i)
            {
                if (SelectedOption == i)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($" {i + 1}. {Options[i].Item1}");

                    Console.ResetColor();
                }
                else
                    Console.WriteLine($"{i + 1}. {Options[i].Item1}");
            }
        }

        public int SetCurrentOption()
        {
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow)
            {
                if (SelectedOption == 0)
                    SelectedOption = Options.Count - 1;
                else
                    SelectedOption--;
            }

            else if (key.Key == ConsoleKey.DownArrow)
            {
                if (SelectedOption == Options.Count - 1)
                    SelectedOption = 0;
                else
                    SelectedOption++;
            }

            else if (key.Key == ConsoleKey.Enter)
            {
                Options[SelectedOption].Item2.Invoke();
                if (DeleteOption)
                    Options.RemoveAt(SelectedOption);
                if (SelectedOption == 0)
                    ExitMenu = true;
            }
            return SelectedOption;
        }

    }
}
