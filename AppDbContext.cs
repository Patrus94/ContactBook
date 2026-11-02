using ContactBook.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactBook
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { 
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlite("Data Source = Contact.db");
            }

        }
        public DbSet<Contact> Contacts => Set<Contact>();
        public DbSet<Note>Notes => Set<Note>();
        public DbSet<Tag>Tags => Set<Tag>();
        public DbSet<ContactTag>ContacTags => Set<ContactTag>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactTag>()
                .HasKey(c => new { c.ContactId, c.TagId });

            modelBuilder.Entity<ContactTag>()
                .HasOne(c => c.Contact)
                .WithMany(c => c.ContactTags)
                .HasForeignKey(c => c.ContactId);

            modelBuilder.Entity<ContactTag>()
                .HasOne(c => c.Tag)
                .WithMany(c => c.ContactTags)
                .HasForeignKey(c => c.TagId);
            
            modelBuilder.Entity<Contact>(entity => {
                entity.Property(c => c.FullName)
                .HasMaxLength(120)
                .IsRequired();

                entity.Property(c => c.Email)
                .HasMaxLength(180)
                .IsRequired();

                entity.HasIndex(c => c.Email)
                .IsUnique();

                entity.HasMany(c => c.Notes)
                .WithOne(n => n.Contact)
                .HasForeignKey(n => n.ContactId)
                .OnDelete(DeleteBehavior.Cascade);
                
            });


         
        }

    }
}
