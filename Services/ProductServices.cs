using NewApi.Models;
using NewApi.Repositories;
namespace NewApi.Services;


class ProductServices : IProductService
{
private readonly IProductRepository repository;
    // public ProductServices(Repositories repositories)
    // {
        
    // }
    public  ProductServices(IProductRepository repository)
    {
        this.repository = repository;
        
    }
    public async Task<List<ProductsResponse>> GetProductsAsync()
    {
        

        return await repository.GetProductsAsync();

        
    }
    // public async Task<ProductsResponse> GetProductsByIdAsync(){
        
    // }

}
