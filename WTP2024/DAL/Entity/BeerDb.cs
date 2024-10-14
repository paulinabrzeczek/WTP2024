using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace WTP2024.DAL.Entity
{
    public class BeerDb
    {
    
        public int Id { get; set; }//!
        public string NameBeer { get; set; } = null!;//!
        public double AlcoholContent { get; set; }//!
        public string? Type {  get; set; }
        public string Packaging { get; set; }//!
        public int? Volume { get; set; }
        public string? Country { get; set; }
        public byte[]? Image { get; set; }
        public double Price { get; set; }//!
        public virtual ICollection<RatingDb> Ratings { get; set; }
    }
}

