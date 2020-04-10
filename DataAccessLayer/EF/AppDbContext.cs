using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EF
{
    public class AppDbContext : IdentityDbContext<User>
    {
        //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
        //{
        //    public AppDbContext CreateDbContext(string[] args)
        //    {
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //            .SetBasePath(Directory.GetCurrentDirectory())
        //            .AddJsonFile("appsettings.json")
        //            .Build();
        //        var builder = new DbContextOptionsBuilder<AppDbContext>();
        //        var connectionString = configuration.GetConnectionString("DefaultConnection");
        //        builder.UseSqlServer(connectionString);
        //        return new AppDbContext(builder.Options);
        //    }
        //}

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Photo> Photos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}


