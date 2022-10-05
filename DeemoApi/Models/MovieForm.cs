using System.ComponentModel.DataAnnotations;

namespace DeemoApi.Models
{
    public class MovieForm
    {
        [Required(ErrorMessage = "Mets un titre zebi")]
        public string Title { get; set; } 
        public string Synopsis { get; set; }

        [Range(1950, 2050)]
        public int ReleaseYear { get; set; }

        public int PEGI { get; set; }

    }
}
