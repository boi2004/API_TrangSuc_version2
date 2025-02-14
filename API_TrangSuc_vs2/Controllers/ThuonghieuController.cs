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
    public class ThuonghieuController : ControllerBase
    {
        private readonly dbtrangsucContext _context;

        public ThuonghieuController(dbtrangsucContext context)
        {
            _context = context;
        }

        // GET: api/Thuonghieux
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Thuonghieu>>> GetThuonghieus()
        {
            return await _context.Thuonghieus.ToListAsync();
        }

        // GET: api/Thuonghieux/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Thuonghieu>> GetThuonghieu(string id)
        {
            var thuonghieu = await _context.Thuonghieus.FindAsync(id);

            if (thuonghieu == null)
            {
                return NotFound();
            }

            return thuonghieu;
        }

        // PUT: api/Thuonghieux/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThuonghieu(string id, Thuonghieu thuonghieu)
        {
            if (id != thuonghieu.IdThuonghieu)
            {
                return BadRequest();
            }

            _context.Entry(thuonghieu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThuonghieuExists(id))
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

        // POST: api/Thuonghieux
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Thuonghieu>> PostThuonghieu(Thuonghieu thuonghieu)
        {
            _context.Thuonghieus.Add(thuonghieu);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ThuonghieuExists(thuonghieu.IdThuonghieu))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetThuonghieu", new { id = thuonghieu.IdThuonghieu }, thuonghieu);
        }

        // DELETE: api/Thuonghieux/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThuonghieu(string id)
        {
            var thuonghieu = await _context.Thuonghieus.FindAsync(id);
            if (thuonghieu == null)
            {
                return NotFound();
            }

            _context.Thuonghieus.Remove(thuonghieu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThuonghieuExists(string id)
        {
            return _context.Thuonghieus.Any(e => e.IdThuonghieu == id);
        }
    }
}
