namespace WTP2024.DTO
{
    public class BeerWithAvgRatingDto
    {
        public int Id { get; set; } 
        public string NameBeer { get; set; } 
        public double AlcoholContent { get; set; } 
        public string? Type { get; set; } 
        public string Packaging { get; set; } 
        public int? Volume { get; set; } 
        public string? Country { get; set; } 
        public byte[]? Image { get; set; } 
        public double Price { get; set; } 
        public double? AvgRating { get; set; } 
        public List<RatingDto>? Ratings { get; set; }
    }
}
