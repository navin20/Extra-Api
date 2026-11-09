using NewApi.Models;

namespace NewApi.Repositories;

public interface IProductRepository
{
    
    Task<List<ProductsResponse>> GetProductsAsync();
    Task<Products> createProductsAsync(Products products);
}