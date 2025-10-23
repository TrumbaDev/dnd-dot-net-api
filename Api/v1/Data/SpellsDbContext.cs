using DNDApi.Api.v1.Models.Entities.Spells;
using Microsoft.EntityFrameworkCore;

namespace DNDApi.Api.v1.Data
{
    public class SpellsDbContext : DbContext
    {
        public SpellsDbContext(DbContextOptions<SpellsDbContext> options) : base(options) { }

        public DbSet<PlayerSpellsEntity> PlayerSpells { get; set; }
        public DbSet<SpellsEntity> Spells { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlayerSpellsEntity>(entity =>
            {
                entity.ToTable("player_spells");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(ps => ps.Spell)
                    .WithMany()
                    .HasForeignKey(ps => ps.SpellId)
                    .HasPrincipalKey(s => s.Id)
                    .IsRequired(false);
            });

            modelBuilder.Entity<SpellsEntity>(entity =>
            {
                entity.ToTable("spells");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}