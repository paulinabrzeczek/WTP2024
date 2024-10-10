using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WTP2024.DAL.Entity;

namespace WTP2024.DAL.Configuration
{
    public class RoleDbConfiguration : IEntityTypeConfiguration<RoleDb>
    {
        public void Configure(EntityTypeBuilder<RoleDb> builder)
        {
            builder.ToTable("role");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.NameRole).HasColumnName("name_role");

          

        }
    }
}
