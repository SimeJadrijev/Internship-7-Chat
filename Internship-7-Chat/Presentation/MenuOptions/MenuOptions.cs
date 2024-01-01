using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.MenuOptions
{
    public class MenuOptions
    {
        public User User { get; set; }

        public MenuOptions(User _user)
        {
            User = _user;
        }



    }
}
