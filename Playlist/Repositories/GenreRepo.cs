using System.Collections.Generic;
using System.Linq;
using Playlist.Data;
using Playlist.Models;

namespace Playlist.Repositories
{
    public class GenreRepo : IGenreRepo
    {
        private AppDbContext _context;

        public GenreRepo(AppDbContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<Genre> Genres => _context.Genres;

        public Genre DeleteGenre(int GenreId)
        {

            var genre = _context.Genres.FirstOrDefault(c => c.Id == GenreId);
            if(genre != null){
                _context.Genres.Remove(genre);
            }
            _context.SaveChanges();
            return genre;
        }

        public void SaveGenre(Genre genre)
        {
            if (genre.Id == 0)
            {
                _context.Genres.Add(genre);

            }
            else
            {
                Genre newModel = _context.Genres.FirstOrDefault(c => c.Id == genre.Id);

                if (newModel != null)
                {
                    newModel.GenreName = genre.GenreName; 
                }
            }
            _context.SaveChanges();
        }
    }
}