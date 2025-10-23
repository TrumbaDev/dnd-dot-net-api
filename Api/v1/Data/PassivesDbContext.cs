using DNDApi.Api.v1.Models.Entities.Passives;
using Microsoft.EntityFrameworkCore;

namespace DNDApi.Api.v1.Data
{
    public class PassivesDbContext: DbContext
    {
        public PassivesDbContext(DbContextOptions<PassivesDbContext> options) : base(options) { }

        public DbSet<PlayerPassivesEntity> PlayerPassives { get; set; }
        public DbSet<PassivesEntity> Passives { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlayerPassivesEntity>(entity =>
            {
                entity.ToTable("player_passive");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(pp => pp.Passive)
                    .WithMany()
                    .HasForeignKey(pp => pp.PassiveId)
                    .HasPrincipalKey(p => p.Id)
                    .IsRequired(false);
            });

            modelBuilder.Entity<PassivesEntity>(entity =>
            {
                entity.ToTable("passive_abilities");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}