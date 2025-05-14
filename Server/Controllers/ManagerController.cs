using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        IBlManager manager;

        public ManagersController(IBl manager)
        {
            this.manager = manager.Manager;
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            if (manager.Get().Result == null)
            {
                return NotFound("Not Found");
            }
            return Ok(manager.Get().Result);
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
            return Ok(manager.GetById(id).Result);
        }
        [HttpGet("GetCustomersById/{id}")]
        public IActionResult GetCustomersByManagerId(int id)
        {
            if (id == 0)
            {
                return NotFound("Not Found Id");
            }
            if (id < 0)
            {
                return BadRequest("Invalid Id");
            }
            return Ok(manager.GetCustomersByManagerId(id).Result);
        }
        [HttpGet("GetOrdersById/{id}")]
        public IActionResult GetOrdrsByManagerId(int id)
        {
            if (id == 0)
            {
                return NotFound("Not Found Id");
            }
            if (id < 0)
            {
                return BadRequest("Invalid Id");
            }
            return Ok(manager.GetOrdersByManagerId(id).Result);
        }
        [HttpGet("GetActivitiesById/{id}")]
        public IActionResult GetActivitiesByManagerId(int id)
        {
            if (id == 0)
            {
                return NotFound("Not Found Id");
            }
            if (id < 0)
            {
                return BadRequest("Invalid Id");
            }
            return Ok(manager.GetActivitiesByManagerId(id).Result);
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
            return Ok(manager.Get().Result);

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
            return Ok(manager.Get().Result);
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
            return Ok(manager.Get().Result);

        }


    }
}
