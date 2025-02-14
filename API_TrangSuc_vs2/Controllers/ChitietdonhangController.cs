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
    public class ChitietdonhangController : ControllerBase
    {
        private readonly dbtrangsucContext _context;

        public ChitietdonhangController(dbtrangsucContext context)
        {
            _context = context;
        }

        // GET: api/Chitietdonhangs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chitietdonhang>>> GetChitietdonhangs()
        {
            return await _context.Chitietdonhangs.ToListAsync();
        }

        // GET: api/Chitietdonhangs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chitietdonhang>> GetChitietdonhang(string id)
        {
            var chitietdonhang = await _context.Chitietdonhangs.FindAsync(id);

            if (chitietdonhang == null)
            {
                return NotFound();
            }

            return chitietdonhang;
        }

        // PUT: api/Chitietdonhangs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChitietdonhang(string id, Chitietdonhang chitietdonhang)
        {
            if (id != chitietdonhang.IdCthd)
            {
                return BadRequest();
            }

            _context.Entry(chitietdonhang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChitietdonhangExists(id))
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

        // POST: api/Chitietdonhangs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Chitietdonhang>> PostChitietdonhang(Chitietdonhang chitietdonhang)
        {
            _context.Chitietdonhangs.Add(chitietdonhang);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChitietdonhangExists(chitietdonhang.IdCthd))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChitietdonhang", new { id = chitietdonhang.IdCthd }, chitietdonhang);
        }

        // DELETE: api/Chitietdonhangs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChitietdonhang(string id)
        {
            var chitietdonhang = await _context.Chitietdonhangs.FindAsync(id);
            if (chitietdonhang == null)
            {
                return NotFound();
            }

            _context.Chitietdonhangs.Remove(chitietdonhang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChitietdonhangExists(string id)
        {
            return _context.Chitietdonhangs.Any(e => e.IdCthd == id);
        }
    }
}
