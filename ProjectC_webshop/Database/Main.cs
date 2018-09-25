using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Model {
    public class WebshopContext : DbContext {

        // Hieronder staan de echte entity's die in de database staan.
        public DbSet<Users> Users { get; set; }
        public DbSet<Role> Role { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            //here we define the name of our database
            optionsBuilder.UseNpgsql("User ID=postgres;Password=Rotterdam1997;Host=localhost;Port=5432;Database=WebshopDB;Pooling=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Make Define Primari key for Role
            modelBuilder.Entity<Role>().HasKey(t => new { t.UserId } );
            // Make relation between Users and Role
            modelBuilder.Entity<Role>().HasOne(R => R.User).WithOne(U => U.Roles);

        }
    }
}