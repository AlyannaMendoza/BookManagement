namespace BOOK_MANAGEMENT_SYSTEM.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<SubGenre> SubGenres { get; set; }
    }
}
