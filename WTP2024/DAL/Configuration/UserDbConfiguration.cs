using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WTP2024.DAL.Entity;
using System.Reflection.Emit;

namespace WTP2024.DAL.Configuration
{
    public class UserDbConfiguration : IEntityTypeConfiguration<UserDb>
    {
        public void Configure(EntityTypeBuilder<UserDb> builder)
        {
            builder.ToTable("user");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Username).HasColumnName("username").IsRequired();
            builder.Property(x => x.Passwordhash).HasColumnName("passwordhash").IsRequired().HasMaxLength(100);
            builder.Property(u => u.RoleId)
            .IsRequired(); // Klucz obcy

            builder.HasIndex(x => x.Username).IsUnique();

            builder.HasMany(u => u.Ratings)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            builder.HasOne(u => u.Role) // Użytkownik ma jedną rolę
            .WithMany(r => r.Users) // Rola ma wielu użytkowników
            .HasForeignKey(u => u.RoleId); // Klucz obcy
        }

    }
}

