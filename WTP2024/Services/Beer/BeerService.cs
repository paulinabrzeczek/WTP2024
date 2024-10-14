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
        public async Task<List<BeerDto>> GetAllBeersAsync()
        {
            var beersDb = await _beerRepository.GetAllBeersAsyns();
            var beerDtos = beersDb.Select(b => MapToDto(b)).ToList();
            return beerDtos;
        }
        public async Task<BeerDto?> FindByIdAsync(int beerId)
        {
            var beerDb = await _beerRepository.FindByIdAsync(beerId);
            if (beerDb == null)
            {
                return null;
            }
            return MapToDto(beerDb);
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
