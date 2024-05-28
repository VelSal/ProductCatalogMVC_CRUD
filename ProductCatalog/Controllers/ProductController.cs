using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
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
            if (!ModelState.IsValid && ModelState == null)
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

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(b => b.Category)
                .FirstOrDefaultAsync(b => b.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _context.Products
                .Include(b => b.Category)
                .FirstOrDefaultAsync(b => b.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _context.Products
                .Include(b => b.Category)
                .FirstOrDefaultAsync(b => b.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            var categories = await _context.Categories.ToListAsync();
            var viewModel = new EditProductViewModel
            {
                ProductId = product.ProductId,
                ProductName = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
                Categories = categories,
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditProductViewModel viewModel)
        {
            if (!ModelState.IsValid && ModelState == null)
            {
                viewModel.Categories = await _context.Categories.ToListAsync();
                return View(viewModel);
            }
            var product = await _context.Products.FindAsync(viewModel.ProductId);
            if (product == null)
            {
                return NotFound();
            }

            product.ProductId = viewModel.ProductId;
            product.Name = viewModel.ProductName;
            product.Price = viewModel.Price;
            product.CategoryId = viewModel.CategoryId;

            _context.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
