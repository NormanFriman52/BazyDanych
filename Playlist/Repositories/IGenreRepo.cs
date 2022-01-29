using System.Collections.Generic;
using Playlist.Models;

namespace Playlist.Repositories
{
    public interface IGenreRepo
    {
        IEnumerable<Genre> Genres{get;}
        void SaveGenre(Genre Genres);
        Genre DeleteGenre(int GenreId);
    }
}