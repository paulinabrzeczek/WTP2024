using WTP2024.DTO;

namespace WTP2024.Services.Rating
{
    public interface IRatingService
    {
        Task AddRatingAsync(RatingDto ratingDto);
        Task<IEnumerable<RatingDto>> GetRatingsForBeerAsync(int beerId);
    }
}
