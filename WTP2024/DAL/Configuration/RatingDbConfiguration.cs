using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WTP2024.DAL.Entity;

namespace WTP2024.DAL.Configuration
{
    public class RatingDbConfiguration : IEntityTypeConfiguration<RatingDb>
    {
        public void Configure(EntityTypeBuilder<RatingDb> builder)
        {
            builder.ToTable("rating");
            builder.HasKey(x => x.IdRating);

            builder.Property(x => x.IdRating).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.IdBeer).HasColumnName("idBeer").IsRequired();
            builder.Property(x => x.IdUser).HasColumnName("idUser").IsRequired();
            builder.Property(x => x.Rating).HasColumnName("rating").IsRequired();
            builder.Property(x => x.AddedDate).HasColumnName("addedDate");

            builder.HasOne(r => r.User)
                .WithMany(u => u.Ratings)
                .HasForeignKey(r => r.IdUser);

            builder.HasOne(r => r.Beer)
                .WithMany(b => b.Ratings)
                .HasForeignKey(r => r.IdBeer);
        }
    }
}
