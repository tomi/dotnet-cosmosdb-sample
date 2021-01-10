# Azure Cosmos DB (MongoDB API) + ASP.NET Core sample

Sample on how to use Azure Cosmos DB MongoDB API with ASP.NET Core

## Requirements

- Azure Cosmos DB MongoDB API account
- .NET 5

## Setup

1. Create a Cosmos DB database and a todos container

Follow the steps on ["Create a database account"](https://docs.microsoft.com/en-us/azure/cosmos-db/create-mongodb-dotnet#create-a-database-account)

2. Configure the connection string

```bash
cp .env-example.sh .env.sh
# Fill the connection string and database name and:
source .env.sh
```

3. Run the application

```bash
dotnet run
```

## Test

```bash
# Create a todo item
curl -d '{"Creator": "me", "Title": "Sample todo item"}' -H 'Content-Type: application/json' http://localhost:5000/api/todos
# List all todo items
curl http://localhost:5000/api/todos
```

## Endpoints

### `POST /api/todos`

Create a new todo

Request body:

```json
{
  "Creator": "Name who created the item",
  "Title": "Title of the todo item",
  "Completed": false
}
```

### `GET /api/todos`

List all todos

### `GET /api/todos/{id}`

Get a single todo
