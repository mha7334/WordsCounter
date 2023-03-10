using Microsoft.EntityFrameworkCore;
using WordsCounter.Application.Interfaces;
using WordsCounter.Domain.Entities;

namespace WordsCounter.Infrastructure.Repository
{
    public class WatchlistRepository : IRepository<Watchlist>
    {
        private readonly WordsCounterDbContext _dbContext;

        public WatchlistRepository(WordsCounterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Watchlist>> GetAllAsync()
        {
            return await _dbContext.Watchlist
                .ToListAsync();
        }

        public async Task<Watchlist> AddAsync(Watchlist entity)
        {
            await _dbContext.Watchlist.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Watchlist> UpdateAsync(Watchlist entity)
        {
            _dbContext.Watchlist.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Watchlist entity)
        {
            _dbContext.Watchlist.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
