using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcMusicShop.Models
{
    public class MusicViewModel
    {
        public List<Music> Musics { get; set; }
        public SelectList? Genres { get; set; }
        public string? MusicGenre { get; set; }
        public SelectList? Artists { get; set; }
        public string? MusicArtist { get; set; }
    }
}
