using DNDApi.Api.v1.DTO.Passive;
using DNDApi.Api.v1.Models.Entities.Passive;
using Microsoft.EntityFrameworkCore;

namespace DNDApi.Api.v1.Data
{
    public class PassiveDbContext : DbContext
    {
        public PassiveDbContext(DbContextOptions<PassiveDbContext> options) : base(options) { }

        public DbSet<PlayerPassivesEntity> PlayerPassives { get; set; }
        public DbSet<PassiveEntity> Passive { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlayerPassivesEntity>(entity =>
            {
                entity.ToTable("player_passives");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(pp => pp.Passive)
                    .WithMany()
                    .HasForeignKey(pp => pp.PassiveId)
                    .HasPrincipalKey(p => p.Id)
                    .IsRequired(false);
            });

            modelBuilder.Entity<PassiveEntity>(entity =>
            {
                entity.ToTable("passives");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}