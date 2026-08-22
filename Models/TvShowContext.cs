using Microsoft.EntityFrameworkCore;

namespace TVShowCatalog.Models
{
    public class TvShowContext : DbContext
    {
        public DbSet<TvShow> TvShows { get; set; }

        public TvShowContext(DbContextOptions<TvShowContext> options) : base(options) 
        {
            if(Database.EnsureCreated())
            {
                TvShows?.AddRange(
                    new TvShow { 
                        Title = "Game of Thrones", 
                        Showrunner = "David Benioff and D.B. Weiss", 
                        Genre = "Epic Fantasy, Dark Fantasy, Drama",
                        Premiere = new DateOnly(2011, 04, 17),
                        Poster = "/images/got.jpg",
                        Description = "Game of Thrones is a dark fantasy television series about noble families fighting for control of the Iron Throne and the Seven Kingdoms of Westeros"
                    },
                    new TvShow
                    {
                        Title = "Breaking Bad",
                        Showrunner = "Vince Gilligan",
                        Genre = "Crime Drama, Psychological Thriller",
                        Premiere = new DateOnly(2008, 1, 20),
                        Poster = "/images/breaking_bad.jpg",
                        Description = "A chemistry teacher diagnosed with inoperable lung cancer turns to manufacturing and selling methamphetamine with a former student to secure his family's future."
                    },
                    new TvShow
                    {
                        Title = "Better Call Saul",
                        Showrunner = "Vince Gilligan and Peter Gould",
                        Genre = "Legal Drama, Crime Drama",
                        Premiere = new DateOnly(2015, 2, 8),
                        Poster = "/images/better_call_saul.jpg",
                        Description = "The trials and tribulations of criminal lawyer Jimmy McGill in the time leading up to his fateful run-in with Walter White and Jesse Pinkman."
                    },
                    new TvShow
                    {
                        Title = "Lost",
                        Showrunner = "Damon Lindelof and Carlton Cuse",
                        Genre = "Sci-Fi, Mystery, Adventure",
                        Premiere = new DateOnly(2004, 9, 22),
                        Poster = "/images/lost.jpg",
                        Description = "The survivors of a plane crash on a mysterious island in the South Pacific must work together to stay alive while facing unexplained supernatural phenomena."
                    },
                    new TvShow
                    {
                        Title = "Dexter",
                        Showrunner = "Clyde Phillips",
                        Genre = "Crime Drama, Mystery, Psychological Thriller",
                        Premiere = new DateOnly(2006, 10, 1),
                        Poster = "/images/dexter.jpg",
                        Description = "A forensic technician specializing in bloodstain pattern analysis for the Miami Metro Police Department leads a secret parallel life as a vigilante serial killer."
                    },
                    new TvShow
                    {
                        Title = "House, M.D.",
                        Showrunner = "David Shore",
                        Genre = "Medical Drama, Mystery",
                        Premiere = new DateOnly(2004, 11, 16),
                        Poster = "/images/house.jpg",
                        Description = "An antisocial, painkiller-addicted medical genius leads a team of diagnosticians at the fictional Princeton-Plainsboro Teaching Hospital in New Jersey."
                    },
                    new TvShow
                    {
                        Title = "The Sopranos",
                        Showrunner = "David Chase",
                        Genre = "Crime Drama",
                        Premiere = new DateOnly(1999, 1, 10),
                        Poster = "/images/sopranos.jpg",
                        Description = "New Jersey mob boss Tony Soprano deals with personal and professional issues in his home and business life that affect his mental state, leading him to seek professional psychiatric counseling."
                    },
                    new TvShow
                    {
                        Title = "Friends",
                        Showrunner = "David Crane and Marta Kauffman",
                        Genre = "Sitcom, Comedy, Romance",
                        Premiere = new DateOnly(1994, 9, 22),
                        Poster = "/images/friends.jpg",
                        Description = "Follows the personal and professional lives of six twenty to thirty-something friends living in the Manhattan borough of New York City."
                    },
                    new TvShow
                    {
                        Title = "The Boys",
                        Showrunner = "Eric Kripke",
                        Genre = "Superhero, Black Comedy, Action",
                        Premiere = new DateOnly(2019, 7, 26),
                        Poster = "/images/the_boys.jpg",
                        Description = "A group of vigilantes set out to take down corrupt superheroes who abuse their superpowers and the corporate entity that manages them."
                    },
                    new TvShow
                    {
                        Title = "Peaky Blinders",
                        Showrunner = "Steven Knight",
                        Genre = "Historical Drama, Crime Fiction",
                        Premiere = new DateOnly(2013, 9, 12),
                        Poster = "/images/peaky_blinders.jpg",
                        Description = "A gangster family epic set in England in 1919 and centered on a gang who sew razor blades in the peaks of their caps, and their fierce boss Tommy Shelby."
                    },
                    new TvShow
                    {
                        Title = "True Detective",
                        Showrunner = "Nic Pizzolatto",
                        Genre = "Crime, Drama, Mystery",
                        Premiere = new DateOnly(2014, 1, 12),
                        Poster = "/images/true_detective.jpg",
                        Description = "Seasonal anthology series in which police investigations unearth the personal and professional secrets of those involved, both within and outside the law."
                    },
                    new TvShow
                    {
                        Title = "The Wire",
                        Showrunner = "David Simon",
                        Genre = "Crime, Drama, Thriller",
                        Premiere = new DateOnly(2002, 6, 2),
                        Poster = "/images/the_wire.jpg",
                        Description = "The Baltimore drug scene is seen through the eyes of drug dealers and law enforcement, exploring the systemic issues of the city's institutions."
                    }
                );

                SaveChanges();
            }
        }
    }
}
