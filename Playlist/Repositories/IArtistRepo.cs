using System.Collections.Generic;
using Playlist.Models;

namespace Playlist.Repositories
{
    public interface IArtistRepo
    {
        IEnumerable<Artist> Artists{get;}
        void SaveArtist(Artist Artists);
        Artist DeleteArtist(int ArtistId);
    }
}