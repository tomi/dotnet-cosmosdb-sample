using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Security.Authentication;

namespace dotnet_cosmosdb_sample
{
  public class CosmosClient
  {
    public IMongoDatabase ConnectAndGetDatabase(IConfiguration config)
    {
      string connectionString = config["MONGODB_CONNECTION_STRING"];
      MongoClientSettings settings = MongoClientSettings.FromUrl(
        new MongoUrl(connectionString)
      );
      settings.SslSettings = new SslSettings()
      {
        EnabledSslProtocols = SslProtocols.Tls12
      };

      var mongoClient = new MongoClient(settings);
      var db = mongoClient.GetDatabase(config["MONGODB_DATABASE"]);
      return db;
    }
  }
}
