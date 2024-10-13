using Microsoft.EntityFrameworkCore;
using WTP2024.DAL.Entity;

namespace WTP2024.DAL
{
    public partial class WTP2024DbContext : DbContext
    {
        public WTP2024DbContext()
        {
        }

        public WTP2024DbContext(DbContextOptions<WTP2024DbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<BeerDb> Beers { get; set; }
        public virtual DbSet<RatingDb> Ratings { get; set; }
        public virtual DbSet<RoleDb> Roles { get; set; }
        public virtual DbSet<UserDb> Users { get; set; }


    }
}
