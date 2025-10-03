using DNDApi.Api.v1.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DNDApi.Api.v1.Data
{
    public class ItemsDbContext : DbContext
    {
        public ItemsDbContext(DbContextOptions<ItemsDbContext> options) : base(options){}
        
        public DbSet<ArmorsEntity> Armors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            

            modelBuilder.Entity<ArmorsEntity>(entity =>
            {
                entity.ToTable("armors_table");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}