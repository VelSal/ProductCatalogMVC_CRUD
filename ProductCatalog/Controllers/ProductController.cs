using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models;
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
        {
            var categories = await _context.Categories.ToListAsync();
            var viewModel = new CreateProductViewModel
            {
                Categories = categories
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = await _context.Categories.ToListAsync();
                return View(viewModel);
            }
            var newProduct = new Product
            {
                Name = viewModel.ProductName,
                Price = viewModel.Price,
                CategoryId = viewModel.CategoryId
            };
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
