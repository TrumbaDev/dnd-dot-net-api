using DNDApi.Api.v1.Models.Entities.Hero;
using Microsoft.EntityFrameworkCore;

namespace DNDApi.Api.v1.Data
{
    public class HeroDbContext : DbContext
    {
        public HeroDbContext(DbContextOptions<HeroDbContext> options) : base(options) { }

        public DbSet<HeroEntity> Hero { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HeroEntity>(entity =>
            {
                entity.ToTable("heroes");
                entity.HasKey(e => e.HeroId);
                entity.Property(e => e.HeroId).ValueGeneratedOnAdd();
            });
        }
    }
}