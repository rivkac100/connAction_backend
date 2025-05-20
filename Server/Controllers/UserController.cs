using BL.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IBlUser user;

        public UserController(IBl manager)
        {
            this.user = manager.User;
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            if (user.GetAll().Result == null)
            {
                return NotFound("Not Found");
            }
            return Ok(user.GetAll().Result);
        }
        [HttpGet("GetByid/{pass}")]
        public IActionResult Get(string pass)
        {
            if (pass =="")
            {
                return NotFound("Not Found Id");
            }
            if (pass == null)
            {
                return BadRequest("Invalid Id");
            }
            return Ok(user.GetById(pass).Result);
        }
    }
}
