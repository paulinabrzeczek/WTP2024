using WTP2024.DAL;

namespace WTP2024.Services
{
    public class BaseService
    {
        protected readonly WTP2024DbContext _dbContext;

        public BaseService(WTP2024DbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
