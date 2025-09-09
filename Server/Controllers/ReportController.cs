//בס"ד

using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        IBlReport reports;
        public ReportController(IBl manager)
        {
            reports = manager.Report;
        }
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            if (reports.Get().Result == null)
            {
                return NotFound("Not Found");
            }
            return Ok(reports.Get().Result);
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
            return Ok(reports.GetById(id).Result);
        }
        [HttpGet("GetByManagerId/{id}")]
        public IActionResult GetByManagerId(int id)
        {
            if (id == 0)
            {
                return NotFound("Not Found Id");
            }
            if (id < 0)
            {
                return BadRequest("Invalid Id");
            }
            return Ok(reports.GetByManagerId(id).Result);
        }
        [HttpGet("GetByActivityId/{id}")]
        public IActionResult GetByActivityId(int id)
        {
            if (id == 0)
            {
                return NotFound("Not Found Id");
            }
            if (id < 0)
            {
                return BadRequest("Invalid Id");
            }
            return Ok(reports.GetByActivityId(id).Result);
        }
        [HttpGet("GetByCUsterId/{id}")]
        public IActionResult GetByCusterId(int id)
        {
            if (id == 0)
            {
                return NotFound("Not Found Id");
            }
            if (id < 0)
            {
                return BadRequest("Invalid Id");
            }
            return Ok(reports.GetByCustomerId(id).Result);
        }
        [HttpGet("GetByOrderId/{id}")]
        public IActionResult GetOrdrsByOrderId(int id)
        {
            if (id == 0)
            {
                return NotFound("Not Found Id");
            }
            if (id < 0)
            {
                return BadRequest("Invalid Id");
            }
            return Ok(reports.GetByOrderId(id).Result);
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                reports.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(reports.Get());
        }
        [HttpPut("Update")]
        public IActionResult Put(BlReport c)
        {
            try
            {
                reports.Update(c);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(reports.Get());
        }
        [HttpPost("Add")]
        public IActionResult Add(BlReport c)
        {
            try
            {
                reports.Create(c);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(reports.Get());
        }
    }
}
