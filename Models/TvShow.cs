namespace TVShowCatalog.Models
{
    public class TvShow
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Showrunner { get; set; }
        public string? Genre { get; set; }
        public DateOnly Premiere { get; set; }
        public string? Poster { get; set; }
        public string? Description { get; set; }
    }
}
