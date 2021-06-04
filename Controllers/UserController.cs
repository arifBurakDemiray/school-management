using Microsoft.AspNetCore.Mvc;
using SchoolManagament.API.Security;
using SchoolManagement.API.Security;


namespace SchoolManagement.API.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private IUserService userService;
        public UserController(IUserService userservice)
        {
            userService = userservice;
        }
         [Route("token")]
         [HttpPost]
         public IActionResult Authenticate(AuthenticationRequest model)
        {
            var response = userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
    }
}
