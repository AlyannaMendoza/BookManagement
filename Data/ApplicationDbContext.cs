using BookManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
                new Genre { Id = 2, Name = "Non-Fiction" },
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

                new SubGenre { Id = 8, Name = "Biography/Autobiography", GenreId = 2 },
                new SubGenre { Id = 9, Name = "Self-Help", GenreId = 2 },
                new SubGenre { Id = 10, Name = "History", GenreId = 2 },
                new SubGenre { Id = 11, Name = "Memoir", GenreId = 2 },
                new SubGenre { Id = 12, Name = "Cookbook", GenreId = 2 },
                new SubGenre { Id = 13, Name = "Travel", GenreId = 2 },
                new SubGenre { Id = 14, Name = "Science", GenreId = 2 },

                new SubGenre { Id = 15, Name = "Picture Books", GenreId = 3 },
                new SubGenre { Id = 16, Name = "Middle Grade", GenreId = 3 },
                new SubGenre { Id = 17, Name = "Young Adult", GenreId = 3 },
                new SubGenre { Id = 18, Name = "Contemporary", GenreId = 3 },

                new SubGenre { Id = 19, Name = "Poetry", GenreId = 4 },
                new SubGenre { Id = 20, Name = "Drama", GenreId = 4 },
                new SubGenre { Id = 21, Name = "Play", GenreId = 4 },

                new SubGenre { Id = 22, Name = "Mystery", GenreId = 5 },
                new SubGenre { Id = 23, Name = "Thriller", GenreId = 5 },
                new SubGenre { Id = 24, Name = "Suspense", GenreId = 5 },
                new SubGenre { Id = 25, Name = "Crime", GenreId = 5 },
                new SubGenre { Id = 26, Name = "Horror", GenreId = 5 },

                new SubGenre { Id = 27, Name = "Humor", GenreId = 6 },
                new SubGenre { Id = 28, Name = "Psychological", GenreId = 6 },
                new SubGenre { Id = 29, Name = "Western", GenreId = 6 },
                new SubGenre { Id = 30, Name = "Satire", GenreId = 6 }
             );
        }

        public DbSet<BookManagement.Models.Book> Book { get; set; } = default!;
    }
}
