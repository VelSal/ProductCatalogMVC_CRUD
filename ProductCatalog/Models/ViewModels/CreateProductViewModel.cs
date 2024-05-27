using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Models.ViewModels
{
        [Keyless]
	public class CreateProductViewModel
	{
        [Required(ErrorMessage = "Please put a name")]
        [Display(Name = "Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please put a price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please chose a category")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public List<Category> Categories { get; set; }

    }
}
