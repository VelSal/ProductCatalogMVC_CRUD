using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models.ViewModels;

namespace ProductCatalog.Controllers
{
    public class ProductController : Controller
    {
        readonly ProductContext _context;
        public ProductController(ProductContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var productCategoryViewModel = _context.Products
                .Include(x => x.Category)
                .Select(x => new ProductCategoryViewModel
                {
                    ProductId = x.ProductId,
                    ProductName = x.Name,
                    ProductPrice = x.Price,
                    CategoryName = x.Category.Name,
                });
            return View(productCategoryViewModel);
        }

        public async Task<IActionResult> Create() 
    }
}
