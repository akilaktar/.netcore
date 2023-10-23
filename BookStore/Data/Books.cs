using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Data
{
    public class Books
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? Language { get; set; }
        public int TotalPages { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? Address { get; set; }
        public string? FileName { get; set; }
        [NotMapped]
        public IFormFile? File { get; set; }
        public int? City { get; set; }
        public string? Gender { get; set; }

    }
}
