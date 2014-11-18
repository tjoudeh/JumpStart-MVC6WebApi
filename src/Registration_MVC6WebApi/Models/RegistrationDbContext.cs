using Microsoft.Data.Entity;
using System;
using Microsoft.Data.Entity.Metadata;

namespace Registration_MVC6WebApi.Models
{
    public class RegistrationDbContext :DbContext
    {
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptions options)
        {
            options.UseSqlServer(Startup.Configuration.Get("Data:DefaultConnection:ConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}