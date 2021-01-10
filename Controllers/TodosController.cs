using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using dotnet_cosmosdb_sample.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;

namespace dotnet_cosmosdb_sample.Controllers
{
  [Route("api/[controller]")]
  public class TodosController : Controller
  {
    private readonly AppDbContext _db;

    public TodosController(AppDbContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<IEnumerable<TodoItemJson>> GetAsync([FromQuery] bool? completed = null)
    {
      var list = new List<TodoItemJson>();
      var result = await _db.Todos.Find(new BsonDocument()).ToListAsync();

      return result.Select(t => TodoItemJson.FromTodoItem(t));
    }

    [HttpGet("{id}")]
    public async Task<TodoItemJson> GetAsync(string id)
    {
      var result = await _db.Todos.Find(a => a.Id == id).SingleOrDefaultAsync();

      return result != null ? TodoItemJson.FromTodoItem(result) : null;
    }

    [HttpPost]
    public async Task<TodoItemJson> CreateAsync([FromBody] CreateTodoItem itemData)
    {
      var itemToCreate = new TodoItem()
      {
        Creator = itemData.Creator,
        Title = itemData.Title,
        Completed = itemData.Completed
      };

      await _db.Todos.InsertOneAsync(itemToCreate);

      return TodoItemJson.FromTodoItem(itemToCreate);
    }
  }
}
