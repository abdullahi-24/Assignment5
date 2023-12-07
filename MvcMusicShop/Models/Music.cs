using System.ComponentModel.DataAnnotations;

namespace MvcMusicShop.Models
{
    public class Music
    {
        
       /* [Required(ErrorMessage = "Genre is required.")]
        [StringLength(50, ErrorMessage = "Genre cannot exceed 50 characters.")]*/
        [Key]
        public string Genre { get; set; }

/*        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]*/
        public string Title { get; set; }
/*
        [StringLength(100, ErrorMessage = "Artist cannot exceed 100 characters.")]
        public string Artist { get; set; }

        [StringLength(100, ErrorMessage = "Album cannot exceed 100 characters.")]
        public string Album { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        [DataType(DataType.Currency)]
        [Range(0, double.MaxValue, ErrorMessage = "Price should be a positive value.")]
        public decimal? Price { get; set; }
*/
       

    }
}
