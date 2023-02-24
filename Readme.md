Follwing DB Tables
```
CREATE TABLE Watchlist (
	id SMALLINT NOT NULL IDENTITY PRIMARY KEY,
    Word VARCHAR(50) UNIQUE  NOT NULL,
);

CREATE TABLE Stats (
    Id BIGINT NOT NULL IDENTITY PRIMARY KEY,
    WordCount BIGINT
);

CREATE TABLE StatsWatchlist (
    StatsId BIGINT,
    WatchlistId SMALLINT,
    PRIMARY KEY (StatsId, WatchlistId),
    FOREIGN KEY (StatsId) REFERENCES Stats(Id),
    FOREIGN KEY (WatchlistId) REFERENCES Watchlist(id)
);

```

Apart from this, the connectionString in appsettings.json file need to adjusted. 
```
"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=wordscounter;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
```

Example:

![image](https://user-images.githubusercontent.com/4058181/218311700-f39c4f63-7fcc-491e-9af2-5d80fa657934.png)



Clean Architecture solution and projects creation
```
dotnet new sln -o WordsCounter 

cd WordsCounter

mkdir src
mkdir tests

dotnet new webapi -o src\WordsCounter.Api
dotnet new classlib -o src\WordsCounter.Contracts
dotnet new classlib -o src\WordsCounter.Infrastructure
dotnet new classlib -o src\WordsCounter.Application
dotnet new classlib -o src\WordsCounter.Domain

dotnet sln WordCounter.sln add (ls src/**/*.csproj)

dotnet add .\src\WordsCounter.Api\ reference .\src\WordsCounter.Application\ .\src\WordsCounter.Contracts\
dotnet add .\src\WordsCounter.Infrastructure\ reference .\src\WordsCounter.Application\
dotnet add .\src\WordsCounter.Application\ reference .\src\WordsCounter.Domain\ 
dotnet add .\src\WordsCounter.Application\ reference .\src\WordsCounter.Infrastructure\

dotnet new xunit -o .\tests\Infrastructure.Tests
dotnet new xunit -o .\tests\Application.Tests
dotnet new xunit -o .\tests\Doamin.Tests

dotnet sln WordCounter.sln add (ls tests/**/*.csproj)

dotnet add .\tests\Application.Tests\ reference .\src\WordsCounter.Application\
dotnet add .\tests\Domain.Tests\ reference .\src\WordsCounter.Domain\
dotnet add .\tests\Infrastructure.Tests\ reference .\src\WordsCounter.Infrastructure\



```
