using ecommerce.data.Model;
using ecommerce.service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("Register")]
        public ActionResult RegisterUser(UserModel user)
        {
            string result;

            if (_service.RegisterUser(user))
                result = "Registration SuccessFull";
            else
                result = "User Already Exists";

            return Ok(result);
        }

        [HttpPost("Login")]
        public ActionResult LoginUser(UserModel user)
        {
            var result = _service.AuthenticateUser(user);

            if (result is null)
            {
                return Unauthorized();
            }

            return Ok(result);
        }

    }
}
