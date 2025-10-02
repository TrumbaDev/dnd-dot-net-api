using DNDApi.Api.v1.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DNDApi.Api.v1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasIndex(u => u.Login).IsUnique();
            });
        }
    }
}