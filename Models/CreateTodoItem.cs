using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnet_cosmosdb_sample.Models
{
  public class CreateTodoItem
  {
    public string Creator { get; set; }
    public string Title { get; set; }
    public bool Completed { get; set; }
  }
}