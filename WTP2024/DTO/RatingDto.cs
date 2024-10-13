using WTP2024.DAL.Entity;

namespace WTP2024.DTO
{
    public class RatingDto
    {
        public int Id { get; set; }
        public double Rating { get; set; }
        public DateTime AddedDate { get; set; }
        public int BeerId { get; set; }
        public BeerDb Beer { get; set; }
        public int UserId { get; set; }
    }
}
