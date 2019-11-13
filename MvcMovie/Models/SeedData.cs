using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "The RM",
                        ReleaseDate = DateTime.Parse("2003-1-31"),
                        Genre = "Romantic Comedy",
                        Rating = "PG",
                        Price = 4.99M
                    },

                    new Movie
                    {
                        Title = "The Singles Ward",
                        ReleaseDate = DateTime.Parse("2002-1-30"),
                        Genre = "Romantic Comedy",
                        Rating = "PG",
                        Price = 4.99M
                    },

                    new Movie
                    {
                        Title = "The Best Two Years",
                        ReleaseDate = DateTime.Parse("2004-2-20"),
                        Genre = "Drama",
                        Rating = "PG",
                        Price = 9.99M
                    },

                    new Movie
                    {
                        Title = "The Singles 2nd Ward",
                        ReleaseDate = DateTime.Parse("2007-12-11"),
                        Genre = "Romantic Comedy",
                        Rating = "PG",
                        Price = 4.99M
                        
                    }
                );
                context.SaveChanges();
            }
        }
    }
}