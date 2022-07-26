using Microsoft.AspNetCore.Mvc;
using UnitTestingLab.BLL.Services;

namespace UnitTestingLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        private readonly IMathService _mathService;
        private const string TOKEN = "MathToken";

        public MathController(IMathService mathService)
        {
            _mathService = mathService;
        }

        [HttpGet("add")]
        public ActionResult<int> Add(int num1, int num2)
        {
            var token = Request.Headers["Token"];
            if (token != TOKEN)
            {
                return Forbid();
            }

            var result = _mathService.Add(num1, num2);

            return result;
        }

        [HttpGet("subtract")]
        public ActionResult<int> Subtract(int num1, int num2)
        {
            var token = Request.Headers["Token"];
            if (token != TOKEN)
            {
                return Forbid();
            }

            var result = _mathService.Subtract(num1, num2);

            return result;
        }

        [HttpGet("multiply")]
        public ActionResult<int> Multiply(int num1, int num2)
        {
            var token = Request.Headers["Token"];
            if (token != TOKEN)
            {
                return Forbid();
            }

            var result = _mathService.Multiply(num1, num2);

            return result;
        }

        [HttpGet("divide")]
        public ActionResult<int> Divide(int num1, int num2)
        {
            var token = Request.Headers["Token"];
            if (token != TOKEN)
            {
                return Forbid();
            }

            var result = _mathService.Divide(num1, num2);

            return result;
        }
    }
}
