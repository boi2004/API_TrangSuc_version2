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
    public class ChitietspController : ControllerBase
    {
        private readonly dbtrangsucContext _context;

        public ChitietspController(dbtrangsucContext context)
        {
            _context = context;
        }

        // GET: api/Chitietsps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chitietsp>>> GetChitietsps()
        {
            return await _context.Chitietsps.ToListAsync();
        }

        // GET: api/Chitietsps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chitietsp>> GetChitietsp(string id)
        {
            var chitietsp = await _context.Chitietsps.FindAsync(id);

            if (chitietsp == null)
            {
                return NotFound();
            }

            return chitietsp;
        }

        // PUT: api/Chitietsps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChitietsp(string id, Chitietsp chitietsp)
        {
            if (id != chitietsp.IdCtsp)
            {
                return BadRequest();
            }

            _context.Entry(chitietsp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChitietspExists(id))
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

        // POST: api/Chitietsps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Chitietsp>> PostChitietsp(Chitietsp chitietsp)
        {
            _context.Chitietsps.Add(chitietsp);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChitietspExists(chitietsp.IdCtsp))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChitietsp", new { id = chitietsp.IdCtsp }, chitietsp);
        }

        // DELETE: api/Chitietsps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChitietsp(string id)
        {
            var chitietsp = await _context.Chitietsps.FindAsync(id);
            if (chitietsp == null)
            {
                return NotFound();
            }

            _context.Chitietsps.Remove(chitietsp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChitietspExists(string id)
        {
            return _context.Chitietsps.Any(e => e.IdCtsp == id);
        }
    }
}
