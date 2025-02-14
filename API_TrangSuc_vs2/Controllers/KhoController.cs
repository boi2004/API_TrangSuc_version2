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
    public class KhoController : ControllerBase
    {
        private readonly dbtrangsucContext _context;

        public KhoController(dbtrangsucContext context)
        {
            _context = context;
        }

        // GET: api/Khoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kho>>> GetKhos()
        {
            return await _context.Khos.ToListAsync();
        }

        // GET: api/Khoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kho>> GetKho(string id)
        {
            var kho = await _context.Khos.FindAsync(id);

            if (kho == null)
            {
                return NotFound();
            }

            return kho;
        }

        // PUT: api/Khoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKho(string id, Kho kho)
        {
            if (id != kho.IdKho)
            {
                return BadRequest();
            }

            _context.Entry(kho).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhoExists(id))
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

        // POST: api/Khoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kho>> PostKho(Kho kho)
        {
            _context.Khos.Add(kho);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KhoExists(kho.IdKho))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKho", new { id = kho.IdKho }, kho);
        }

        // DELETE: api/Khoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKho(string id)
        {
            var kho = await _context.Khos.FindAsync(id);
            if (kho == null)
            {
                return NotFound();
            }

            _context.Khos.Remove(kho);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KhoExists(string id)
        {
            return _context.Khos.Any(e => e.IdKho == id);
        }
    }
}
