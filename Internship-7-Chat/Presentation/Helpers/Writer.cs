using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
