using System.ComponentModel.DataAnnotations;

namespace MvcCore.Models.ViewModels
{
    public class SupplierViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Supplier name is required")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(100)]
        [Display(Name = "Contact Name")]
        public string? ContactName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(100)]
        public string? Email { get; set; }

        // For Details view
        public int ProductCount { get; set; }
        public IEnumerable<string> ProductNames { get; set; } = new List<string>();

    }
}
