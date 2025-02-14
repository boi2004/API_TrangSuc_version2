using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_TrangSuc_vs2.Models;

namespace API_TrangSuc_vs2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VanchuyenController : ControllerBase
    {
        private readonly dbtrangsucContext _context;

        public VanchuyenController(dbtrangsucContext context)
        {
            _context = context;
        }

        // GET: api/Vanchuyens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vanchuyen>>> GetVanchuyens()
        {
            return await _context.Vanchuyens.ToListAsync();
        }

        // GET: api/Vanchuyens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vanchuyen>> GetVanchuyen(string id)
        {
            var vanchuyen = await _context.Vanchuyens.FindAsync(id);

            if (vanchuyen == null)
            {
                return NotFound();
            }

            return vanchuyen;
        }

        // PUT: api/Vanchuyens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVanchuyen(string id, Vanchuyen vanchuyen)
        {
            if (id != vanchuyen.IdVanchuyen)
            {
                return BadRequest();
            }

            _context.Entry(vanchuyen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VanchuyenExists(id))
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

        // POST: api/Vanchuyens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vanchuyen>> PostVanchuyen(Vanchuyen vanchuyen)
        {
            _context.Vanchuyens.Add(vanchuyen);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VanchuyenExists(vanchuyen.IdVanchuyen))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVanchuyen", new { id = vanchuyen.IdVanchuyen }, vanchuyen);
        }

        // DELETE: api/Vanchuyens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVanchuyen(string id)
        {
            var vanchuyen = await _context.Vanchuyens.FindAsync(id);
            if (vanchuyen == null)
            {
                return NotFound();
            }

            _context.Vanchuyens.Remove(vanchuyen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VanchuyenExists(string id)
        {
            return _context.Vanchuyens.Any(e => e.IdVanchuyen == id);
        }
    }
}
