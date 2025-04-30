using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        IBlEvent events;
        public EventController(IBl manager)
        {
            events = manager.Event;
        }
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            if (events.Get() == null)
            {
                return NotFound("Not Found");
            }
            return Ok(events.Get());
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
            return Ok(events.GetById(id));
        }
        //[HttpGet("GetByCustomerId/{customerId}")]
        //public IActionResult GetByCustomerId(int customerId)
        //{
        //    if (customerId == 0)
        //    {
        //        return BadRequest("Invalid Id ");
        //    }
        //    return Ok(events.GetByCustomerId(customerId));
        //}
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                events.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(events.Get());
        }
        [HttpPut("Update")]
        public IActionResult Put(BlEvent e)
        {
            try
            {
                events.Update(e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(events.Get());
        }
        [HttpPost("Add")]
        public IActionResult Add(BlEvent e)
        {
            try
            {
                events.Create(e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(events.Get());

        }
    }
}
