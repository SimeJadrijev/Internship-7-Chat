using Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Seeds
{
    public static class DatabaseSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(new List<User> 
                {
                    new User("Sime Jadrijev", "sime.jadrijev@gmail.com", "password123", true)
                    {
                        UserID = 1
                    },
                    new User("Marko Livaja", "marko.livaja@gmail.com", "password123", false)
                    {
                        UserID = 2
                    },
                    new User("Kevin Punter", "kevin.punter@gmail.com", "password123", false)
                    {
                        UserID = 3
                    },
                    new User("Anthony Edwards", "anthony.edwards@gmail.com", "password123", false)
                    {
                        UserID = 4
                    },
                    new User("Toni Kukoc", "toni.kukoc@gmail.com", "password123", true)
                    {
                        UserID = 5
                    },
                    new User("Marin Cilic", "marin.cilic@gmail.com", "password123", true)
                    {
                        UserID = 6
                    },
                    new User("Mondo Duplantis", "mondo.duplantis@gmail.com", "password123", false)
                    {
                        UserID = 7
                    },
                    new User("Luka Doncic", "luka.doncic@gmail.com", "password123", false)
                    {
                        UserID = 8
                    },
                    new User("Devin Booker", "devin.booker@gmail.com", "password123", false)
                    {
                        UserID = 9
                    },
                    new User("Kevin Durant", "kevin.durant@gmail.com", "password123", false)
                    {
                        UserID = 10
                    },
                    new User("Cristiano Ronaldo", "cristiano.ronaldo@gmail.com", "password123", false)
                    {
                        UserID = 11
                    },
                     new User("Kylian Mbappe", "kylian.mbappe@gmail.com", "password123", false)
                    {
                        UserID = 12
                    }

                });
            builder.Entity<Group>()
                .HasData(new List<Group>
                {
                    new Group("Basketball players")
                    {
                        GroupID = 1,
                        UserCreatorID = 3
                    },
                    new Group("Football players")
                    {
                        GroupID = 2,
                        UserCreatorID = 2
                    },
                    new Group("Others")
                    {
                        GroupID = 3,
                        UserCreatorID = 1
                    }

                });
            builder.Entity<GroupUser>()
                .HasData(new List<GroupUser>
                {
                    new GroupUser()
                    {
                        GroupID = 1,
                        UserID = 3
                    },
                    new GroupUser()
                    {
                        GroupID = 1,
                        UserID = 4
                    },
                    new GroupUser()
                    {
                        GroupID = 1,
                        UserID = 5
                    },
                    new GroupUser()
                    {
                        GroupID = 1,
                        UserID = 8
                    },
                    new GroupUser()
                    {
                        GroupID = 1,
                        UserID = 9
                    },
                    new GroupUser()
                    {
                        GroupID = 1,
                        UserID = 10
                    },

                    new GroupUser()
                    {
                        GroupID = 2,
                        UserID = 3
                    },
                    new GroupUser()
                    {
                        GroupID = 2,
                        UserID = 11
                    },
                    new GroupUser()
                    {
                        GroupID = 2,
                        UserID = 12
                    },

                    new GroupUser()
                    {
                        GroupID = 3,
                        UserID = 1
                    },
                    new GroupUser()
                    {
                        GroupID = 3,
                        UserID = 6
                    },
                    new GroupUser()
                    {
                        GroupID = 3,
                        UserID = 7
                    }

                });
            builder.Entity<GroupMessage>()
                .HasData(new List<GroupMessage>
                {
                    
                    new GroupMessage("Ja sam Punter!", new DateTime(2023, 12, 25, 13, 25, 0), 1, 3),
                    new GroupMessage("Ja sam AntMan!", new DateTime(2023, 12, 26, 12, 25, 0), 1, 4),
                    new GroupMessage("Ja sam Toni!", new DateTime(2023, 12, 27, 12, 25, 0), 1, 5),
                    new GroupMessage("Ja sam Luka!", new DateTime(2023, 12, 28, 14, 25, 0), 1, 8),
                    new GroupMessage("Ja sam Devin!", new DateTime(2023, 12, 27, 15, 25, 0), 1, 9),
                    new GroupMessage("Ja sam KD!", new DateTime(2023, 12, 27, 12, 28, 0), 1, 10),

                    new GroupMessage("Ja sam Marko!", new DateTime(2023, 12, 28, 23, 25, 0), 2, 2),
                    new GroupMessage("Ja sam Cristiano!", new DateTime(2023, 12, 27, 23, 25, 0), 2, 11),
                    new GroupMessage("Ja sam Kylian!", new DateTime(2023, 12, 28, 23, 29, 0), 2, 12),

                    new GroupMessage("Ja sam Sime!", new DateTime(2023, 12, 22, 22, 25, 0), 3, 1),
                    new GroupMessage("Ja sam Marin!", new DateTime(2023, 12, 27, 13, 25, 0), 3, 6),
                    new GroupMessage("Ja sam Mondo!", new DateTime(2023, 12, 25, 13, 26, 0), 3, 7),
                });

            builder.Entity<PrivateMessage>()
                .HasData(new List<PrivateMessage>
                {
                    new PrivateMessage("Pozdrav Marine, Sime je.", new DateTime(2023, 12, 26, 12, 12, 0), 6, 1),
                    new PrivateMessage("Pozdrav Luka, Sime je.", new DateTime(2023, 12, 27, 11, 12, 0), 8, 1),
                    new PrivateMessage("Pozdrav Cristiano, Luka je.", new DateTime(2023, 12, 26, 12, 12, 0), 11, 8),
                    new PrivateMessage("Pozdrav KD, Punter je.", new DateTime(2023, 12, 28, 10, 15, 0), 10, 3)



                });
        }
    }
}
