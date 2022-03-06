using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;

namespace Plugins.DataStore.SQL {

    public class ScheduleContext : DbContext {
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public ScheduleContext(DbContextOptions options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Bookings)
                .WithOne(b => b.Customer)
                .HasForeignKey(b => b.CustomerId);

            modelBuilder.Entity<Booking>()
                .HasMany(b => b.Attendances)
                .WithOne(a => a.Booking)
                .HasForeignKey(a => a.BookingId);
        }
    }
}