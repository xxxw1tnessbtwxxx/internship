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

        public bool isDatabaseConnected { get; private set; } = false;

        public DbSet<OpenedShift> OpenedShifts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Access> Accesess { get; set; }
        public DbSet<ShiftStory> ShiftStories { get; set; }   
        public DbSet<Gender> Genders { get; set; }
        public DbSet<TradePoint> TradePoints { get; set; }

        public TimeControllerContext()
        {
            try
            {
                Database.OpenConnection();
                this.isDatabaseConnected = true;
            }
            catch
            {
                this.isDatabaseConnected = false;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Server=localhost;Username=postgres;Password=123456;Database=timecontroller");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<OpenedShift>().Property(o => o.OpenedDate).HasColumnType("timestamp without time zone");

            modelBuilder.Entity<ShiftStory>().Property(s => s.ComeDate).HasColumnType("timestamp without time zone");
            modelBuilder.Entity<ShiftStory>().Property(s => s.LeaveDate).HasColumnType("timestamp without time zone");
            base.OnModelCreating(modelBuilder);

        }

    }
}
