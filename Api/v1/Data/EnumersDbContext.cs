using DNDApi.Api.v1.Models.Entities.Enumers;
using Microsoft.EntityFrameworkCore;

namespace DNDApi.Api.v1.Data
{
    public class EnumersDbContext : DbContext
    {
        public EnumersDbContext(DbContextOptions<EnumersDbContext> options) : base(options) { }

        public DbSet<ClassEnumerEnity> ClassEnumer { get; set; }
        public DbSet<RaceEnumerEnity> RaceEnumer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClassEnumerEnity>(entity =>
            {
                entity.ToTable("class_enumer");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<RaceEnumerEnity>(entity =>
            {
                entity.ToTable("race_enumer");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}