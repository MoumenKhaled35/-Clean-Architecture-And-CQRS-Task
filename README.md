# Catalog API – Clean Architecture + CQRS

## Run
1. Edit the connection string in `Catalog.WebApi/appsettings.json`.
2. From the solution folder:

```
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate -p Catalog.Infrastructure -s Catalog.WebApi
dotnet ef database update -p Catalog.Infrastructure -s Catalog.WebApi
dotnet run --project Catalog.WebApi
```

3. Open `/swagger`.

## Endpoints
| Method | Route              | Description       |
|--------|--------------------|-------------------|
| GET    | /api/products      | List all products |
| GET    | /api/products/{id} | Get product by id |
| POST   | /api/products      | Add a product     |

POST body: `{ "name": "Laptop", "price": 1500.00 }`
