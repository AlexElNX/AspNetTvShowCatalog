using System.ComponentModel.DataAnnotations;
using TVShowCatalog.ValidationAttributes;

namespace TVShowCatalog.Models
{
    public class TvShow
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 100 characters")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Showrunner / Creator is required")]
        [StringLength(60, ErrorMessage = "Showrunner name is too long")]
        public string? Showrunner { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        public string? Genre { get; set; }

        [Required(ErrorMessage = "Premiere date is required")]
        [PastOrPresentDate(ErrorMessage = "Premiere date cannot be in the future or earlier than 1946")]

        public DateOnly Premiere { get; set; }
        public string? Poster { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "Description must be at least 10 characters long")]
        public string? Description { get; set; }
    }
}
