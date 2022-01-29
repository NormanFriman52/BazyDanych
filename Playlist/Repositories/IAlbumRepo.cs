using System.Collections.Generic;
using Playlist.Models;

namespace Playlist.Repositories
{
    public interface IAlbumRepo
    {
        IEnumerable<Album> Albums{get;}
        void SaveAlbum(Album albums);
        Album DeleteAlbum(int AlbumId);
    }
}