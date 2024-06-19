using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BOOK_MANAGEMENT_SYSTEM.Models;
using Microsoft.AspNetCore.Identity;

namespace BOOK_MANAGEMENT_SYSTEM.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().ToTable("Genres");
            modelBuilder.Entity<SubGenre>().ToTable("SubGenres");

            // Configure relationships
            modelBuilder.Entity<SubGenre>()
                .HasOne(s => s.Genre)
                .WithMany(g => g.SubGenres)
                .HasForeignKey(s => s.GenreId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete if a genre is deleted

            // Seed initial data
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Fiction" },
                new Genre { Id = 2, Name = "Non-Fiction"},
                new Genre { Id = 3, Name = "Children's and Young Adult" },
                new Genre { Id = 4, Name = "Poetry and Drama" },
                new Genre { Id = 5, Name = "Horror/Suspense" },
                new Genre { Id = 6, Name = "Miscellaneous" }
            );

            modelBuilder.Entity<SubGenre>().HasData(
                new SubGenre { Id = 1, Name = "Literary Fiction", GenreId = 1 },
                new SubGenre { Id = 3, Name = "Science Fiction", GenreId = 1 },
                new SubGenre { Id = 4, Name = "Fantasy", GenreId = 1 },
                new SubGenre { Id = 5, Name = "Romance", GenreId = 1 },
                new SubGenre { Id = 6, Name = "Historical Fiction", GenreId = 1 },
                new SubGenre { Id = 7, Name = "Adventure", GenreId = 1 },

                new SubGenre { Id = 3, Name = "Biography/Autobiography", GenreId = 2 },
                new SubGenre { Id = 4, Name = "Self-Help", GenreId = 2 },
                new SubGenre { Id = 3, Name = "History", GenreId = 2 },
                new SubGenre { Id = 3, Name = "Memoir", GenreId = 2 },
                new SubGenre { Id = 3, Name = "Cookbook", GenreId = 2 },
                new SubGenre { Id = 3, Name = "Travel", GenreId = 2 },
                new SubGenre { Id = 3, Name = "Science", GenreId = 2 },


                new SubGenre { Id = 3, Name = "Picture Books", GenreId = 3 },
                new SubGenre { Id = 3, Name = "Middle Grade", GenreId = 3 },
                new SubGenre { Id = 3, Name = "Young Adult", GenreId = 3 },
                new SubGenre { Id = 3, Name = "Contemporary", GenreId = 3 },

                new SubGenre { Id = 3, Name = "Poetry", GenreId = 4 },
                new SubGenre { Id = 3, Name = "Drama", GenreId = 4},
                new SubGenre { Id = 3, Name = "Play", GenreId = 4},

                new SubGenre { Id = 2, Name = "Mystery", GenreId = 5 },
                new SubGenre { Id = 3, Name = "Thriller", GenreId = 5 },
                new SubGenre { Id = 3, Name = "Suspense", GenreId = 5 },
                new SubGenre { Id = 3, Name = "Crime", GenreId = 5 },
                new SubGenre { Id = 3, Name = "Horror", GenreId = 5 },

                new SubGenre { Id = 3, Name = "Humor", GenreId = 6 },
                new SubGenre { Id = 3, Name = "Psychological", GenreId = 6 },
                new SubGenre { Id = 3, Name = "Western", GenreId = 6 },
                new SubGenre { Id = 3, Name = "Satire", GenreId = 6 }
             );
        }

        public DbSet<BOOK_MANAGEMENT_SYSTEM.Models.Book> Book { get; set; } = default!;
    }
}
