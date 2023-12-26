using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class Group
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }   
        public int UserCreatorID { get; set; }
        public User User { get; set; } = null!;
        public ICollection<GroupMessage> GroupMessages { get; set; }
    }
}
