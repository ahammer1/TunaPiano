namespace TunaPiano.Models
{
    public class Song
    {
        public int Songid { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public string Album { get; set; }

        public string length { get; set; }

        public List<Genre> Genre { get; set; }
    }
}
