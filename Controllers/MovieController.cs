using Microsoft.AspNetCore.Mvc;

namespace iMovieMaker.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly ILogger<MovieController> _logger;
    private readonly MovieDbContext _dbContext;

    public MovieController(ILogger<MovieController> logger, MovieDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet(Name = "Greet")]
    public IActionResult Get()
    {
        return Ok("Welcome to iMovieMaker v2 again");
    }

    [HttpPost]
    public IActionResult PostMovie(Movie movie){
        _dbContext.Movies.Add(movie);
        _dbContext.SaveChanges();
        return Ok($"Movie with id: {movie.Id}");
    }
}
