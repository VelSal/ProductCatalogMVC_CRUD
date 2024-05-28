using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Models.ViewModels
{
    public class EditProductViewModel
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Please put a name")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Please put a price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please chose a category")]
        public int CategoryId { get; set; }
        public List<Category> Categories { get; set; }
    }
}
