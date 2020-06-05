using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToysController : ControllerBase
    {
        private readonly DBToyShopContext _context;

        public ToysController(DBToyShopContext context)
        {
            _context = context;
        }

        // GET: api/Toys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Toys>>> GetToys()
        {
            return await _context.Toys.ToListAsync();
        }

        // GET: api/Toys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Toys>> GetToys(int id)
        {
            var toys = await _context.Toys.FindAsync(id);

            if (toys == null)
            {
                return NotFound();
            }

            return toys;
        }

        // PUT: api/Toys/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToys(int id, Toys toys)
        {
            if (id != toys.ToyId)
            {
                return BadRequest();
            }

            _context.Entry(toys).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToysExists(id))
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

        // POST: api/Toys
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Toys>> PostToys(Toys toys)
        {
            _context.Toys.Add(toys);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToys", new { id = toys.ToyId }, toys);
        }

        // DELETE: api/Toys/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Toys>> DeleteToys(int id)
        {
            var toys = await _context.Toys.FindAsync(id);
            if (toys == null)
            {
                return NotFound();
            }

            _context.Toys.Remove(toys);
            await _context.SaveChangesAsync();

            return toys;
        }

        private bool ToysExists(int id)
        {
            return _context.Toys.Any(e => e.ToyId == id);
        }
    }
}
