using Playlist.Data;
using Playlist.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Playlist.Models;

namespace Playlist.Controllers
{
    public class GenreController : Controller
    {
        private IGenreRepo _repo;
        private AppDbContext _context;

        public GenreController(IGenreRepo arepo, AppDbContext ctx)
        {
            _repo = arepo;
            _context = ctx;

        }
        [HttpGet]
        public ViewResult Index() => View(_repo.Genres);
        [HttpGet]
        public ViewResult AddGenre() => View(new Genre());
        [HttpPost]
        public IActionResult AddGenre(Genre genre){
            if (genre!=null){
                _repo.SaveGenre(genre);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult DeleteGenre(int Id){
            _repo.DeleteGenre(Id);
            return RedirectToAction(nameof(Index));
        }

    }
}