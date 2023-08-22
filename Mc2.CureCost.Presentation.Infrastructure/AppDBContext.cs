using Mc2.CureCost.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CureCost.Presentation.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Event> Events { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(c => new { c.Firstname, c.Lastname, c.DateOfBirth }).IsUnique();
                entity.OwnsOne(c => c.PhoneNumber);
                entity.OwnsOne(c => c.BankAccountNumber);
            });

            modelBuilder.Entity<Customer>()
                .OwnsOne(c => c.Email, email =>
                {
                    email.Property(e => e.Value)
                        .HasColumnName("Email")
                        .IsRequired();
                });
        }
    }
}