using ASPHomeWork_5.Entities;
namespace ASPHomeWork_5.Models;

public class ProductViewModel
{
    public List<Product>? Products { get; set; }
    public Product? Product { get; set; }
    public string Search { get; set; }
}
