using Microsoft.EntityFrameworkCore;
using YandexGo.Domain.Entities.Cars;
using YandexGo.Domain.Entities.Orders;
using YandexGo.Domain.Entities.Ratings;
using YandexGo.Domain.Entities.Users;

namespace YandexGo.Data.Context
{
    public class YandexGoDbContext : DbContext
    {
        protected virtual DbSet<User> Users { get; set; }
        protected virtual DbSet<Rating> Ratings { get; set; }
        protected virtual DbSet<Order> Orders { get; set; }
        protected virtual DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Settings.CONNECTION_STRING);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasIndex(u => u.Username)
                        .IsUnique(true);

            modelBuilder.Entity<User>()
                        .HasIndex(c => c.Email)
                        .IsUnique(true);

            modelBuilder.Entity<User>()
                        .HasIndex(s => s.Login)
                        .IsUnique(true);

            modelBuilder.Entity<Car>()
                        .HasIndex(c => c.Number)
                        .IsUnique();
        }
    }
}
