using DNDApi.Api.v1.Models.Entities.Items;
using Microsoft.EntityFrameworkCore;

namespace DNDApi.Api.v1.Data
{
    public class ItemsDbContext : DbContext
    {
        public ItemsDbContext(DbContextOptions<ItemsDbContext> options) : base(options) { }

        public DbSet<ArmorsEntity> Armors { get; set; }

        public DbSet<WeaponsEntity> Weapons { get; set; }

        public DbSet<OthersEntity> Others { get; set; }

        public DbSet<PotionEntity> Potion { get; set; }

        public DbSet<FoodsEntity> Foods { get; set; }
        public DbSet<PlayerItemsEntity> PlayerItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ArmorsEntity>(entity =>
            {
                entity.ToTable("armors_table");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<WeaponsEntity>(entity =>
            {
                entity.ToTable("weapons_table");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<OthersEntity>(entity =>
            {
                entity.ToTable("other_items");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<PotionEntity>(entity =>
            {
                entity.ToTable("potion_table");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<FoodsEntity>(entity =>
            {
                entity.ToTable("food_table");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<PlayerItemsEntity>(entity =>
            {
                entity.ToTable("player_items");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(pi => pi.Armor)
                    .WithMany()
                    .HasForeignKey(pi => pi.ItemId)
                    .HasPrincipalKey(a => a.Id)
                    .IsRequired(false);

                entity.HasOne(pi => pi.Weapon)
                    .WithMany()
                    .HasForeignKey(pi => pi.ItemId)
                    .HasPrincipalKey(w => w.Id)
                    .IsRequired(false);

                entity.HasOne(pi => pi.Potion)
                    .WithMany()
                    .HasForeignKey(pi => pi.ItemId)
                    .HasPrincipalKey(p => p.Id)
                    .IsRequired(false);

                entity.HasOne(pi => pi.Food)
                    .WithMany()
                    .HasForeignKey(pi => pi.ItemId)
                    .HasPrincipalKey(f => f.Id)
                    .IsRequired(false);

                entity.HasOne(pi => pi.Other)
                    .WithMany()
                    .HasForeignKey(pi => pi.ItemId)
                    .HasPrincipalKey(o => o.Id)
                    .IsRequired(false);
            });
        }
    }
}