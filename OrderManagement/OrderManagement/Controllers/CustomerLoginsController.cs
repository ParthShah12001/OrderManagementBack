using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Models;

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerLoginsController : ControllerBase
    {
        private readonly OrderManagement74029Context _context;

        public CustomerLoginsController(OrderManagement74029Context context)
        {
            _context = context;
        }

        // GET: api/CustomerLogins
        [HttpGet]
        public IEnumerable<CustomerLogin> GetCustomerLogin()
        {
            return _context.CustomerLogin;
        }

        // GET: api/CustomerLogins/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerLogin([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerLogin = await _context.CustomerLogin.FindAsync(id);

            if (customerLogin == null)
            {
                return NotFound();
            }

            return Ok(customerLogin);
        }

        // PUT: api/CustomerLogins/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerLogin([FromRoute] int id, [FromBody] CustomerLogin customerLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerLogin.Customerid)
            {
                return BadRequest();
            }

            _context.Entry(customerLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerLoginExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CustomerLogins
        [HttpPost]
        public async Task<IActionResult> PostCustomerLogin([FromBody] CustomerLogin customerLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CustomerLogin.Add(customerLogin);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerLoginExists(customerLogin.Customerid))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomerLogin", new { id = customerLogin.Customerid }, customerLogin);
        }

        // DELETE: api/CustomerLogins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerLogin([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerLogin = await _context.CustomerLogin.FindAsync(id);
            if (customerLogin == null)
            {
                return NotFound();
            }

            _context.CustomerLogin.Remove(customerLogin);
            await _context.SaveChangesAsync();

            return Ok(customerLogin);
        }

        private bool CustomerLoginExists(int id)
        {
            return _context.CustomerLogin.Any(e => e.Customerid == id);
        }
    }
}