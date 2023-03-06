using Microsoft.EntityFrameworkCore;
using DrWizardry.Models;

namespace DrWizardry.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Vocab> Vocabs { get; set; } = null!;
        public DbSet<DrWizardry.Models.Synonym> Synonym { get; set; }
    }
}
