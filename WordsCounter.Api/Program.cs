using Microsoft.EntityFrameworkCore;
using WordsCounter.Application.Interfaces;
using WordsCounter.Application.Services;
using WordsCounter.Domain.Entities;
using WordsCounter.Infrastructure;
using WordsCounter.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<WordsCounterDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    //Application DI
    builder.Services.AddScoped<IWordsCounterService, WordsCounterService>();

    //Infrastructure DI
    builder.Services.AddScoped<IRepository<Watchlist>, WatchlistRepository>();
    builder.Services.AddScoped<IRepository<Stats>, StatsRepository>();
    builder.Services.AddScoped<IRepository<StatsWatchlist>, StatsWatchlistRepository>();
}

var app = builder.Build();
{

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.MapControllers();
    app.Run();
}