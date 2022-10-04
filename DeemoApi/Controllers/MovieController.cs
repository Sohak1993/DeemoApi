using BLL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_movieService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult getOne(int id)
        {
            
            return Ok(_movieService.GetById(id));
        }
    }
}
