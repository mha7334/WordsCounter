using Microsoft.EntityFrameworkCore;
using WordsCounter.Application.Interfaces;
using WordsCounter.Domain.Entities;

namespace WordsCounter.Infrastructure.Repository
{
    public class StatsRepository : IRepository<Stats>
    {
        private readonly WordsCounterDbContext _dbContext;

        public StatsRepository(WordsCounterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Stats>> GetAllAsync()
        {
            return await _dbContext.Stats
                .ToListAsync();
        }

        public async Task<Stats> AddAsync(Stats entity)
        {
            await _dbContext.Stats.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;

        }

        public async Task<Stats> UpdateAsync(Stats entity)
        {
            _dbContext.Stats.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Stats entity)
        {
            _dbContext.Stats.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

    }
}
