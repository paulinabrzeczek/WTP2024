using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WTP2024.DAL.Entity;

namespace WTP2024.DAL.Configuration
{
    public class BeerDbConfiguration : IEntityTypeConfiguration<BeerDb>
    {
        public void Configure(EntityTypeBuilder<BeerDb> builder)
        {
            builder.ToTable("beer");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.NameBeer).HasColumnName("name").IsRequired().HasMaxLength(100);
            builder.Property(x => x.AlcoholContent).HasColumnName("alcohol_content").IsRequired();
            builder.Property(x => x.Type).HasColumnName("type").HasMaxLength(100);
            builder.Property(x => x.Packaging).HasColumnName("packaging").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Volume).HasColumnName("volume");
            builder.Property(x => x.Country).HasColumnName("country").HasMaxLength(100);
            builder.Property(x => x.Image).HasColumnName("image").HasColumnType("varbinary(max)");
            builder.Property(x => x.Price).HasColumnName("price").IsRequired();

            builder.HasMany(b => b.Ratings)
                .WithOne(r => r.Beer)
                .HasForeignKey(r => r.BeerId);

        }
    }
}
