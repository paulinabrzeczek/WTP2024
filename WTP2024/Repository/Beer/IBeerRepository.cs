using System.Threading.Tasks;
using WTP2024.DAL.Entity;

namespace WTP2024.Repository.Beer
{
    public interface IBeerRepository
    {
        Task<BeerDb?> GetBeerByIdAsync(int id); 
        Task<IEnumerable<BeerDb>> GetAllBeersAsync();
        Task<bool> CheckIfExistsAsync(int beerId);
        Task AddAsync(BeerDb beerDb);
    }
}
