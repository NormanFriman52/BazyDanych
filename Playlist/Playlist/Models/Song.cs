namespace Playlist.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int AlbumId  { get; set; }
        public Album Album { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}