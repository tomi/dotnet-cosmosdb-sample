using MongoDB.Bson;

namespace dotnet_cosmosdb_sample.Models
{
  public class TodoItemJson
  {
    public string Id { get; set; }

    public string Creator { get; set; }
    public string Title { get; set; }

    public bool Completed { get; set; }

    public static TodoItemJson FromTodoItem(TodoItem todoItem)
    {
      return new TodoItemJson
      {
        Id = todoItem.Id,
        Creator = todoItem.Creator,
        Title = todoItem.Title,
        Completed = todoItem.Completed,
      };
    }

    public static TodoItemJson FromTodoItem(BsonDocument doc)
    {
      return new TodoItemJson
      {
        Id = doc["_id"].AsString,
        Creator = doc["Creator"].AsString,
        Title = doc["Title"].AsString,
        Completed = doc["Completed"].AsBoolean,
      };
    }
  }
}