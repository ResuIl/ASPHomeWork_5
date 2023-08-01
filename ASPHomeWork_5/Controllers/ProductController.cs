using ASPHomeWork_5.Entities;
using ASPHomeWork_5.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPHomeWork_5.Controllers;

public class ProductController : Controller
{
    private ProductViewModel? ProductVM;

    private static List<Product> products = new List<Product>()
    {
        new Product()
        {
            Name = "Potato",
            Price = 1.2M,
            Count = 40,
            Description = "Made in Gadabay"
        },
        new Product()
        {
            Name = "Tomato",
            Price = 1.5M,
            Count = 50,
            Description = "Made in Zira"
        },
        new Product()
        {
            Name = "Cucumber",
            Price = 1.2M,
            Count = 20,
            Description = "Made in Ganja"
        },
    };

    public ProductController()
    {
        ProductVM = new ProductViewModel()
        {
            Products = products
        };
    }

    public IActionResult Get()
    {
        return View(ProductVM);
    }
    public IActionResult Delete(int id)
    {
        products.Remove(products.First(x => x.Id == id));
        return RedirectToAction("Get");
    }
    public IActionResult Add()
    {
        return View(ProductVM);
    }

    [HttpPost]
    public IActionResult Add(ProductViewModel ProductVM)
    {
        if (ModelState.IsValid)
        {
            products.Add(ProductVM.Product!);
            return RedirectToAction("Get");
        }
        return View();
    }

    public IActionResult SearchView(ProductViewModel ProductVM)
    {
        ProductVM.Products = products.Where(x => x.Name!.ToLower() == ProductVM.Search.ToLower()).ToList();
        return View(ProductVM);
    }

    [HttpPost]
    public IActionResult Search(ProductViewModel ProductVM)
    {
        if (ProductVM.Search != null && ProductVM.Search != string.Empty)
            return RedirectToAction("SearchView", ProductVM);
        return RedirectToAction("get");
    }

}
