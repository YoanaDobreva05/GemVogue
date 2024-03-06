using GemVogue.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GemVogue.Data
{
    public class GemVogueDbContext : IdentityDbContext<User>
    {
        public GemVogueDbContext(DbContextOptions<GemVogueDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Favorite> Favorites { get; set; }

        public DbSet<Jewel> Jewelry { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Jewel>()
                .HasOne(j => j.Producer)
                .WithMany(p => p.Jewels)
                .HasForeignKey(j => j.ProducerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Favorite>()
                .HasKey(f => new { f.JewelId, f.UserId });

            builder.Entity<Favorite>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Favorite>()
                .HasOne(f => f.Jewel)
                .WithMany(j => j.Favorites)
                .HasForeignKey(f => f.JewelId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
