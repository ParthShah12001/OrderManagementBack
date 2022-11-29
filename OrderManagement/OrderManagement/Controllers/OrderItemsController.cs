using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly OrderManagement74029Context _context;

        public OrderItemsController(OrderManagement74029Context context)
        {
            _context = context;
        }

        // GET: api/OrderItems
        [HttpGet]
        public IEnumerable<OrderItems> GetOrderItems()
        {
            return _context.OrderItems;
        }

        [HttpGet("cart/{id}")]
        public async Task<IActionResult> GetCartItems([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cartItems = await _context.OrderItems.Where(i => i.Customerid == id).ToListAsync();

            if (cartItems == null)
            {
                return NotFound();
            }

            return Ok(cartItems);
        }

        [HttpGet("gettotal/{id}")]
        public decimal GetTotalPrice([FromRoute] int id)
        {

            var total = _context.OrderItems.Where(i => i.Customerid == id).Sum(i => i.Price);
            return total;
        }

        [HttpGet("ordered/{orderid}/{id}")]
        public async Task<IActionResult> GetOrderedItems([FromRoute] int id, [FromRoute]int orderid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cartItems = await _context.OrderItems.Where(i => i.Customerid == id && i.Orderid == orderid).ToListAsync();

            if (cartItems == null)
            {
                return NotFound();
            }

            return Ok(cartItems);
        }


        // GET: api/OrderItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderItems([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderItems = await _context.OrderItems.FindAsync(id);

            if (orderItems == null)
            {
                return NotFound();
            }

            return Ok(orderItems);
        }

        // PUT: api/OrderItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderItems([FromRoute] int id, [FromBody] OrderItems orderItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderItems.Itemid)
            {
                return BadRequest();
            }

            _context.Entry(orderItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderItemsExists(id))
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

        // POST: api/OrderItems
        [HttpPost]
        public async Task<IActionResult> PostOrderItems([FromBody] OrderItems orderItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OrderItems.Add(orderItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderItems", new { id = orderItems.Itemid }, orderItems);
        }

        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItems([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderItems = await _context.OrderItems.FindAsync(id);
            if (orderItems == null)
            {
                return NotFound();
            }

            _context.OrderItems.Remove(orderItems);
            await _context.SaveChangesAsync();

            return Ok(orderItems);
        }

        private bool OrderItemsExists(int id)
        {
            return _context.OrderItems.Any(e => e.Itemid == id);
        }
    }
}
