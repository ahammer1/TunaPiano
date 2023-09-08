﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TunaPiano;

#nullable disable

namespace TunaPiano.Migrations
{
    [DbContext(typeof(TunaPianoDbContext))]
    partial class TunaPianoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GenreSong", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.Property<int>("SongsSongid")
                        .HasColumnType("integer");

                    b.HasKey("GenreId", "SongsSongid");

                    b.HasIndex("SongsSongid");

                    b.ToTable("GenreSong");
                });

            modelBuilder.Entity("TunaPiano.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ArtistId"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("bio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ArtistId");

                    b.ToTable("Artist");

                    b.HasData(
                        new
                        {
                            ArtistId = 103,
                            Age = 25,
                            Name = "Dolly Parton",
                            bio = "American singer song writer"
                        },
                        new
                        {
                            ArtistId = 104,
                            Age = 74,
                            Name = "Elton John",
                            bio = "British singer-songwriter and pianist"
                        },
                        new
                        {
                            ArtistId = 105,
                            Age = 39,
                            Name = "Beyoncé",
                            bio = "American singer, songwriter, and actress"
                        },
                        new
                        {
                            ArtistId = 106,
                            Age = 50,
                            Name = "Michael Jackson",
                            bio = "American singer, songwriter, and dancer"
                        },
                        new
                        {
                            ArtistId = 107,
                            Age = 33,
                            Name = "Adele",
                            bio = "British singer-songwriter"
                        },
                        new
                        {
                            ArtistId = 108,
                            Age = 36,
                            Name = "Bruno Mars",
                            bio = "American singer, songwriter, and record producer"
                        });
                });

            modelBuilder.Entity("TunaPiano.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GenreId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("GenreId");

                    b.ToTable("Genre");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            Description = "Rock"
                        },
                        new
                        {
                            GenreId = 2,
                            Description = "Pop"
                        },
                        new
                        {
                            GenreId = 3,
                            Description = "R&B"
                        },
                        new
                        {
                            GenreId = 4,
                            Description = "Hip-Hop"
                        });
                });

            modelBuilder.Entity("TunaPiano.Models.Song", b =>
                {
                    b.Property<int>("Songid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Songid"));

                    b.Property<string>("Album")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("length")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Songid");

                    b.HasIndex("ArtistId");

                    b.ToTable("Song");

                    b.HasData(
                        new
                        {
                            Songid = 3,
                            Album = "Album3",
                            ArtistId = 105,
                            Title = "Song3",
                            length = "3:55"
                        },
                        new
                        {
                            Songid = 4,
                            Album = "Album4",
                            ArtistId = 106,
                            Title = "Song4",
                            length = "4:10"
                        },
                        new
                        {
                            Songid = 5,
                            Album = "Album5",
                            ArtistId = 107,
                            Title = "Song5",
                            length = "4:30"
                        },
                        new
                        {
                            Songid = 6,
                            Album = "Album6",
                            ArtistId = 108,
                            Title = "Song6",
                            length = "3:40"
                        },
                        new
                        {
                            Songid = 7,
                            Album = "Album7",
                            ArtistId = 103,
                            Title = "Song7",
                            length = "4:00"
                        },
                        new
                        {
                            Songid = 8,
                            Album = "Album8",
                            ArtistId = 104,
                            Title = "Song8",
                            length = "3:25"
                        });
                });

            modelBuilder.Entity("GenreSong", b =>
                {
                    b.HasOne("TunaPiano.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TunaPiano.Models.Song", null)
                        .WithMany()
                        .HasForeignKey("SongsSongid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TunaPiano.Models.Song", b =>
                {
                    b.HasOne("TunaPiano.Models.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });
#pragma warning restore 612, 618
        }
    }
}
