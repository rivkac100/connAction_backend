//בס"ד
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BL.Api;
using BL.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        IBlCustomer customer;

        public CustomersController(IBl manager)
        {
            customer = manager.Customer;
        }

        [HttpGet("GetAll")]
        public IActionResult Get() {
            if (customer.Get().Result == null)
            {
                return NotFound("Not Found");
            }
            return Ok(customer.Get().Result);
        }
        [HttpGet("GetByid/{id}")]
        public IActionResult Get(int id) {
            if (id== 0)
            {
                return NotFound("Not Found Id");
            }
            if (id < 0)
            {
                return BadRequest("Invalid Id");
            }
            return Ok(customer.GetById(id).Result);
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try { 
             customer.Delete(id);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            return Ok(customer.Get().Result);

        }
        [HttpPut("Update")]
        public IActionResult Update(BlCustomer c)
        {
            try
            {
                customer.Update(c);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(customer.Get().Result);
        }
        [HttpPost("Add")]
        public IActionResult Add(BlCustomer c)
        {
            try
            {
                customer.Create(c);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(customer.Get().Result);

        }


    }

}
