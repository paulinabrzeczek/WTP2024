using System.Reflection.Metadata;

namespace WTP2024.DAL.Entity
{
    public partial class BeerDb
    {
        public BeerDb()
        {
            Ratings = new HashSet<RatingDb>();
        }

        public int IdBeer { get; set; }//!
        public string NameBeer { get; set; } = null!;//!
        public double AlcoholContent { get; set; }//!
        public string Type {  get; set; }
        public string Packaging { get; set; }//!
        public int Volume { get; set; }
        public string Country { get; set; }
        public Blob Image { get; set; }
        public double Price { get; set; }//!

        public virtual ICollection<RatingDb> Ratings { get; set; }
    }
}

