using Microsoft.EntityFrameworkCore;
using WTP2024.DAL;
using WTP2024.DAL.Entity;

namespace WTP2024.Repository.Beer
{
    public class BeerRepository : IBeerRepository
    {
        private readonly WTP2024DbContext _dbContext;
        public BeerRepository(WTP2024DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<BeerDb?> GetBeerByIdAsync(int id)
        {
            return await _dbContext.Beers
                .Include(b => b.Ratings) 
                .FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task<IEnumerable<BeerDb>> GetAllBeersAsync()
        {
            return await _dbContext.Beers
                .Include(b => b.Ratings) 
                .ToListAsync();
        }
        public async Task<bool> CheckIfExistsAsync(int beerId)
        {
            return await _dbContext.Beers.Where(x => x.Id == beerId).AnyAsync();
        }
        public async Task AddAsync(BeerDb beerDb)
        {
            await _dbContext.Beers.AddAsync(beerDb);
            await _dbContext.SaveChangesAsync();
        }


    }
}
