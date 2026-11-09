# C#Api

A lightweight ASP.NET Core Web API for managing product data with PostgreSQL. This project demonstrates a simple layered API design using controllers, repositories, and services.

## Features

- ASP.NET Core Web API using .NET 10
- PostgreSQL connectivity via Npgsql
- Product listing endpoint
- Environment-based configuration for database settings
- OpenAPI support for development

## Tech Stack

- C#
- ASP.NET Core
- PostgreSQL
- Npgsql
- DotNetEnv

## Project Structure

- `Controllers/` - API endpoints
- `Models/` - Data models
- `Repositories/` - Data access logic
- `Services/` - Business logic layer
- `Data/` - Database setup files
- `Program.cs` - Application startup and DI configuration
- `.env` - local environment variables for database connection

## Prerequisites

- .NET 10 SDK
- PostgreSQL database
- A valid database user and connection details

## Configuration

Create or update a `.env` file in the project root with values similar to:

```env
Host=your-postgres-host
Database=your-database-name
Username=your-db-username
Password=your-db-password
port=5432
```

The application loads these values in `Program.cs` and builds the PostgreSQL connection string automatically.

## Run the API

From the project root:

```bash
dotnet restore
dotnet run
```

By default, the API listens on the ASP.NET Core local development URL (for example `https://localhost:5001` or `http://localhost:5000` depending on your environment).

## API Endpoint

### Get all products

```http
GET /products
```

Example response:

```json
[
  {
    "id": 1,
    "name": "Nike Shoes",
    "price": 120
  },
  {
    "id": 2,
    "name": "Adidas Shirt",
    "price": 80
  }
]
```

The repository filters products to return only records with a price below 2000.

## Database Notes

This project expects a PostgreSQL table named `products` with at least the following fields:

```sql
CREATE TABLE products (
    id SERIAL PRIMARY KEY,
    name TEXT NOT NULL,
    price INTEGER NOT NULL
);
```

You can extend the schema as needed for additional fields such as `image`, `description`, or `size`.

## Development Notes

- OpenAPI is enabled in development mode.
- The application uses dependency injection for repository and service registration.
- The project is structured to be easy to extend with additional CRUD operations.

## License

This project is provided as-is for learning and development purposes.
