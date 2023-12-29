﻿// <auto-generated />
using System;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ChatAppDbContext))]
    [Migration("20231229135003_AddSeed")]
    partial class AddSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Data.Entities.Models.Group", b =>
                {
                    b.Property<int>("GroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GroupID"));

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserCreatorID")
                        .HasColumnType("integer");

                    b.HasKey("GroupID");

                    b.HasIndex("UserCreatorID");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            GroupID = 1,
                            GroupName = "Basketball players",
                            UserCreatorID = 3
                        },
                        new
                        {
                            GroupID = 2,
                            GroupName = "Football players",
                            UserCreatorID = 2
                        },
                        new
                        {
                            GroupID = 3,
                            GroupName = "Others",
                            UserCreatorID = 1
                        });
                });

            modelBuilder.Entity("Data.Entities.Models.GroupMessage", b =>
                {
                    b.Property<int>("GroupMessageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GroupMessageID"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("GroupID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("MessageTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserSenderID")
                        .HasColumnType("integer");

                    b.HasKey("GroupMessageID");

                    b.HasIndex("GroupID");

                    b.HasIndex("UserSenderID");

                    b.ToTable("GroupMessages");

                    b.HasData(
                        new
                        {
                            GroupMessageID = 1,
                            Content = "Ja sam Punter!",
                            GroupID = 1,
                            MessageTime = new DateTime(2023, 12, 25, 13, 25, 0, 0, DateTimeKind.Utc),
                            UserSenderID = 3
                        },
                        new
                        {
                            GroupMessageID = 2,
                            Content = "Ja sam AntMan!",
                            GroupID = 1,
                            MessageTime = new DateTime(2023, 12, 26, 12, 25, 0, 0, DateTimeKind.Utc),
                            UserSenderID = 4
                        },
                        new
                        {
                            GroupMessageID = 3,
                            Content = "Ja sam Toni!",
                            GroupID = 1,
                            MessageTime = new DateTime(2023, 12, 27, 12, 25, 0, 0, DateTimeKind.Utc),
                            UserSenderID = 5
                        },
                        new
                        {
                            GroupMessageID = 4,
                            Content = "Ja sam Luka!",
                            GroupID = 1,
                            MessageTime = new DateTime(2023, 12, 28, 14, 25, 0, 0, DateTimeKind.Utc),
                            UserSenderID = 8
                        },
                        new
                        {
                            GroupMessageID = 5,
                            Content = "Ja sam Devin!",
                            GroupID = 1,
                            MessageTime = new DateTime(2023, 12, 27, 15, 25, 0, 0, DateTimeKind.Utc),
                            UserSenderID = 9
                        },
                        new
                        {
                            GroupMessageID = 6,
                            Content = "Ja sam KD!",
                            GroupID = 1,
                            MessageTime = new DateTime(2023, 12, 27, 12, 28, 0, 0, DateTimeKind.Utc),
                            UserSenderID = 10
                        },
                        new
                        {
                            GroupMessageID = 7,
                            Content = "Ja sam Marko!",
                            GroupID = 2,
                            MessageTime = new DateTime(2023, 12, 28, 23, 25, 0, 0, DateTimeKind.Utc),
                            UserSenderID = 2
                        },
                        new
                        {
                            GroupMessageID = 8,
                            Content = "Ja sam Cristiano!",
                            GroupID = 2,
                            MessageTime = new DateTime(2023, 12, 27, 23, 25, 0, 0, DateTimeKind.Utc),
                            UserSenderID = 11
                        },
                        new
                        {
                            GroupMessageID = 9,
                            Content = "Ja sam Kylian!",
                            GroupID = 2,
                            MessageTime = new DateTime(2023, 12, 28, 23, 29, 0, 0, DateTimeKind.Utc),
                            UserSenderID = 12
                        },
                        new
                        {
                            GroupMessageID = 10,
                            Content = "Ja sam Sime!",
                            GroupID = 3,
                            MessageTime = new DateTime(2023, 12, 22, 22, 25, 0, 0, DateTimeKind.Utc),
                            UserSenderID = 1
                        },
                        new
                        {
                            GroupMessageID = 11,
                            Content = "Ja sam Marin!",
                            GroupID = 3,
                            MessageTime = new DateTime(2023, 12, 27, 13, 25, 0, 0, DateTimeKind.Utc),
                            UserSenderID = 6
                        },
                        new
                        {
                            GroupMessageID = 12,
                            Content = "Ja sam Mondo!",
                            GroupID = 3,
                            MessageTime = new DateTime(2023, 12, 25, 13, 26, 0, 0, DateTimeKind.Utc),
                            UserSenderID = 7
                        });
                });

            modelBuilder.Entity("Data.Entities.Models.GroupUser", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("integer");

                    b.Property<int>("GroupID")
                        .HasColumnType("integer");

                    b.HasKey("UserID", "GroupID");

                    b.HasIndex("GroupID");

                    b.ToTable("GroupUsers");

                    b.HasData(
                        new
                        {
                            UserID = 3,
                            GroupID = 1
                        },
                        new
                        {
                            UserID = 4,
                            GroupID = 1
                        },
                        new
                        {
                            UserID = 5,
                            GroupID = 1
                        },
                        new
                        {
                            UserID = 8,
                            GroupID = 1
                        },
                        new
                        {
                            UserID = 9,
                            GroupID = 1
                        },
                        new
                        {
                            UserID = 10,
                            GroupID = 1
                        },
                        new
                        {
                            UserID = 3,
                            GroupID = 2
                        },
                        new
                        {
                            UserID = 11,
                            GroupID = 2
                        },
                        new
                        {
                            UserID = 12,
                            GroupID = 2
                        },
                        new
                        {
                            UserID = 1,
                            GroupID = 3
                        },
                        new
                        {
                            UserID = 6,
                            GroupID = 3
                        },
                        new
                        {
                            UserID = 7,
                            GroupID = 3
                        });
                });

            modelBuilder.Entity("Data.Entities.Models.PrivateMessage", b =>
                {
                    b.Property<int>("PrivateMessageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PrivateMessageID"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("MessageTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserReceiverID")
                        .HasColumnType("integer");

                    b.Property<int>("UserSenderID")
                        .HasColumnType("integer");

                    b.HasKey("PrivateMessageID");

                    b.HasIndex("UserReceiverID");

                    b.HasIndex("UserSenderID");

                    b.ToTable("PrivateMessages");

                    b.HasData(
                        new
                        {
                            PrivateMessageID = 1,
                            Content = "Pozdrav Marine, Sime je.",
                            MessageTime = new DateTime(2023, 12, 26, 12, 12, 0, 0, DateTimeKind.Utc),
                            UserReceiverID = 6,
                            UserSenderID = 1
                        },
                        new
                        {
                            PrivateMessageID = 2,
                            Content = "Pozdrav Sime! Kako si?",
                            MessageTime = new DateTime(2023, 12, 26, 12, 14, 0, 0, DateTimeKind.Utc),
                            UserReceiverID = 1,
                            UserSenderID = 6
                        },
                        new
                        {
                            PrivateMessageID = 3,
                            Content = "Odlicno, upravo gledam tvoj prosli mec.",
                            MessageTime = new DateTime(2023, 12, 26, 12, 15, 0, 0, DateTimeKind.Utc),
                            UserReceiverID = 6,
                            UserSenderID = 1
                        },
                        new
                        {
                            PrivateMessageID = 4,
                            Content = "Super, ja upravo koristim tvoju aplikaciju. Pozdrav, Marin.",
                            MessageTime = new DateTime(2023, 12, 26, 12, 16, 0, 0, DateTimeKind.Utc),
                            UserReceiverID = 1,
                            UserSenderID = 6
                        },
                        new
                        {
                            PrivateMessageID = 5,
                            Content = "Pozdrav Luka, Sime je.",
                            MessageTime = new DateTime(2023, 12, 27, 11, 12, 0, 0, DateTimeKind.Utc),
                            UserReceiverID = 8,
                            UserSenderID = 1
                        },
                        new
                        {
                            PrivateMessageID = 6,
                            Content = "Bok Sime, ne mogu sad razgovarat, spremam se za utakmicu.",
                            MessageTime = new DateTime(2023, 12, 27, 11, 12, 0, 0, DateTimeKind.Utc),
                            UserReceiverID = 1,
                            UserSenderID = 8
                        },
                        new
                        {
                            PrivateMessageID = 7,
                            Content = "U redu, cujemo se drugom prilikom.",
                            MessageTime = new DateTime(2023, 12, 27, 11, 15, 0, 0, DateTimeKind.Utc),
                            UserReceiverID = 8,
                            UserSenderID = 1
                        },
                        new
                        {
                            PrivateMessageID = 8,
                            Content = "Pozdrav Cristiano, Luka je.",
                            MessageTime = new DateTime(2023, 12, 26, 12, 12, 0, 0, DateTimeKind.Utc),
                            UserReceiverID = 11,
                            UserSenderID = 8
                        },
                        new
                        {
                            PrivateMessageID = 9,
                            Content = "Bok Luka, cestitam na prinovi.",
                            MessageTime = new DateTime(2023, 12, 26, 12, 13, 0, 0, DateTimeKind.Utc),
                            UserReceiverID = 8,
                            UserSenderID = 11
                        },
                        new
                        {
                            PrivateMessageID = 10,
                            Content = "Hvala ti! Kako je u novom klubu?",
                            MessageTime = new DateTime(2023, 12, 26, 12, 14, 0, 0, DateTimeKind.Utc),
                            UserReceiverID = 11,
                            UserSenderID = 8
                        },
                        new
                        {
                            PrivateMessageID = 11,
                            Content = "Sve je odlicno, hvala na pitanju!",
                            MessageTime = new DateTime(2023, 12, 26, 12, 15, 0, 0, DateTimeKind.Utc),
                            UserReceiverID = 8,
                            UserSenderID = 11
                        },
                        new
                        {
                            PrivateMessageID = 12,
                            Content = "Kad dolazis u Europu?",
                            MessageTime = new DateTime(2023, 12, 26, 12, 16, 0, 0, DateTimeKind.Utc),
                            UserReceiverID = 8,
                            UserSenderID = 11
                        },
                        new
                        {
                            PrivateMessageID = 13,
                            Content = "Na ljeto dolazim u Portugal pa se mozemo vidjeti. ",
                            MessageTime = new DateTime(2023, 12, 26, 12, 17, 0, 0, DateTimeKind.Utc),
                            UserReceiverID = 11,
                            UserSenderID = 8
                        },
                        new
                        {
                            PrivateMessageID = 14,
                            Content = "Dogovoreno, vidimo se!",
                            MessageTime = new DateTime(2023, 12, 26, 12, 20, 0, 0, DateTimeKind.Utc),
                            UserReceiverID = 8,
                            UserSenderID = 11
                        },
                        new
                        {
                            PrivateMessageID = 15,
                            Content = "Pozdrav KD, Punter je.",
                            MessageTime = new DateTime(2023, 12, 28, 10, 15, 0, 0, DateTimeKind.Utc),
                            UserReceiverID = 10,
                            UserSenderID = 3
                        },
                        new
                        {
                            PrivateMessageID = 16,
                            Content = "Bok, kako ti mogu pomoci?",
                            MessageTime = new DateTime(2023, 12, 28, 10, 15, 30, 0, DateTimeKind.Utc),
                            UserReceiverID = 3,
                            UserSenderID = 10
                        },
                        new
                        {
                            PrivateMessageID = 17,
                            Content = "Dolazim u Phoenix za 2 dana, mozes li sredit kartu za utakmicu?",
                            MessageTime = new DateTime(2023, 12, 28, 10, 16, 0, 0, DateTimeKind.Utc),
                            UserReceiverID = 10,
                            UserSenderID = 3
                        },
                        new
                        {
                            PrivateMessageID = 18,
                            Content = "Naravno, poslat cu ti court side ulaznice preko menadzera. Vidimo se!",
                            MessageTime = new DateTime(2023, 12, 28, 10, 18, 30, 0, DateTimeKind.Utc),
                            UserReceiverID = 3,
                            UserSenderID = 10
                        },
                        new
                        {
                            PrivateMessageID = 19,
                            Content = "Pozdrav Livaja, mozes li mi sredit neki transfer u Hajduk?",
                            MessageTime = new DateTime(2023, 12, 29, 12, 11, 0, 0, DateTimeKind.Utc),
                            UserReceiverID = 2,
                            UserSenderID = 12
                        },
                        new
                        {
                            PrivateMessageID = 20,
                            Content = "Nema problema Mbappe, ali broj 10 je zauzet.",
                            MessageTime = new DateTime(2023, 12, 29, 12, 12, 0, 0, DateTimeKind.Utc),
                            UserReceiverID = 12,
                            UserSenderID = 2
                        },
                        new
                        {
                            PrivateMessageID = 21,
                            Content = "Znam tko je glavni u Splitu tako da nema problema. Igrat cu na krilu.",
                            MessageTime = new DateTime(2023, 12, 29, 12, 14, 0, 0, DateTimeKind.Utc),
                            UserReceiverID = 2,
                            UserSenderID = 12
                        },
                        new
                        {
                            PrivateMessageID = 22,
                            Content = "Onda u redu, spojit cu te s Luksom.",
                            MessageTime = new DateTime(2023, 12, 29, 12, 18, 0, 0, DateTimeKind.Utc),
                            UserReceiverID = 12,
                            UserSenderID = 2
                        });
                });

            modelBuilder.Entity("Data.Entities.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Email = "sime.jadrijev@gmail.com",
                            IsAdmin = true,
                            Password = "password123",
                            Username = "Sime Jadrijev"
                        },
                        new
                        {
                            UserID = 2,
                            Email = "marko.livaja@gmail.com",
                            IsAdmin = false,
                            Password = "password123",
                            Username = "Marko Livaja"
                        },
                        new
                        {
                            UserID = 3,
                            Email = "kevin.punter@gmail.com",
                            IsAdmin = false,
                            Password = "password123",
                            Username = "Kevin Punter"
                        },
                        new
                        {
                            UserID = 4,
                            Email = "anthony.edwards@gmail.com",
                            IsAdmin = false,
                            Password = "password123",
                            Username = "Anthony Edwards"
                        },
                        new
                        {
                            UserID = 5,
                            Email = "toni.kukoc@gmail.com",
                            IsAdmin = true,
                            Password = "password123",
                            Username = "Toni Kukoc"
                        },
                        new
                        {
                            UserID = 6,
                            Email = "marin.cilic@gmail.com",
                            IsAdmin = true,
                            Password = "password123",
                            Username = "Marin Cilic"
                        },
                        new
                        {
                            UserID = 7,
                            Email = "mondo.duplantis@gmail.com",
                            IsAdmin = false,
                            Password = "password123",
                            Username = "Mondo Duplantis"
                        },
                        new
                        {
                            UserID = 8,
                            Email = "luka.doncic@gmail.com",
                            IsAdmin = false,
                            Password = "password123",
                            Username = "Luka Doncic"
                        },
                        new
                        {
                            UserID = 9,
                            Email = "devin.booker@gmail.com",
                            IsAdmin = false,
                            Password = "password123",
                            Username = "Devin Booker"
                        },
                        new
                        {
                            UserID = 10,
                            Email = "kevin.durant@gmail.com",
                            IsAdmin = false,
                            Password = "password123",
                            Username = "Kevin Durant"
                        },
                        new
                        {
                            UserID = 11,
                            Email = "cristiano.ronaldo@gmail.com",
                            IsAdmin = false,
                            Password = "password123",
                            Username = "Cristiano Ronaldo"
                        },
                        new
                        {
                            UserID = 12,
                            Email = "kylian.mbappe@gmail.com",
                            IsAdmin = false,
                            Password = "password123",
                            Username = "Kylian Mbappe"
                        });
                });

            modelBuilder.Entity("Data.Entities.Models.Group", b =>
                {
                    b.HasOne("Data.Entities.Models.User", "User")
                        .WithMany("Groups")
                        .HasForeignKey("UserCreatorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.Models.GroupMessage", b =>
                {
                    b.HasOne("Data.Entities.Models.Group", "Group")
                        .WithMany("GroupMessages")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Models.User", "UserSender")
                        .WithMany("SentGroupMessages")
                        .HasForeignKey("UserSenderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("UserSender");
                });

            modelBuilder.Entity("Data.Entities.Models.GroupUser", b =>
                {
                    b.HasOne("Data.Entities.Models.Group", "Group")
                        .WithMany("GroupUsers")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Models.User", "User")
                        .WithMany("GroupUsers")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.Models.PrivateMessage", b =>
                {
                    b.HasOne("Data.Entities.Models.User", "UserReceiver")
                        .WithMany("ReceivedPrivateMessages")
                        .HasForeignKey("UserReceiverID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Models.User", "UserSender")
                        .WithMany("SentPrivateMessages")
                        .HasForeignKey("UserSenderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserReceiver");

                    b.Navigation("UserSender");
                });

            modelBuilder.Entity("Data.Entities.Models.Group", b =>
                {
                    b.Navigation("GroupMessages");

                    b.Navigation("GroupUsers");
                });

            modelBuilder.Entity("Data.Entities.Models.User", b =>
                {
                    b.Navigation("GroupUsers");

                    b.Navigation("Groups");

                    b.Navigation("ReceivedPrivateMessages");

                    b.Navigation("SentGroupMessages");

                    b.Navigation("SentPrivateMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
