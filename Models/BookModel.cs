using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagement.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }

        public int GenreId { get; set; }
        public Genre? Genre { get; set; }

        public DateTime PublishedDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
