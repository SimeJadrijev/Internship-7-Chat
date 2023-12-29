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

                    new GroupMessage("Ja sam Punter!", DateTime.SpecifyKind(new DateTime(2023, 12, 25, 13, 25, 0), DateTimeKind.Utc), 1, 3)
                    {
                        GroupMessageID = 1
                    },
                    new GroupMessage("Ja sam AntMan!", DateTime.SpecifyKind(new DateTime(2023, 12, 26, 12, 25, 0), DateTimeKind.Utc), 1, 4)
                    {
                        GroupMessageID = 2
                    },
                    new GroupMessage("Ja sam Toni!", DateTime.SpecifyKind(new DateTime(2023, 12, 27, 12, 25, 0),DateTimeKind.Utc), 1, 5)
                    {
                        GroupMessageID = 3
                    },
                    new GroupMessage("Ja sam Luka!", DateTime.SpecifyKind(new DateTime(2023, 12, 28, 14, 25, 0), DateTimeKind.Utc), 1, 8)
                    {
                        GroupMessageID = 4
                    },
                    new GroupMessage("Ja sam Devin!", DateTime.SpecifyKind(new DateTime(2023, 12, 27, 15, 25, 0), DateTimeKind.Utc), 1, 9)
                    {
                        GroupMessageID = 5
                    },
                    new GroupMessage("Ja sam KD!", DateTime.SpecifyKind(new DateTime(2023, 12, 27, 12, 28, 0),DateTimeKind.Utc), 1, 10)
                    {
                        GroupMessageID = 6
                    },


                    new GroupMessage("Ja sam Marko!", DateTime.SpecifyKind(new DateTime(2023, 12, 28, 23, 25, 0), DateTimeKind.Utc), 2, 2)
                    {
                        GroupMessageID = 7
                    },
                    new GroupMessage("Ja sam Cristiano!", DateTime.SpecifyKind(new DateTime(2023, 12, 27, 23, 25, 0), DateTimeKind.Utc), 2, 11)
                    {
                        GroupMessageID = 8
                    },
                    new GroupMessage("Ja sam Kylian!", DateTime.SpecifyKind(new DateTime(2023, 12, 28, 23, 29, 0), DateTimeKind.Utc), 2, 12)
                    {
                        GroupMessageID = 9
                    },


                    new GroupMessage("Ja sam Sime!", DateTime.SpecifyKind(new DateTime(2023, 12, 22, 22, 25, 0), DateTimeKind.Utc), 3, 1)
                    {
                        GroupMessageID = 10
                    },
                    new GroupMessage("Ja sam Marin!", DateTime.SpecifyKind(new DateTime(2023, 12, 27, 13, 25, 0), DateTimeKind.Utc), 3, 6)
                    {
                        GroupMessageID = 11
                    },
                    new GroupMessage("Ja sam Mondo!", DateTime.SpecifyKind(new DateTime(2023, 12, 25, 13, 26, 0), DateTimeKind.Utc), 3, 7)
                    {
                        GroupMessageID = 12
                    },
                });

            builder.Entity<PrivateMessage>()
                .HasData(new List<PrivateMessage>
                {
                    new PrivateMessage("Pozdrav Marine, Sime je.", DateTime.SpecifyKind(new DateTime(2023, 12, 26, 12, 12, 0),DateTimeKind.Utc), 6, 1) {PrivateMessageID = 1},
                    new PrivateMessage("Pozdrav Sime! Kako si?", DateTime.SpecifyKind(new DateTime(2023, 12, 26, 12, 14, 0), DateTimeKind.Utc), 1, 6) {PrivateMessageID = 2},
                    new PrivateMessage("Odlicno, upravo gledam tvoj prosli mec.", DateTime.SpecifyKind(new DateTime(2023, 12, 26, 12, 15, 0), DateTimeKind.Utc), 6, 1) {PrivateMessageID = 3},
                    new PrivateMessage("Super, ja upravo koristim tvoju aplikaciju. Pozdrav, Marin.",  DateTime.SpecifyKind(new DateTime(2023, 12, 26, 12, 16, 0),DateTimeKind.Utc), 1, 6) {PrivateMessageID = 4},

                    new PrivateMessage("Pozdrav Luka, Sime je.", DateTime.SpecifyKind(new DateTime(2023, 12, 27, 11, 12, 0), DateTimeKind.Utc), 8, 1) {PrivateMessageID = 5 },
                    new PrivateMessage("Bok Sime, ne mogu sad razgovarat, spremam se za utakmicu.", DateTime.SpecifyKind(new DateTime(2023, 12, 27, 11, 12, 0), DateTimeKind.Utc), 1, 8) {PrivateMessageID = 6},
                    new PrivateMessage("U redu, cujemo se drugom prilikom.", DateTime.SpecifyKind(new DateTime(2023, 12, 27, 11, 15, 0), DateTimeKind.Utc), 8, 1) {PrivateMessageID = 7},


                    new PrivateMessage("Pozdrav Cristiano, Luka je.",  DateTime.SpecifyKind(new DateTime(2023, 12, 26, 12, 12, 0),DateTimeKind.Utc), 11, 8) {PrivateMessageID = 8},
                    new PrivateMessage("Bok Luka, cestitam na prinovi.", DateTime.SpecifyKind(new DateTime(2023, 12, 26, 12, 13, 0), DateTimeKind.Utc), 8, 11) {PrivateMessageID = 9},
                    new PrivateMessage("Hvala ti! Kako je u novom klubu?", DateTime.SpecifyKind(new DateTime(2023, 12, 26, 12, 14, 0), DateTimeKind.Utc), 11, 8) { PrivateMessageID = 10 },
                    new PrivateMessage("Sve je odlicno, hvala na pitanju!", DateTime.SpecifyKind(new DateTime(2023, 12, 26, 12, 15, 0), DateTimeKind.Utc), 8, 11) { PrivateMessageID = 11 },
                    new PrivateMessage("Kad dolazis u Europu?", DateTime.SpecifyKind(new DateTime(2023, 12, 26, 12, 16, 0), DateTimeKind.Utc), 8, 11) { PrivateMessageID = 12 },
                    new PrivateMessage("Na ljeto dolazim u Portugal pa se mozemo vidjeti. ", DateTime.SpecifyKind(new DateTime(2023, 12, 26, 12, 17, 0), DateTimeKind.Utc), 11, 8) { PrivateMessageID = 13 },
                    new PrivateMessage("Dogovoreno, vidimo se!", DateTime.SpecifyKind(new DateTime(2023, 12, 26, 12, 20, 0), DateTimeKind.Utc), 8, 11) { PrivateMessageID = 14 },

                    new PrivateMessage("Pozdrav KD, Punter je.", DateTime.SpecifyKind(new DateTime(2023, 12, 28, 10, 15, 0), DateTimeKind.Utc), 10, 3) {PrivateMessageID = 15},
                    new PrivateMessage("Bok, kako ti mogu pomoci?", DateTime.SpecifyKind(new DateTime(2023, 12, 28, 10, 15, 30), DateTimeKind.Utc), 3, 10) {PrivateMessageID = 16},
                    new PrivateMessage("Dolazim u Phoenix za 2 dana, mozes li sredit kartu za utakmicu?", DateTime.SpecifyKind(new DateTime(2023, 12, 28, 10, 16, 0), DateTimeKind.Utc), 10, 3) {PrivateMessageID = 17},
                    new PrivateMessage("Naravno, poslat cu ti court side ulaznice preko menadzera. Vidimo se!", DateTime.SpecifyKind(new DateTime(2023, 12, 28, 10, 18, 30), DateTimeKind.Utc), 3, 10) {PrivateMessageID = 18},

                    new PrivateMessage("Pozdrav Livaja, mozes li mi sredit neki transfer u Hajduk?", DateTime.SpecifyKind(new DateTime(2023, 12, 29, 12, 11, 0), DateTimeKind.Utc), 2, 12) {PrivateMessageID = 19},
                    new PrivateMessage("Nema problema Mbappe, ali broj 10 je zauzet.", DateTime.SpecifyKind(new DateTime(2023, 12, 29, 12, 12, 0), DateTimeKind.Utc), 12, 2) {PrivateMessageID = 20},
                    new PrivateMessage("Znam tko je glavni u Splitu tako da nema problema. Igrat cu na krilu.", DateTime.SpecifyKind(new DateTime(2023, 12, 29, 12, 14, 0), DateTimeKind.Utc), 2, 12) {PrivateMessageID = 21},
                    new PrivateMessage("Onda u redu, spojit cu te s Luksom.", DateTime.SpecifyKind(new DateTime(2023, 12, 29, 12, 18, 0), DateTimeKind.Utc), 12, 2) {PrivateMessageID = 22},


                });
        }
    }
}
