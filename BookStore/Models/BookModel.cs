using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Author { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Category { get; set; }
        [Required]
        public string? Language { get; set; }
        [Required]
        public int TotalPages { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public DateTime? CreatedOn { get; set; }
        [Required]
        public DateTime? UpdatedOn { get; set; }
        [Required]
        public string? FileName { get; set; }
        [Required]

        [NotMapped]
        public  IFormFile? File { get; set; }
        public int? City { get; set; }
        public string? Gender { get; set; }
    }
}
