using System.Collections.Generic;
using Playlist.Models;

namespace Playlist.Repositories
{
    public interface ISongRepo
    {
        IEnumerable<Song> Songs{get;}
        void SaveSong(Song songs);
        Song DeleteSong(int SongId);
    }
}