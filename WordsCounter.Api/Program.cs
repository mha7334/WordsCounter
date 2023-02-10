using Microsoft.EntityFrameworkCore;
using WordsCounter.Application.Interfaces;
using WordsCounter.Application.Services;
using WordsCounter.Infrastructure;
using WordsCounter.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();

    builder.Services.AddDbContext<WatchlistDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    //Application DI
    builder.Services.AddScoped<IWordsCounterService, WordsCounterService>();

    //Infrastructure DI
    builder.Services.AddScoped<IWatchlistRepository, WatchlistRepository>();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();

    app.MapControllers();
    app.Run();
}