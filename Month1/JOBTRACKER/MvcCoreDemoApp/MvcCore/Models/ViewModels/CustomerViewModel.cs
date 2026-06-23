using System.ComponentModel.DataAnnotations;

namespace MvcCore.Models.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer name is required")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [StringLength(20)]
        public string? Phone { get; set; }

        // For Details view
        public int OrderCount { get; set; }
        public decimal TotalSpent { get; set; }
    }
}
