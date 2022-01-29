using System.Collections.Generic;
using System.Linq;
using Playlist.Data;
using Playlist.Models;

namespace Playlist.Repositories
{
    public class ArtistRepo : IArtistRepo
    {
        private AppDbContext _context;

        public ArtistRepo(AppDbContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<Artist> Artists => _context.Artists;

        public Artist DeleteArtist(int ArtistId)
        {

            var artist = _context.Artists.FirstOrDefault(c => c.Id == ArtistId);
            if(artist != null){
                _context.Artists.Remove(artist);
            }
            _context.SaveChanges();
            return artist;
        }

        public void SaveArtist(Artist artist)
        {
            if (artist.Id == 0)
            {
                _context.Artists.Add(artist);

            }
            else
            {
                Artist newModel = _context.Artists.FirstOrDefault(c => c.Id == artist.Id);

                if (newModel != null)
                {
                    newModel.ArtistName = artist.ArtistName; 
                }
            }
            _context.SaveChanges();
        }
    }
}