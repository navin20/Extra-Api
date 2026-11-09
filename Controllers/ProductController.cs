using Microsoft.AspNetCore.Mvc;
using NewApi.Models;
using NewApi.Repositories;
using NewApi.Services;


namespace NewApi.Controllers;

[ApiController]
[Route("products")]
public class ProductController : ControllerBase
{
    private readonly IProductService service;

    public ProductController(IProductService productService)
    {
        this.service = productService;
    }
[HttpGet]
    public async Task<IActionResult> GetProducts()
    {

        try{
        var products = await service.GetProductsAsync();
        return Ok(products);
    }catch(Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500,"Internal server error");
        }
    }


}