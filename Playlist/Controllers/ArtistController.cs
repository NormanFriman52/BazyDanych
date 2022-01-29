using Playlist.Data;
using Playlist.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Playlist.Models;

namespace Playlist.Controllers
{
    public class ArtistController : Controller
    {
        private IArtistRepo _repo;
        private AppDbContext _context;

        public ArtistController(IArtistRepo arepo, AppDbContext ctx)
        {
            _repo = arepo;
            _context = ctx;

        }
        [HttpGet]
        public ViewResult Index() => View(_repo.Artists);
        [HttpGet]
        public ViewResult AddArtist() => View(new Artist());
        [HttpPost]
        public IActionResult AddArtist(Artist artist){
            if (artist!=null){
                _repo.SaveArtist(artist);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult DeleteArtist(int Id){
            _repo.DeleteArtist(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}