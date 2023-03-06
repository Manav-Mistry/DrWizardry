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
            
            /*modelBuilder.Entity<UserVocab>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.UserVocabs)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UserVocab>()
                .HasOne(pt => pt.Vocab)
                .WithMany(t => t.UserVocabs)
                .HasForeignKey(pt => pt.VocabId);*/
        }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Vocab> Vocabs { get; set; } = null!;
        public DbSet<DrWizardry.Models.Synonym> Synonym { get; set; }
    }
}
