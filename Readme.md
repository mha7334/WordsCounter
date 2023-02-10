Follwing DB Table is required to be created
```
CREATE TABLE Watchlist (
	id INT NOT NULL IDENTITY PRIMARY KEY,
    Word VARCHAR(50) UNIQUE  NOT NULL,
);
```

Apart from this, the connectionString in appsettings.json file need to adjusted. 
```
"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=wordscounter;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
```

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