using BLL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DeemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _movieService;
        public UserController(IUserService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_movieService.GetAll());
        }
    }
}
