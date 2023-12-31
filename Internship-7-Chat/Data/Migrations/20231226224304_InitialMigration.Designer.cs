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
    [Migration("20231226224304_InitialMigration")]
    partial class InitialMigration
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
                });

            modelBuilder.Entity("Data.Entities.Models.User", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("ReceivedPrivateMessages");

                    b.Navigation("SentGroupMessages");

                    b.Navigation("SentPrivateMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
