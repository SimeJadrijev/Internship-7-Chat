using Data.Entities.Models;
using Data.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ChatAppDbContext : DbContext
    {

        public ChatAppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Group> Groups => Set<Group>();
        public DbSet<GroupMessage> GroupMessages => Set<GroupMessage>();
        public DbSet<PrivateMessage> PrivateMessages => Set<PrivateMessage>();
        public DbSet<GroupUser> GroupUsers => Set<GroupUser>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
                .HasOne(g => g.User)
                .WithMany(u => u.Groups)
                .HasForeignKey(g => g.UserCreatorID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GroupMessage>()
                .HasOne(gm => gm.Group)
                .WithMany(g => g.GroupMessages)
                .HasForeignKey(gm => gm.GroupID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GroupMessage>()
            .HasOne(gm => gm.UserSender)
            .WithMany(u => u.SentGroupMessages)
            .HasForeignKey(gm => gm.UserSenderID)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PrivateMessage>()
                .HasOne(pm => pm.UserSender)
                .WithMany(u => u.SentPrivateMessages)
                .HasForeignKey(pm => pm.UserSenderID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PrivateMessage>()
            .HasOne(pm => pm.UserReceiver)
            .WithMany(u => u.ReceivedPrivateMessages)
            .HasForeignKey(pm => pm.UserReceiverID)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GroupUser>()
           .HasKey(gu => new { gu.UserID, gu.GroupID }); 

            modelBuilder.Entity<GroupUser>()
                .HasOne(gu => gu.User)
                .WithMany(u => u.GroupUsers)
                .HasForeignKey(gu => gu.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GroupUser>()
                .HasOne(gu => gu.Group)
                .WithMany(g => g.GroupUsers)
                .HasForeignKey(gu => gu.GroupID)
                .OnDelete(DeleteBehavior.Cascade);
            DatabaseSeeder.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }


    public class ChatAppDbContextFactory : IDesignTimeDbContextFactory<ChatAppDbContext>
    {
        public ChatAppDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddXmlFile("App.config")
                .Build();

            config.Providers
                .First()
                .TryGet("ConnectionStrings:add:ChatApp:connectionString", out var connectionString);

            Console.WriteLine(connectionString);
            var options = new DbContextOptionsBuilder<ChatAppDbContext>()
                .UseNpgsql(connectionString)
                .Options;

            return new ChatAppDbContext(options);
        }
    }
}
