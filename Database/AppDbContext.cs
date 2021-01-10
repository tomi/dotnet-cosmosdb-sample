using dotnet_cosmosdb_sample.Models;
using MongoDB.Driver;

public class AppDbContext
{
  private readonly IMongoDatabase _db;

  public AppDbContext(IMongoClient client, string dbName)
  {
    _db = client.GetDatabase(dbName);
  }

  public IMongoCollection<TodoItem> Todos => _db.GetCollection<TodoItem>("todos");
}
