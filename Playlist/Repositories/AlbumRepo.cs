using System.Collections.Generic;
using System.Linq;
using Playlist.Data;
using Playlist.Models;

namespace Playlist.Repositories
{
    public class AlbumRepo : IAlbumRepo
    {
        private AppDbContext _context;

        public AlbumRepo(AppDbContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<Album> Albums => _context.Albums;

        public Album DeleteAlbum(int AlbumId)
        {

            var album = _context.Albums.FirstOrDefault(c => c.Id == AlbumId);
            if(album != null){
                _context.Albums.Remove(album);
            }
            _context.SaveChanges();
            return album;
        }

        public void SaveAlbum(Album album)
        {
            if (album.Id == 0)
            {
                _context.Albums.Add(album);

            }
            else
            {
                Album newModel = _context.Albums.FirstOrDefault(c => c.Id == album.Id);

                if (newModel != null)
                {
                    newModel.AlbumName = album.AlbumName; 
                }
            }
            _context.SaveChanges();
        }
    }
}