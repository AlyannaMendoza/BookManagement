namespace BookManagement.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<SubGenre> SubGenres { get; set; }
    }
}
