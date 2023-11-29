using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using System.Diagnostics.Eventing.Reader;

namespace MoviesAPI.Services
{
    public class MoviesService
    {
        private AppDbContext _context;
        public MoviesService(AppDbContext context)
        {
            _context = context;
        }
        public void AddMovie(MovieVM movie)
        {
            var newMovie = new Movie()
            {
                Name = movie.Name,
                Year = movie.Year,
                Genre = movie.Genre,
            };
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
        }
        public List<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }
        public Movie? GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(x => x.Id == id);
        }


        public Movie? UpdateMoveById(int id, MovieVM movieVM)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if(movie !=null)
            {
                movie.Name = movie.Name;
                movie.Year = movie.Year;
                movie.Genre = movie.Genre;

            _context.SaveChanges();
            }
            return movie;
        }

        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}
