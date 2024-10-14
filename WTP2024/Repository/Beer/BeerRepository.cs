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
        public async Task<IList<BeerDb>> GetAllBeersAsyns()
        {
            return await _dbContext.Beers.OrderBy(x => x.Id)
                .Include(x => x.Ratings)
                .ToListAsync();
        }
        public async Task<bool> CheckIfExistsAsync(int beerId)
        {
            return await _dbContext.Beers.Where(x => x.Id == beerId).AnyAsync();
        }
        public async Task<BeerDb?> FindByIdAsync(int beerId)
        {
            return await _dbContext.Beers.Include(b => b.Ratings).FirstOrDefaultAsync(b => b.Id == beerId);
        }


    }
}
