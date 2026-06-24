using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahlilgaran.Models;

namespace Tahlilgaran.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Admin> Products => Set<Admin>();

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
    }
}
