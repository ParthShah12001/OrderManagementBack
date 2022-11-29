﻿using System;
using System.Collections.Generic;
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
    public class OrdersController : ControllerBase
    {
        private readonly OrderManagement74029Context _context;

        public OrdersController(OrderManagement74029Context context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public IEnumerable<Orders> GetOrders()
        {
            return _context.Orders;
        }

        [HttpGet("customer/{id}")]
        public async Task<IActionResult> GetOrderedItems([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cartItems = await _context.Orders.Where(i => i.Customerid == id).ToListAsync();

            if (cartItems == null)
            {
                return NotFound();
            }
            cartItems.Reverse();
            return Ok(cartItems);
        }

        [HttpGet("getlastorder")]
        public Orders GetLastOrder()
        {
            var orders = _context.Orders.FromSql("Select * from Orders where orderid=(select max(orderid) from Orders)").FirstOrDefault();



            return orders;
        }
        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrders([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orders = await _context.Orders.FindAsync(id);

            if (orders == null)
            {
                return NotFound();
            }

            return Ok(orders);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrders([FromRoute] int id, [FromBody] Orders orders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orders.Orderid)
            {
                return BadRequest();
            }

            _context.Entry(orders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersExists(id))
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

        // POST: api/Orders
        [HttpPost]
        public async Task<IActionResult> PostOrders([FromBody] Orders orders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Orders.Add(orders);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrdersExists(orders.Orderid))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrders", new { id = orders.Orderid }, orders);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrders([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();

            return Ok(orders);
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.Orderid == id);
        }
    }
}
