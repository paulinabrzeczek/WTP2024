using System.ComponentModel.DataAnnotations;

namespace WTP2024.DAL.Entity
{
    public partial class RatingDb
    {
        public int Id { get; set; }
        public double Rating { get; set; } 
        public DateTime AddedDate { get; set; }
        public int BeerId { get; set; }
        public BeerDb Beer { get; set; }
        public int UserId { get; set; }
        public UserDb User { get; set; }
    }
}
