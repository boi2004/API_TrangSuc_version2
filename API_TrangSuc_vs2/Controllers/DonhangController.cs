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
    public class DonhangController : ControllerBase
    {
        private readonly dbtrangsucContext _context;

        public DonhangController(dbtrangsucContext context)
        {
            _context = context;
        }

        // GET: api/Donhangs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donhang>>> GetDonhangs()
        {
            return await _context.Donhangs.ToListAsync();
        }

        // GET: api/Donhangs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Donhang>> GetDonhang(string id)
        {
            var donhang = await _context.Donhangs.FindAsync(id);

            if (donhang == null)
            {
                return NotFound();
            }

            return donhang;
        }

        // PUT: api/Donhangs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonhang(string id, Donhang donhang)
        {
            if (id != donhang.IdDonhang)
            {
                return BadRequest();
            }

            _context.Entry(donhang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonhangExists(id))
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

        // POST: api/Donhangs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Donhang>> PostDonhang(Donhang donhang)
        {
            _context.Donhangs.Add(donhang);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DonhangExists(donhang.IdDonhang))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDonhang", new { id = donhang.IdDonhang }, donhang);
        }

        // DELETE: api/Donhangs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonhang(string id)
        {
            var donhang = await _context.Donhangs.FindAsync(id);
            if (donhang == null)
            {
                return NotFound();
            }

            _context.Donhangs.Remove(donhang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DonhangExists(string id)
        {
            return _context.Donhangs.Any(e => e.IdDonhang == id);
        }
    }
}
