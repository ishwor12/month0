using Library_Book_Management_API.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Library_Book_Management_API.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string? Title { get; set; }

        [Required, StringLength(100)]
        public string? Author { get; set; }

        [Required, StringLength(13,MinimumLength=5)]
        public string? ISBN { get; set; }
        
        public bool IsAvailable { get; set; } = true;

        public DateTime? AddedDate { get; set; } 
        
        public Genre Genre { get; set; }


    }
}
