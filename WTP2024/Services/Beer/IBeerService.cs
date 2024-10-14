using WTP2024.DTO;

namespace WTP2024.Services.Beer
{
    public interface IBeerService
    {
        Task<BeerWithAvgRatingDto?> GetBeerWithAvgRatingAsync(int id); 
        Task<IEnumerable<RatingDto>> GetAllBeersWithAvgRatingAsync();
        Task AddAsync(BeerDto beerDto);
    }
}
