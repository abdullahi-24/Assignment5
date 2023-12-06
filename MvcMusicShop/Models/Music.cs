﻿using System.ComponentModel.DataAnnotations;

namespace MvcMusicShop.Models
{
    public class Music
    {
        [Key] public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        
        public decimal Price { get; set; }

    }
}
