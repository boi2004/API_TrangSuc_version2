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
    public class PhukienController : ControllerBase
    {
        private readonly dbtrangsucContext _context;

        public PhukienController(dbtrangsucContext context)
        {
            _context = context;
        }

        // GET: api/Phukiens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Phukien>>> GetPhukiens()
        {
            return await _context.Phukiens.ToListAsync();
        }

        // GET: api/Phukiens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Phukien>> GetPhukien(string id)
        {
            var phukien = await _context.Phukiens.FindAsync(id);

            if (phukien == null)
            {
                return NotFound();
            }

            return phukien;
        }

        // PUT: api/Phukiens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhukien(string id, Phukien phukien)
        {
            if (id != phukien.IdPhukien)
            {
                return BadRequest();
            }

            _context.Entry(phukien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhukienExists(id))
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

        // POST: api/Phukiens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Phukien>> PostPhukien(Phukien phukien)
        {
            _context.Phukiens.Add(phukien);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PhukienExists(phukien.IdPhukien))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPhukien", new { id = phukien.IdPhukien }, phukien);
        }

        // DELETE: api/Phukiens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhukien(string id)
        {
            var phukien = await _context.Phukiens.FindAsync(id);
            if (phukien == null)
            {
                return NotFound();
            }

            _context.Phukiens.Remove(phukien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhukienExists(string id)
        {
            return _context.Phukiens.Any(e => e.IdPhukien == id);
        }
    }
}
