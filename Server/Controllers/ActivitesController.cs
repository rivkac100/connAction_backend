//בס"ד

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BL.Api;
using BL.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitesController : ControllerBase
    {
        IBlActivity activity;

        public ActivitesController(IBl manager)
        {
            activity = manager.Activity;
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            if (activity.Get() == null)
            {
                return NotFound("Not Found");
            }
            return Ok(activity.Get());
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
            return Ok(activity.GetById(id));
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                activity.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(activity.Get());

        }
        [HttpPut("Update")]
        public IActionResult Update(BlActivity a)
        {
            try
            {
                activity.Update(a);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(activity.Get());
        }
        [HttpPost("Add")]
        public IActionResult Add(BlActivity a)
        {
            try
            {
                    activity.Create(a);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(activity.Get());

        }

    }
}
