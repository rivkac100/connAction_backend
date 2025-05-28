//בס"ד

using BL.Api;
using BL.Models;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IBlOrder orders;
        public OrderController(IBl manager) 
        {
            orders = manager.Order;
        }
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            if (orders.Get() == null)
            {
                return NotFound("Not Found");
            }
            return Ok(orders.Get().Result);
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
            return Ok(orders.GetById(id).Result);
        }
        [HttpGet("GetByDate/{date}")]
        public IActionResult Get(DateOnly date)
        {
            if (date ==null)
            {
                return NotFound("Not Found Id");
            }
            if (date.Year<2000)
            {
                return BadRequest("Invalid Id");
            }
            return Ok(orders.GetByDate(date).Result);
        }
        //[HttpGet("GetByCustomerId/{customerId}")]
        //public IActionResult GetByCustomerId(int customerId)
        //{
        //    if (customerId == 0)
        //    {
        //        return BadRequest("Invalid Id ");
        //    }
        //    return Ok(orders.GetByCustomerId(customerId));
        //}
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                orders.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(orders.Get().Result);
        }
        [HttpPut("Update")]
        public IActionResult Put(BlOrder c)
        {
            try
            {
                orders.Update(c);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(orders.Get().Result);
        }
        [HttpPost("Add")]
        public IActionResult Add(BlOrder c)
        {
            try
            {
                orders.Create(c);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(orders.Get().Result);
        }
    }
}
