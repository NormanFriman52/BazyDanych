using Playlist.Data;
using Playlist.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Playlist.Models;

namespace Playlist.Controllers
{
    public class AlbumController : Controller
    {
        private IAlbumRepo _repo;
        private AppDbContext _context;

        public AlbumController(IAlbumRepo arepo, AppDbContext ctx)
        {
            _repo = arepo;
            _context = ctx;

        }
        [HttpGet]
        public ViewResult Index() => View(_repo.Albums);
        [HttpGet]
        public ViewResult AddAlbum() => View(new Album());
        [HttpPost]
        public IActionResult AddAlbum(Album album){
            if (album!=null){
                _repo.SaveAlbum(album);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult DeleteAlbum(int Id){
            _repo.DeleteAlbum(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}