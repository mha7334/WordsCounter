Follwing DB Tables
```
CREATE TABLE Watchlist (
	id INT NOT NULL IDENTITY PRIMARY KEY,
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
![image](https://user-images.githubusercontent.com/4058181/218311597-a7d1daed-a554-49fb-8331-1ac1b2437d42.png)
![image](https://user-images.githubusercontent.com/4058181/218311631-276852ef-08a9-4462-95ec-55160c203ea6.png)



Clean Architecture solution and projects creation
```
dotnet new sln -o WordsCounter 

cd WordsCounter

dotnet new webapi -o WordsCounter.Api
dotnet new classlib -o WordsCounter.Contracts
dotnet new classlib -o WordsCounter.Infrastructure
dotnet new classlib -o WordsCounter.Application
dotnet new classlib -o WordsCounter.Domain

dotnet sln add (ls -r **\*.csproj)

dotnet add .\WordsCounter.Api\ reference .\WordsCounter.Contracts\ .\WordsCounter.Application\
dotnet add .\WordsCounter.Infrastructure\ reference .\WordsCounter.Application\
dotnet add .\WordsCounter.Application\ reference .\WordsCounter.Domain\ 
dotnet add .\WordsCounter.Application\ reference .\WordsCounter.Infrastructure\

```
