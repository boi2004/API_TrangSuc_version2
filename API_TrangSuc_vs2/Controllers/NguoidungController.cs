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
    public class NguoidungController : ControllerBase
    {
        private readonly dbtrangsucContext _context;

        public NguoidungController(dbtrangsucContext context)
        {
            _context = context;
        }

        // GET: api/Nguoidungs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nguoidung>>> GetNguoidungs()
        {
            return await _context.Nguoidungs.ToListAsync();
        }

        // GET: api/Nguoidungs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nguoidung>> GetNguoidung(string id)
        {
            var nguoidung = await _context.Nguoidungs.FindAsync(id);

            if (nguoidung == null)
            {
                return NotFound();
            }

            return nguoidung;
        }

        // PUT: api/Nguoidungs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNguoidung(string id, Nguoidung nguoidung)
        {
            if (id != nguoidung.IdNguoidung)
            {
                return BadRequest();
            }

            _context.Entry(nguoidung).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguoidungExists(id))
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

        // POST: api/Nguoidungs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Nguoidung>> PostNguoidung(Nguoidung nguoidung)
        {
            _context.Nguoidungs.Add(nguoidung);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NguoidungExists(nguoidung.IdNguoidung))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNguoidung", new { id = nguoidung.IdNguoidung }, nguoidung);
        }

        // DELETE: api/Nguoidungs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNguoidung(string id)
        {
            var nguoidung = await _context.Nguoidungs.FindAsync(id);
            if (nguoidung == null)
            {
                return NotFound();
            }

            _context.Nguoidungs.Remove(nguoidung);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NguoidungExists(string id)
        {
            return _context.Nguoidungs.Any(e => e.IdNguoidung == id);
        }
    }
}
