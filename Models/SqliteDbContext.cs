using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MarsRover.Models
{
    public class SqliteDbContext : DbContext
    {
        public DbSet<Grid> Grids { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Rover> Rovers { get; set; }
        public DbSet<Movement> Movements { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "sqlitedb.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grid>().ToTable("Grids");

            base.OnModelCreating(modelBuilder);
        }
    }
}
