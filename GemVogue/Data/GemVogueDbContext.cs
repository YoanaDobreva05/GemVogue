using GemVogue.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GemVogue.Data
{
    public class GemVogueDbContext : IdentityDbContext
    {
        public GemVogueDbContext(DbContextOptions<GemVogueDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Jewelry> Jewelry { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
