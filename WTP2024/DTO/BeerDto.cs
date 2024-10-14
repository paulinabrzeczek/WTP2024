using Microsoft.AspNetCore.Routing.Constraints;

namespace WTP2024.DTO
{
    public class BeerDto
    {
        public int Id { get; set; }//!
        public string NameBeer { get; set; } = null!;//!
        public double AlcoholContent { get; set; }//!
        public string Type { get; set; }
        public string Packaging { get; set; }//!
        public int Volume { get; set; }
        public string Country { get; set; }
        public byte[] Image { get; set; }
        public double Price { get; set; }//!
        public double? Rating { get; set; }
    }
}
