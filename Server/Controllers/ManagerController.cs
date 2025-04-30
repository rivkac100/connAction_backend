using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class managersController : ControllerBase
    {
        IBlManager manager;

        public managersController(IBl manager)
        {
            this.manager = manager.Manager;
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            if (manager.Get() == null)
            {
                return NotFound("Not Found");
            }
            return Ok(manager.Get());
        }
        [HttpGet("GetByid/{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
            {
                return NotFound("Not Found Id");
            }
            if (id < 0)
            {
                return BadRequest("Invalid Id");
            }
            return Ok(manager.GetById(id));
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                manager.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(manager.Get());

        }
        [HttpPut("Update")]
        public IActionResult Update(BlManager c)
        {
            try
            {
                manager.Update(c);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(manager.Get());
        }
        [HttpPost("Add")]
        public IActionResult Add(BlManager c)
        {
            try
            {
                manager.Create(c);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(manager.Get());

        }


    }
}
