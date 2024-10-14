using WTP2024.DAL.Entity;

namespace WTP2024.Repository.Rating
{
    public interface IRatingRepository
    {
        Task AddRatingAsync(RatingDb rating);
        Task<IEnumerable<RatingDb>> GetRatingsByBeerIdAsync(int beerId);
    }
}
