using DatabaseLayer.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Database
{
    public class TimeControllerContext: DbContext
    {

        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TradePoint> TradePoints { get; set; }

        public TimeControllerContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Server=localhost;Username=postgres;Password=123;Database=timecontroller");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }
}
