using System.ComponentModel.DataAnnotations;

namespace MvcMusicShop.Models
{
    public class Music
    {
        [Key] public string Genre { get; set; }
        public string Title { get; set; }

    }
}
