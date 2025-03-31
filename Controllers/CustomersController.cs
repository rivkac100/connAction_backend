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
            if (customer.Get() == null)
            {
                return NotFound("Not Found");
            }
            return Ok(customer.Get());
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
            return Ok(customer.GetById(id));
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
            return Ok(customer.Get());

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
            return Ok(customer.Get());
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
            return Ok(customer.Get());

        }


    }

}
