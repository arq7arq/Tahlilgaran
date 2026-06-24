using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahlilgaran.Models;
using Tahlilgaran.Utility;

namespace Tahlilgaran.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Admin> Admins => Set<Admin>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var folder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Tahlilgaran"
            );

            Directory.CreateDirectory(folder);

            var dbPath = Path.Combine(folder, "app.db");

            optionsBuilder.UseSqlite($"Data Source={dbPath}");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasData(
                new Admin() { AdminID=1, Username="admin", Password=PasswordHasher.HashPassword("1234")}
            );
        }

    }
}
