using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Factories
{
    public static class DbContextFactory
    {
        public static ChatAppDbContext GetChatAppDbContext()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(FindProjectRoot(AppContext.BaseDirectory))
                .AddXmlFile("App.config")
                .Build();

            config.Providers
                .First()
                .TryGet("ConnectionStrings:add:ChatApp:connectionString", out var connectionString);

            var options = new DbContextOptionsBuilder<ChatAppDbContext>()
                .UseNpgsql(connectionString)
                .Options;

            return new ChatAppDbContext(options);

        }

        public static string FindProjectRoot(string basePath)
        {
            while (!File.Exists(Path.Combine(basePath, "App.config")))
            {
                string parentDirectory = Directory.GetParent(basePath)!.FullName;

                if (parentDirectory == null)
                {
                    throw new InvalidOperationException("Unable to find project root directory.");
                }

                basePath = parentDirectory;
            }

            return basePath;
        }
    }
}
