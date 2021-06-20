using ecommerce.data.DTOs;
using ecommerce.data.Model;
using ecommerce.service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ecommerce.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _service;
        ICustomerService _customerService;
        public UserController(IUserService service, ICustomerService customerService)
        {
            _service = service;
            _customerService = customerService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> RegisterUser(UserModel user)
        {
            string result;
            var registerRes = _service.RegisterUser(user);

            if (registerRes != null)
            {
                var customer = new CustomerModelDto()
                {
                    CustomerId = registerRes.Id,
                    Name = user.Name,
                    Age = user.Age,
                    Address = user.Address,
                };
                var response = await _customerService.AddCustomerData(customer);
                result = $"Registration SuccessFull - {response}";
            }
            else
            {
                result = "User Already Exists";
            }
            return Ok(result);
        }

        [HttpPost("Login")]
        public ActionResult LoginUser(User user)
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
