using WTP2024.DAL;
using WTP2024.DAL.Entity;
using WTP2024.DTO;
using WTP2024.Repository.Beer;
using WTP2024.Repository.Rating;
using WTP2024.Services.User;

namespace WTP2024.Services.Rating
{
    public class RatingService : BaseService, IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly ILogger<UserService> _logger;

        public RatingService(WTP2024DbContext dbContext, ILogger<UserService> logger, IRatingRepository ratingRepository) : base(dbContext)
        {
            _ratingRepository = ratingRepository;
            _logger = logger;
        }
        public async Task AddRatingAsync(RatingDto ratingDto)
        {
            var rating = new RatingDb
            {
                Rating = ratingDto.Rating,
                AddedDate = ratingDto.AddedDate,
                BeerId = ratingDto.BeerId,
                UserId = ratingDto.UserId
            };
            await _ratingRepository.AddRatingAsync(rating);
        }

        public async Task<IEnumerable<RatingDto>> GetRatingsForBeerAsync(int beerId)
        {
            var ratings = await _ratingRepository.GetRatingsByBeerIdAsync(beerId);
            return ratings.Select(r => MapToDto(r)).ToList();
        }

        #region "Private"
        private static RatingDto MapToDto(RatingDb ratingDb)
        {
            return new RatingDto
            {
                Id = ratingDb.Id,
                Rating = ratingDb.Rating,
                AddedDate = ratingDb.AddedDate,
                BeerId = ratingDb.BeerId,
                UserId = ratingDb.UserId,
            };
        }
        #endregion
    }
}

