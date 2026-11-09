# C# API

A lightweight ASP.NET Core Web API for managing product data using PostgreSQL.

This project demonstrates a practical approach to backend API development with C#, ASP.NET Core, and a layered architecture. It is shared as an educational reference for developers interested in understanding API structure, database connectivity, dependency injection, and separation of concerns.

## Overview

The application provides a product listing endpoint backed by a PostgreSQL database.

It uses a layered architecture to separate HTTP request handling, business logic, and database access, making the code easier to understand, maintain, and extend.

## Features

- ASP.NET Core Web API using .NET 10
- PostgreSQL connectivity via Npgsql
- Product listing endpoint
- Environment-based database configuration
- OpenAPI support for development
- Dependency Injection
- Separation of controllers, services, and repositories

## Tech Stack

| Technology | Purpose |
|---|---|
| C# | Main programming language |
| .NET 10 | Application framework |
| ASP.NET Core Web API | Backend API framework |
| PostgreSQL | Relational database |
| Npgsql | PostgreSQL connectivity |
| DotNetEnv | Environment variable loading |

## Project Structure

```text
C#Api/
│
├── Controllers/
│   └── ProductController.cs
│
├── Models/
│   └── Product.cs
│
├── Repositories/
│   └── ProductRepository.cs
│
├── Services/
│   └── ProductService.cs
│
├── Data/
│   └── Database setup files
│
├── Program.cs
├── appsettings.json
├── .env
└── C#Api.csproj
```

### Architecture Responsibilities

**Controllers**

Handle incoming HTTP requests and return appropriate HTTP responses.

**Services**

Contain application logic and coordinate operations between controllers and repositories.

**Repositories**

Handle database access and execute queries against PostgreSQL.

**Models**

Define the data structures used by the application.

**Data**

Contains database setup and connection-related components.

## Request Flow

The application follows a simple layered request flow:

```text
           Client
              |
              v
         Controller
              |
              v
           Service
              |
              v
         Repository
              |
              v
       PostgreSQL DB
```

1. The client sends an HTTP request.
2. The controller receives the request.
3. The service handles the application logic.
4. The repository communicates with PostgreSQL.
5. The database returns the requested records.
6. The API sends the response back to the client.

## API Endpoint

### Get All Products

| Method | Endpoint | Description |
|---|---|---|
| GET | `/products` | Retrieve products from the database |

Example request:

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

The repository currently filters products to return records with a price below 2000.

## Database Setup

The application expects a PostgreSQL database with a table named `products`.

Example table definition:

```sql
CREATE TABLE products (
    id SERIAL PRIMARY KEY,
    name TEXT NOT NULL,
    price INTEGER NOT NULL
);
```

The schema can be extended with additional fields such as:

- `image`
- `description`
- `size`

These fields are optional extensions and are not required by the current example.

## Getting Started

### Prerequisites

Make sure you have the following installed:

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Git](https://git-scm.com/)

### 1. Clone the Repository

```bash
git clone https://github.com/navin20/Extra-Api.git
```

Navigate to the project directory:

```bash
cd Extra-Api
```

### 2. Configure Environment Variables

Create a `.env` file in the project root.

Example configuration:

```env
Host=your-postgres-host
Database=your-database-name
Username=your-db-username
Password=your-db-password
Port=5432
```

The application loads these environment variables through DotNetEnv in `Program.cs` and builds the PostgreSQL connection string.

Replace the example values with your own PostgreSQL connection details.

**Important:** Never commit your actual `.env` file or database credentials to a public repository.

### 3. Restore Dependencies

```bash
dotnet restore
```

### 4. Run the Application

```bash
dotnet run
```

The API listens on the ASP.NET Core development URL configured for your environment.

For example:

```text
https://localhost:5001
http://localhost:5000
```

Check the terminal output for the actual listening address.

## Development Notes

- OpenAPI support is enabled in development mode.
- Dependency Injection is used to register application services and repositories.
- Database configuration is loaded from environment variables.
- The project uses a layered architecture to separate responsibilities.
- The structure can be extended with additional CRUD operations and API functionality.

## Project Purpose

This repository is shared as an educational and reference project for developers interested in C# backend development.

It demonstrates how a basic ASP.NET Core API can be organized, how application layers interact, and how a backend application communicates with PostgreSQL.

Developers are welcome to explore the implementation, experiment with the structure, and extend it for their own learning and development.

## License

This project is provided as-is for educational and reference purposes.

Refer to the `LICENSE` file for the applicable license terms.

---

**Author:** [navin20](https://github.com/navin20)

**Repository:** [C# API – GitHub](https://github.com/navin20/Extra-Api)
