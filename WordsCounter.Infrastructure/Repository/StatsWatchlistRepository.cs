using Microsoft.EntityFrameworkCore;
using WordsCounter.Application.Interfaces;
using WordsCounter.Domain.Entities;

namespace WordsCounter.Infrastructure.Repository
{
    public class StatsWatchlistRepository : IRepository<StatsWatchlist>
    {
        private readonly WordsCounterDbContext _dbContext;

        public StatsWatchlistRepository(WordsCounterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<StatsWatchlist>> GetAllAsync()
        {
            return await _dbContext.StatsWatchlist
                .ToListAsync();
        }

        public async Task<StatsWatchlist> AddAsync(StatsWatchlist entity)
        {
            await _dbContext.StatsWatchlist.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<StatsWatchlist> UpdateAsync(StatsWatchlist entity)
        {
            _dbContext.StatsWatchlist.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(StatsWatchlist entity)
        {
            _dbContext.StatsWatchlist.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

    }
}
