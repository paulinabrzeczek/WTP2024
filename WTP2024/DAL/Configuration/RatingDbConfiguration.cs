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
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.Rating).HasColumnName("rating").IsRequired();
            builder.Property(x => x.AddedDate).HasColumnName("added_date");


        }
    }
}
