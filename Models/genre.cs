namespace TunaPiano.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Description { get; set; }
        public List<Song> Song { get; set; }

    }
}
