using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public  class GroupUser
    {
        public int UserID { get; set; }
        public User User { get; set; }
        public int GroupID { get; set; }
        public Group Group { get; set; }
    }
}
