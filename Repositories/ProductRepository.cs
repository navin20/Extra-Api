using System.Data.Common;
using System.Reflection;
using NewApi.Models;
using Npgsql;

namespace NewApi.Repositories;

public class ProductRepository : IProductRepository
{

private readonly NpgsqlDataSource _dataSource;
    public ProductRepository(NpgsqlDataSource dataSource)
    {
        this._dataSource = dataSource;
    }
    // private readonly string connectionString;
    // public ProductRepository()
    // {
    //     connectionString =
    //         Environment.GetEnvironmentVariable("DATABASE_URL")!;
    // }


// public async Task<> createProductsAsync()
//     {
        
//     }

public async Task<ProductsResponse> GetUpdateAsync()
    {
        return new ProductsResponse();
        
    }
    public async Task<ProductsResponse> GetDeleteAsync()
    {
        return new ProductsResponse();
        
    }
    public async Task<List<ProductsResponse>> GetProductsAsync()




    {
        await using var command = _dataSource.CreateCommand("SELECT id, name, price FROM products");
        await using var reader = await command.ExecuteReaderAsync();
        var products = new List<ProductsResponse>();

    // while(await reader.ReadAsync() )
    //     {
        
        
           

            while (await reader.ReadAsync())
            {
                products.Add( new ProductsResponse
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Price = reader.GetInt32(2)
                });
            }

    
        // }
        return products.Where((p)=>p.Price<2000).ToList();

        // var products = new List<Products>();
        // await using var connection =
        //     new NpgsqlConnection(connectionString);

        // await connection.OpenAsync();
        //  await using var command  =  new NpgsqlCommand("Select id,name,price from products order by id");
        //  await using var reader = await command.ExecuteReaderAsync();
        //  while(await reader.ReadAsync())
        // {
        //     products.Add( new Products
        //     {
        //         Id =reader.GetInt32(0),
        //         Name=reader.GetString(1), 
        //         Price =reader.GetInt32(2)
                
        //     });
          
            
        // }
    
// var products = new List<Products>

//          {
//         new Products { Id = 1, Name = "Nike Shoes", Price = 120 },
//         new Products { Id = 2, Name = "Adidas Shirt", Price = 80 },
//         new Products { Id = 3, Name = "Puma Jacket", Price = 150 },
//         new Products { Id = 4, Name = "Reebok Shoes", Price = 150 }
//     };


//         return products;

        //  while 

        // return Task.FromResult(new List<Products>());
      
       
    }

    public async Task <Products> createProductsAsync(Products product){
        await using var command = _dataSource.CreateCommand( 
        """ 
        INSERT into products (name,price) 
        VALUES ($1,$2)
         RETURNING id,name,price;
        """);
        await using var reader = await command.ExecuteReaderAsync();
        command.Parameters.AddWithValue(product.Name);
        command.Parameters.AddWithValue(product.Price);
        while(await reader.ReadAsync())
        {
            return new Products
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Price = reader.GetInt32(2)
            };
            
        }
        throw new InvalidOperationException("Failed to create product.");




    }
}