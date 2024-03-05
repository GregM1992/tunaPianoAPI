using Microsoft.EntityFrameworkCore;
using TunaPiano.Models;

public class TunaPianoDbContext : DbContext
{
    public DbSet<Song> Songs { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Artist> Artists { get; set; }
  

    public TunaPianoDbContext(DbContextOptions<TunaPianoDbContext> context) : base(context)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Song>().HasData(new Song[]
        {
          new Song { Id = 1, Title = "Enderbachie", ArtistId = 1, Album = "Morbid Curiosity", Length = "1:11 minutes" },
          new Song { Id = 2, Title = "San Diego Rock Song About People Talking In The Movie Theatre", ArtistId = 1, Album = "Morbid Curiosity", Length = "1:19 minutes"},
          new Song { Id = 3, Title = "She's Making Friends, I'm Turning Stranger", ArtistId = 2, Album = "Purple Mountains", Length = "4:11 minutes"},
          new Song { Id = 4, Title = "Nights That Wont Happen", ArtistId = 2, Album = "Purple Mountains", Length = "6:08 minutes"},
          new Song { Id = 5, Title = "Land Of Steve-O", ArtistId = 3, Album = "Buds", Length = "2:50 minutes" },
          new Song { Id = 6, Title = "Feel The Pain", ArtistId = 3, Album = "Buds", Length = " 4:48 minutes"},
          new Song { Id = 7, Title = "Short Morgan", ArtistId = 3, Album = "TRU", Length = "2:00 minutes" },
          new Song { Id = 8, Title = "Weird Circles", ArtistId = 4, Album = "X'ed Out", Length = "3:05 minutes"}


        });
        modelBuilder.Entity<Artist>().HasData(new Artist[]
        {
            new Artist { Id = 1, Name = "Thingy", Age = 28, Bio = "Staring ContestFollowing the 1995 dissolution of the quirky art-pop band Heavy Vegetable, guitarist/singer/songwriter Rob Crow and lead singer Eléa Tenuta regrouped in Thingy, which turned into one of the restless and prolific Crow's main creative outlets"},
            new Artist { Id = 2, Name = "Purple Mountains", Age = 5, Bio = "Purple Mountains was an American indie rock project formed by musician and poet David Berman. The project debuted in May 2019, over a decade after the dissolution of Berman's previous group Silver Jews. An eponymous album was released in July 2019." },
            new Artist { Id = 3, Name = "Ovlov", Age = 15, Bio = "It's a long story" },
            new Artist { Id = 4, Name = "Tera Melos", Age = 20, Bio = "Tera Melos is an American math rock band from Sacramento, California, formed in 2004. They incorporate many styles of rock, ambient electronics and unconventional song structures."}

       
        });
        modelBuilder.Entity<Genre>().HasData(new Genre[]
        {
            new Genre { Id = 1, Description = "Math Rock"},
            new Genre { Id = 2, Description = "Americana"},
            new Genre { Id = 3, Description = "Alternative Rock"}
        });
       
    }
}
