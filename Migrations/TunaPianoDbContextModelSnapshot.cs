﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                    b.Property<int>("GenresId")
                        .HasColumnType("integer");

                    b.Property<int>("SongsId")
                        .HasColumnType("integer");

                    b.HasKey("GenresId", "SongsId");

                    b.HasIndex("SongsId");

                    b.ToTable("GenreSong");
                });

            modelBuilder.Entity("TunaPiano.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 28,
                            Bio = "Staring ContestFollowing the 1995 dissolution of the quirky art-pop band Heavy Vegetable, guitarist/singer/songwriter Rob Crow and lead singer Eléa Tenuta regrouped in Thingy, which turned into one of the restless and prolific Crow's main creative outlets",
                            Name = "Thingy"
                        },
                        new
                        {
                            Id = 2,
                            Age = 5,
                            Bio = "Purple Mountains was an American indie rock project formed by musician and poet David Berman. The project debuted in May 2019, over a decade after the dissolution of Berman's previous group Silver Jews. An eponymous album was released in July 2019.",
                            Name = "Purple Mountains"
                        },
                        new
                        {
                            Id = 3,
                            Age = 15,
                            Bio = "It's a long story",
                            Name = "Ovlov"
                        },
                        new
                        {
                            Id = 4,
                            Age = 20,
                            Bio = "Tera Melos is an American math rock band from Sacramento, California, formed in 2004. They incorporate many styles of rock, ambient electronics and unconventional song structures.",
                            Name = "Tera Melos"
                        });
                });

            modelBuilder.Entity("TunaPiano.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Math Rock"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Americana"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Alternative Rock"
                        });
                });

            modelBuilder.Entity("TunaPiano.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Album")
                        .HasColumnType("text");

                    b.Property<int>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<string>("Length")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId")
                        .IsUnique();

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Album = "Morbid Curiosity",
                            ArtistId = 1,
                            Length = "1:11 minutes",
                            Title = "Enderbachie"
                        },
                        new
                        {
                            Id = 2,
                            Album = "Morbid Curiosity",
                            ArtistId = 1,
                            Length = "1:19 minutes",
                            Title = "San Diego Rock Song About People Talking In The Movie Theatre"
                        },
                        new
                        {
                            Id = 3,
                            Album = "Purple Mountains",
                            ArtistId = 2,
                            Length = "4:11 minutes",
                            Title = "She's Making Friends, I'm Turning Stranger"
                        },
                        new
                        {
                            Id = 4,
                            Album = "Purple Mountains",
                            ArtistId = 2,
                            Length = "6:08 minutes",
                            Title = "Nights That Wont Happen"
                        },
                        new
                        {
                            Id = 5,
                            Album = "Buds",
                            ArtistId = 3,
                            Length = "2:50 minutes",
                            Title = "Land Of Steve-O"
                        },
                        new
                        {
                            Id = 6,
                            Album = "Buds",
                            ArtistId = 3,
                            Length = " 4:48 minutes",
                            Title = "Feel The Pain"
                        },
                        new
                        {
                            Id = 7,
                            Album = "TRU",
                            ArtistId = 3,
                            Length = "2:00 minutes",
                            Title = "Short Morgan"
                        },
                        new
                        {
                            Id = 8,
                            Album = "X'ed Out",
                            ArtistId = 4,
                            Length = "3:05 minutes",
                            Title = "Weird Circles"
                        });
                });

            modelBuilder.Entity("GenreSong", b =>
                {
                    b.HasOne("TunaPiano.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TunaPiano.Models.Song", null)
                        .WithMany()
                        .HasForeignKey("SongsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TunaPiano.Models.Song", b =>
                {
                    b.HasOne("TunaPiano.Models.Artist", "Artist")
                        .WithOne("Songs")
                        .HasForeignKey("TunaPiano.Models.Song", "ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("TunaPiano.Models.Artist", b =>
                {
                    b.Navigation("Songs");
                });
#pragma warning restore 612, 618
        }
    }
}
