using WTP2024.DAL.Entity;

namespace WTP2024.Repository.Beer
{
    public interface IBeerRepository
    {
        Task<IList<BeerDb>> GetAllBeersAsyns();
        Task<BeerDb?> FindByIdAsync(int beerId);
        Task<bool> CheckIfExistsAsync(int beerId);
        Task AddAsync(BeerDb beerDb);
    }
}
