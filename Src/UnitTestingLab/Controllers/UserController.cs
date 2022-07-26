using Microsoft.AspNetCore.Mvc;
using UnitTestingLab.BLL.Services;
using UnitTestingLab.Models;

namespace UnitTestingLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private const string TOKEN = "UserToken";

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<IEnumerable<UserModel>> Get()
        {
            var token = Request.Headers["Token"];
            if (token != TOKEN)
            {
                return Forbid();
            }

            var users = _userService.Get();

            var response = users
                .Select(u => new UserModel(u))
                .ToList();

            return Ok(response);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<UserModel> Get(Guid id)
        {
            var token = Request.Headers["Token"];
            if (token != TOKEN)
            {
                return Forbid();
            }

            var user = _userService.Get(id);

            var response = new UserModel(user);

            return Ok(response);
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult Post([FromBody] UserModel value)
        {
            var token = Request.Headers["Token"];
            if (token != TOKEN)
            {
                return Forbid();
            }

            var user = value.ToEntity();

            _userService.Create(user);

            return Ok();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] UserModel value)
        {
            var token = Request.Headers["Token"];
            if (token != TOKEN)
            {
                return Forbid();
            }

            var user = value.ToEntity();

            _userService.Update(id, user);

            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var token = Request.Headers["Token"];
            if (token != TOKEN)
            {
                return Forbid();
            }

            _userService.Delete(id);

            return Ok();
        }
    }
}
