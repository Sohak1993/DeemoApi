using BLL.Interface;
using BLL.Models;
using DeemoApi.Models;
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
            try
            {
                return Ok(_movieService.GetById(id));
            } catch (ArgumentNullException e) {
                return BadRequest(e.Message);
            } catch (Exception e)
            {
                return BadRequest("Exemption non gérée : " + e.Message);
            }

        }

        [HttpPost] 
        public IActionResult Create(MovieForm m)
        {
            if (!ModelState.IsValid) return BadRequest();
            _movieService.Create(new Movie
            {
                Title = m.Title,
                Synopsis = m.Synopsis,
                ReleaseYear = m.ReleaseYear,
                PEGI = m.PEGI,
            });
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Movie m)
        {
            _movieService.Update(m);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _movieService.Delete(id);
            return Ok();
        }
    }
}
