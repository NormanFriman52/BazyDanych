using System.Collections.Generic;
using System.Linq;
using Playlist.Data;
using Playlist.Models;

namespace Playlist.Repositories
{
    public class SongRepo : ISongRepo
    {
        private AppDbContext _context;

        public SongRepo(AppDbContext ctx)
        {
            _context = ctx;
        }
        public IEnumerable<Song> Songs => _context.Songs;

        public Song DeleteSong(int SongId)
        {

            var song = _context.Songs.FirstOrDefault(c => c.Id == SongId);
            if(song != null){
                _context.Songs.Remove(song);
            }
            _context.SaveChanges();
            return song;
        }

        public void SaveSong(Song song)
        {
            if (song.Id == 0)
            {
                _context.Songs.Add(song);

            }
            else
            {
                Song newModel = _context.Songs.FirstOrDefault(c => c.Id == song.Id);

                if (newModel != null)
                {
                    newModel.Title = song.Title; 
                    newModel.ArtistId = song.ArtistId;
                    newModel.Artist = song.Artist;
                    newModel.AlbumId = song.AlbumId;
                    newModel.Album = song.Album;
                    newModel.GenreId = song.GenreId;
                    newModel.Genre = song.Genre;
                }
            }
            _context.SaveChanges();
        }
    }
}