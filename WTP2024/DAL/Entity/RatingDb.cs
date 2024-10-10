namespace WTP2024.DAL.Entity
{
    public partial class RatingDb
    {
        public int IdRating { get; set; }
        public int IdBeer { get; set; }
        public int IdUser { get; set; }
        public double Rating { get; set; } 
        public DateTime AddedDate { get; set; }
        public BeerDb Beer { get; set; }
        public UserDb User { get; set; }
    }
}
