using System.ComponentModel.DataAnnotations;

namespace BlazorWasmAuthenticationAndAuthorization.Server.Models
{
    public partial class Book
    {
        public int BookID { get; set; }

        [Required]
        public string BookName { get; set; } = null!;

        [Required]
        public string Author { get; set; } = null!;
        [Required]
        public string BookDescribation { get; set; } = null!;

        //[Required]
        public string? Category { get; set; } 
        //[Required]

        public int CategoryID { get; set; }
        public bool? Active { get; set; }

    }
}
