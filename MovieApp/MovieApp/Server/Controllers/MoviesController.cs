using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieApp.Server.Services;
using MovieApp.Shared.Models;
using System;
using System.Threading.Tasks;


namespace MovieApp.Server.Controllers
{
    [Authorize]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IMoviesDbService _dbService;

        public MoviesController(IMoviesDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            try
            {
                var result = await _dbService.GetMovies();
                if(result == null)
                {
                    _logger.LogWarning("Movies not present in Database");
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                _logger.LogError($"GetMovies Threw An Exception");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Getting the Data");
            }

        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Movie>> GetMovie(int Id)
        {
            try
            {
                var result = await _dbService.GetMovie(Id);
                if (result == null)
                {
                    _logger.LogWarning($"Movie with {Id} not present");
                    return NotFound($"Movie with {Id} not present");
                }
                return result;
            }
            catch (Exception)
            {
                _logger.LogError($"GetMovie Threw An Exception");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting data");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> AddMovie(Movie movie)
        {
            try
            {
                if (movie == null) 
                {
                    _logger.LogWarning($"Data for {movie} Not Provided By the User");
                    return BadRequest($"Data for {movie} Not Provided By the User");
                }
                var newMovie = await _dbService.AddMovie(movie);
                return CreatedAtAction(nameof(GetMovie), new { id = newMovie.Id },
                    newMovie);

            }
            catch (Exception)
            {
                _logger.LogError($"AddMovie Threw An Exception");
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error getting data");
            }
        }

        [HttpPut()]
        public async Task<ActionResult<Movie>> UdateMovie( Movie movie)
        {
            try
            {
                var updateMovie = await _dbService.GetMovie(movie.Id);

                if (updateMovie == null) 
                {
                    _logger.LogWarning($"Movie with Id = {movie.Id} not Found");
                    return NotFound($"Movie with Id = {movie.Id} not Found");
                }

                return await _dbService.UpdateMovie(movie);

            }
            catch (Exception)
            {
                _logger.LogError($"UpdateMovies Threw An Exception");
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error getting data");
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Movie>> DeleteMovie(int Id)
        {
            try
            {
                var movieDelete = await _dbService.GetMovie(Id);

                if (movieDelete == null)
                {
                    _logger.LogWarning($"Movie with Id = {Id} not Found");
                    return NotFound($"Movie with Id = {Id} not Found");
                }

                return await _dbService.DeleteMovie(Id);
            }
            catch (Exception)
            {
                _logger.LogError($"DeleteMovies Threw An Exception");
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error getting data");
            }

        }

    }
}

