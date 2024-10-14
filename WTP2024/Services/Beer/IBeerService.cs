using WTP2024.DTO;

namespace WTP2024.Services.Beer
{
    public interface IBeerService
    {
        Task<List<BeerDto>> GetAllBeersAsync();
        Task<BeerDto?> FindByIdAsync(int beerId);
    }
}
