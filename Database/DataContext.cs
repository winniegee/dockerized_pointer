using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
//using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;

namespace Database
{
    public class DataContext: DbContext
    {
       
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Campaign> Users { get; set; }
        public DbSet<Message> Bookings { get; set; }
        public DbSet<Tasks> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("Config.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("EventContext");
                optionsBuilder.UseSqlServer(connectionString);
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Role>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Location>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Purpose>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Hall>().Property(p => p.Id).ValueGeneratedOnAdd();
        }

    }
}
