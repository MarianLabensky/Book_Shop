# Book Shop
## About project
It`s a simple web-site for books selling with shop cart, order block and database.

Technologies used during development of project included ASP.NET Core 3.1, Entity Framework, SQL, Linq(work with list), HTML5, CSS3, Bootstrap.

Working site is available [here](http://www.bookshopp.somee.com)

## How to launch and run

1. Install project and launch in Visual Studio

2. In file appsettings.json change connection string if you want use your own database or leave it at that

```json
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BookShop_db;Trusted_Connection=True"
  }
```
3. Then in database have to create tables according to models in project. For this you need open Package Manager Console window from within Visual Studio by going to Tools -> Library Package Manager -> Package Manager Console.
And input a command `enable-migrations` then `add-migration "AddNewMigration"` and then `update-database`.

After this manipulations in database will be created tables and we will run project.	
