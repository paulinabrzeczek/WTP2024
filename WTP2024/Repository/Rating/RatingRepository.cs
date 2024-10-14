using Microsoft.EntityFrameworkCore;
using WTP2024.DAL;
using WTP2024.DAL.Entity;

namespace WTP2024.Repository.Rating
{
    public class RatingRepository : IRatingRepository
    {
        private readonly WTP2024DbContext _dbContext;
        public RatingRepository(WTP2024DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddRatingAsync(RatingDb rating)
        {
            await _dbContext.Ratings.AddAsync(rating);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<RatingDb>> GetRatingsByBeerIdAsync(int beerId)
        {
            return await _dbContext.Ratings
                .Where(r => r.BeerId == beerId)
                .ToListAsync();
        }
    }
}
