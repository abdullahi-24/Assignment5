﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMusicShop.Data;
using MvcMusicShop.Models;

namespace MvcMusicShop.Controllers
{
    public class MusicsController : Controller
    {
        private readonly MvcMusicShopContext _context;

        public MusicsController(MvcMusicShopContext context)
        {
            _context = context;
        }

        // GET: Musics
        public async Task<IActionResult> Index(string MusicGenre, string MusicArtist)
        {
            if (_context.Music == null)
            {
                return Problem("Entity set 'MvcMusicShopContext.Music'  is null.");
            }

            IQueryable<string> genreQuery = from m in _context.Music
                                            orderby m.Genre
                                            select m.Genre;

            IQueryable<string> artistQuery = from m in _context.Music
                                             orderby m.Artist
                                             select m.Artist;

            var musics = from m in _context.Music
                         select m;

            if (!string.IsNullOrEmpty(MusicGenre))
            {
                musics = musics.Where(x => x.Genre == MusicGenre);
            }

            if (!string.IsNullOrEmpty(MusicArtist))
            {
                musics = musics.Where(x => x.Artist == MusicArtist);
            }

            var musicVM = new MusicViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Artists = new SelectList(await artistQuery.Distinct().ToListAsync()),
                Musics = await musics.ToListAsync()
            };

            return View(musicVM);
        }

        // GET: Musics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var music = await _context.Music
                .FirstOrDefaultAsync(m => m.Id == id);
            if (music == null)
            {
                return NotFound();
            }

            return View(music);
        }


        // GET: Musics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Musics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Genre,Title,Artist,ReleaseDate,Price")] Music music)
        {
            if (ModelState.IsValid)
            {
                _context.Add(music);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(music);
        }

        // GET: Musics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Music == null)
            {
                return NotFound();
            }

            var music = await _context.Music.FindAsync(id);
            if (music == null)
            {
                return NotFound();
            }
            return View(music);
        }

        // POST: Musics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Genre,Title,Artist,ReleaseDate,Price")] Music music)
        {
            if (id != music.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(music);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicExists(music.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(music);
        }

        // GET: Musics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Music == null)
            {
                return NotFound();
            }

            var music = await _context.Music
                .FirstOrDefaultAsync(m => m.Id == id);
            if (music == null)
            {
                return NotFound();
            }

            return View(music);
        }

        // POST: Musics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Music == null)
            {
                return Problem("Entity set 'MvcMusicShopContext.Music'  is null.");
            }
            var music = await _context.Music.FindAsync(id);
            if (music != null)
            {
                _context.Music.Remove(music);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusicExists(int id)
        {
          return (_context.Music?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
