using ClientProperty.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClientProperty.Domain
{
    public class AppDbContext : DbContext
    {
        public DbSet<Property> Properties { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(userId => userId.Id);

            modelBuilder.Entity<Property>()
                .HasKey(propertyId => propertyId.Id);

            modelBuilder.Entity<User>()
                .HasMany(up => up.UserProperties)
                .WithOne(user => user.User)
                .HasForeignKey(userId => userId.UserId);

            modelBuilder.Entity<Property>()
                .HasMany(up => up.UserProperties)
                .WithOne(property => property.Property)
                .HasForeignKey(propertyId => propertyId.PropertyId);

            modelBuilder.Entity<UserProperty>()
               .HasKey(up => new
               {
                   up.UserId,
                   up.PropertyId,
               });

            //modelBuilder.Entity<Period>()
            //    .HasKey(periodId => periodId.Id);
        }
    }
}
