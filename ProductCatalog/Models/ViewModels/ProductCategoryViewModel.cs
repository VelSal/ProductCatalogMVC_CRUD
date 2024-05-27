using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Models.ViewModels
{
    public class ProductCategoryViewModel
    {
        [Key]
        [Display(Name = "ID")]
        public int ProductId { get; set; }

        [Display(Name = "Name")]
        public string ProductName { get; set; }

        [Display(Name = "Price")]
        public decimal ProductPrice { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

    }
}
