using Playlist.Data;
using Playlist.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Playlist.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Playlist.Controllers
{
    public class SongController : Controller
    {
        private ISongRepo _repo;
        private AppDbContext _context;
        private IArtistRepo _ArtistRepo;
        private IAlbumRepo _AlbumRepo;
        private IGenreRepo _GenreRepo;

        public SongController(ISongRepo arepo, AppDbContext ctx, IArtistRepo artistRepo, IAlbumRepo albumRepo, IGenreRepo genreRepo)
        {
            _repo = arepo;
            _context = ctx;
            _ArtistRepo = artistRepo;
            _AlbumRepo = albumRepo;
            _GenreRepo = genreRepo;
        }
        
        [HttpGet]
        public ViewResult Index() => View(_context.Songs.Include(c => c.Artist)
        .Include(c => c.Album).Include(c => c.Genre));

         [HttpGet]
        public ViewResult AddSong() {
        IEnumerable<SelectListItem> artist = _ArtistRepo.Artists.Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.ArtistName
                    });
        IEnumerable<SelectListItem> album = _AlbumRepo.Albums.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.AlbumName
            });
        IEnumerable<SelectListItem> genre = _GenreRepo.Genres.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.GenreName
            });
        ViewBag.Artists = artist;
        ViewBag.Albums = album;
        ViewBag.Genres = genre;

         return View(new Song());
        }
        [HttpPost]
        public IActionResult AddSong(Song song){
            var album_name = _context.Albums.FirstOrDefault(c => c.Id == song.Album.Id).AlbumName;
            var artist_name = _context.Artists.FirstOrDefault(c => c.Id == song.Artist.Id).ArtistName;
            var genre_name = _context.Genres.FirstOrDefault(c => c.Id == song.Genre.Id).GenreName;

            song.AlbumId = song.Album.Id;
            song.ArtistId = song.Artist.Id;
            song.GenreId = song.Genre.Id;
            song.Album.AlbumName = album_name;
            song.Artist.ArtistName = artist_name;
            song.Genre.GenreName = genre_name;
            
            if (song!=null){
                _repo.SaveSong(song);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult DeleteSong(int Id){
            _repo.DeleteSong(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}