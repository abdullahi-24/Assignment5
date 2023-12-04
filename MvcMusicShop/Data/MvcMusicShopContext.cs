using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMusicShop.Models;

namespace MvcMusicShop.Data
{
    public class MvcMusicShopContext : DbContext
    {
        public MvcMusicShopContext (DbContextOptions<MvcMusicShopContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMusicShop.Models.Music> Music { get; set; } = default!;
    }
}
