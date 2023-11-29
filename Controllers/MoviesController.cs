using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public MoviesService MovieService { get; set; }
        public MoviesController(MoviesService movieService)
        {
            MovieService = movieService;
        }


        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieVM movie)
        {
            MovieService.AddMovie(movie);
            return Ok();
        }
        public List<Movie> GetAllMovie()
        {
            return MovieService.GetAllMovies();
        }
        public Movie? GetMoviesById(int id)
        {
            return MovieService.GetMovieById(id);
        }


        //DOHVAT SVIH KNJIGA i DOHVAT JEDNE KNJIGE PREKO ID-a

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var allMovies = MovieService.GetAllMovies();
            return Ok(allMovies);
        }


        [HttpGet("id")]
        public IActionResult GetMovieById([FromQuery] int id)
        {
            var movie = MovieService.GetMovieById(id);
            return Ok(movie);
        }


        [HttpPut("id")]
        public IActionResult UpdateMoveById([FromQuery] int id,
        [FromBody] MovieVM movieVM, MoviesService moviesService)
        {
            var updatedMovie = moviesService.UpdateMoveById(id, movieVM);
            return Ok(updatedMovie);
        }


        [HttpDelete("id")]
        public IActionResult DeleteMovie ([FromQuery] int id, MoviesService moviesService)
        {
            moviesService.DeleteMovie(id);
            return Ok();
        }
    }
}
