namespace BookManagement.Models
{
    public class SubGenre
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
}
