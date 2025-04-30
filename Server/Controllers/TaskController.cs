//בס"ד

using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        IBlTask tasks;
        public TaskController(IBl manager)
        {
            tasks = manager.Task;
        }
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            if (tasks.Get() == null)
            {
                return NotFound("Not Found");
            }
            return Ok(tasks.Get());
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
            return Ok(tasks.GetById(id));
        }
        [HttpDelete("Delete/{id}")]
        public void Delete(int id)
        {
            try
            {
                tasks.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        [HttpPut("Update")]
        public void Put(BlTask c)
        {
            try
            {
                tasks.Update(c);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        [HttpPost("Add")]
        public void Add(BlTask c)
        {
            try
            {
                tasks.Create(c);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
