using Microsoft.EntityFrameworkCore;
using TunaPiano.Models;

namespace TunaPiano
{
    public class TunaPianoDbContext : DbContext
    {
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Song> Song { get; set; }
        public DbSet<Genre> Genre { get; set; }

        public TunaPianoDbContext(DbContextOptions<TunaPianoDbContext> context) : base(context)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Artist>().HasData(new Artist[]
            {
                new Artist{ArtistId = 103, Age = 25, Name = "Dolly Parton", bio = "American singer song writer" },
                new Artist{ArtistId = 104, Name = "Elton John", Age = 74, bio = "British singer-songwriter and pianist"},
                new Artist{ArtistId = 105, Name = "Beyoncé", Age = 39, bio = "American singer, songwriter, and actress"},
                new Artist{ArtistId = 106, Name = "Michael Jackson", Age = 50, bio = "American singer, songwriter, and dancer"},
                new Artist{ArtistId = 107, Name = "Adele", Age = 33, bio = "British singer-songwriter"},
                new Artist{ArtistId = 108,Name = "Bruno Mars", Age = 36, bio = "American singer, songwriter, and record producer"}

            });

            modelBuilder.Entity<Song>().HasData(new Song[]
                {
                    new Song { Songid = 3, Title = "Song3", ArtistId = 105, Album = "Album3", length = "3:55" },
                    new Song { Songid = 4, Title = "Song4", ArtistId = 106, Album = "Album4", length = "4:10"},
                    new Song { Songid = 5, Title = "Song5", ArtistId = 107, Album = "Album5", length = "4:30" },
                    new Song { Songid = 6, Title = "Song6", ArtistId = 108, Album = "Album6", length = "3:40"},
                    new Song { Songid = 7, Title = "Song7", ArtistId = 103, Album = "Album7", length = "4:00"},
                    new Song { Songid = 8, Title = "Song8", ArtistId = 104, Album = "Album8", length = "3:25" },


        });
            modelBuilder.Entity<Genre>().HasData(new Genre[]
               {
                   new Genre { GenreId = 1, Description = "Rock" },
                   new Genre { GenreId = 2, Description = "Pop" },
                    new Genre { GenreId = 3, Description = "R&B" },
                    new Genre { GenreId = 4, Description = "Hip-Hop" },
               });

///*            var GenreSong = modelBuilder.Entity("GenreSong");
//              GenreSong.HasData(new[] {
//            new { GenreId = 1, Songid = 4 },
//            new { GenreId = 2, Songid = 6 },
//           new { GenreId = 3, Songid = 5 },
//             new { GenreId = 4, Songid = 7 } 
//              }
//  );
//*/
        }



    }
    }

