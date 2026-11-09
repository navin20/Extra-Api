using NewApi.Models;


namespace NewApi.Repositories;

public interface IProductService
{
     Task<List<ProductsResponse>> GetProductsAsync();
     // Task<ProductsResponse> GetProductsByIdAsync(); 

}