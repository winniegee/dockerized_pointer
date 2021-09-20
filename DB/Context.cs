using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Model;

namespace DB
{
    public class DataContext : DbContext, IDbContext
    {
        //public Context() : base()
        //{

        //}
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Campaign> Campaign { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("config.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("Context");
                optionsBuilder.UseSqlServer(connectionString);
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Role>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Campaign>().Property(p => p.CampaignID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Message>().Property(p => p.MessageId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Tasks>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(p => p.UserId).ValueGeneratedOnAdd();
        }

    }
}
