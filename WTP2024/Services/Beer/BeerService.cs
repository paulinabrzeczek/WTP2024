using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WTP2024.DAL;
using WTP2024.DAL.Entity;
using WTP2024.DTO;
using WTP2024.Repository.Beer;
using WTP2024.Repository.User;
using WTP2024.Services.User;

namespace WTP2024.Services.Beer
{
    public class BeerService : BaseService, IBeerService
    {
        private readonly IBeerRepository _beerRepository;
        private readonly ILogger<UserService> _logger;

        public BeerService(WTP2024DbContext dbContext, ILogger<UserService> logger, IBeerRepository beerRepository) : base(dbContext)
        {
            _beerRepository = beerRepository;
            _logger = logger;
        }
        public async Task<BeerWithAvgRatingDto?> GetBeerWithAvgRatingAsync(int id)
        {
            var beer = await _beerRepository.GetBeerByIdAsync(id);

            if (beer == null)
            {
                return null; 
            }

            double? avgRating = beer.Ratings.Any() ? beer.Ratings.Average(r => r.Rating) : (double?)null;

            return new BeerWithAvgRatingDto
            {
                Id = beer.Id,
                NameBeer = beer.NameBeer,
                AlcoholContent = beer.AlcoholContent,
                Type = beer.Type,
                Packaging = beer.Packaging,
                Volume = beer.Volume,
                Country = beer.Country,
                Image = beer.Image,
                Price = beer.Price,
                AvgRating = avgRating,
                Ratings = beer.Ratings.Select(r => new RatingDto
                {
                    Id = r.Id,
                    Rating = r.Rating,
                    AddedDate = r.AddedDate,
                    BeerId = r.BeerId,
                    UserId = r.UserId
                }).ToList()
            };
        }
        public async Task<IEnumerable<RatingDto>> GetAllBeersWithAvgRatingAsync()
        {
            var beers = await _beerRepository.GetAllBeersAsync();

            return beers.Select(beer => new RatingDto
            {
                Id = beer.Id,
                BeerId = beer.Id,
                Beer = beer,
                Rating = beer.Ratings.Any() ? beer.Ratings.Average(r => r.Rating) : 0.0, 
                AddedDate = DateTime.Now, // To pole możesz dostosować
                UserId = 0 // Zostawiasz puste, jeśli nie potrzebujesz użytkownika
            }).ToList();
        }

        public async Task AddAsync(BeerDto beerDto)
        {

            var beer = new BeerDb
            {
                NameBeer = beerDto.NameBeer,
                AlcoholContent = beerDto.AlcoholContent,
                Type = beerDto.Type,
                Packaging = beerDto.Packaging,
                Volume = beerDto.Volume,
                Country = beerDto.Country,
                Image = beerDto.Image,
                Price = beerDto.Price
            };
            _dbContext.Beers.Add(beer);
            await _dbContext.SaveChangesAsync();
        }
        #region "Private"
        private static BeerDto MapToDto(BeerDb beerDb)
        {
            return Map<BeerDto>(beerDb);
        }
        private static T Map<T>(BeerDb beerDb) where T : BeerDto, new()
            => new()
            {
                Id = beerDb.Id,
                NameBeer = beerDb.NameBeer,
                AlcoholContent = beerDb.AlcoholContent,
                Type = beerDb.Type,
                Packaging = beerDb.Packaging,
                Volume = beerDb.Volume,
                Country =beerDb.Country,
                Image = beerDb.Image,
                Price = beerDb.Price,
                Rating = beerDb.Ratings != null && beerDb.Ratings.Any()
                    ? beerDb.Ratings.Average(r => r.Rating) 
                    : (double?)null
            };

        #endregion
    }
}
