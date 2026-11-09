namespace NewApi.Models;

public class Products
{

    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string image { get; set; } = "";
    public int Price { get; set; } = 0;
    public string Description { get; set; } = "";
    public int Size { get; set; } = 0;
}
public class ProductsResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Price { get; set; }


}


