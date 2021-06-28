using Microsoft.EntityFrameworkCore;
using MovieApp.Server.Data;
using MovieApp.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Server.Services
{
    public interface IMoviesRepository
    {

    }

    public interface IMoviesDbService
    {
        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> GetMovie(int Id);
        Task<Movie> AddMovie(Movie movie);
        Task<Movie> UpdateMovie(Movie movie);
        Task<Movie> DeleteMovie(int id);

    }

    public class MoviesDbService : IMoviesDbService
    {
        private ApplicationDbContext _context;

        public MoviesDbService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Movie> AddMovie(Movie movie)
        {
            var result = await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Movie> DeleteMovie(int id)
        {
            var result = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                _context.Movies.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Movie> GetMovie(int Id)
        {
            return await _context.Movies.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _context.Movies.OrderBy(x => x.Title).ToListAsync();
        }

        public async Task<Movie> UpdateMovie(Movie movie)
        {
            var result = await _context.Movies
                .FirstOrDefaultAsync(x => x.Id == movie.Id);

            if (result != null)
            {
                result.Id = movie.Id;
                result.Title = movie.Title;
                result.Summary = movie.Summary;
                result.InTheaters = movie.InTheaters;
                result.ReleaseDate = movie.ReleaseDate;
                result.Trailer = movie.Trailer;
                result.Poster = movie.Poster;

                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

    }
}
