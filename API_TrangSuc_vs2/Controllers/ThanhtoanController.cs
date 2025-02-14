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
    public class ThanhtoanController : ControllerBase
    {
        private readonly dbtrangsucContext _context;

        public ThanhtoanController(dbtrangsucContext context)
        {
            _context = context;
        }

        // GET: api/Thanhtoans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Thanhtoan>>> GetThanhtoans()
        {
            return await _context.Thanhtoans.ToListAsync();
        }

        // GET: api/Thanhtoans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Thanhtoan>> GetThanhtoan(string id)
        {
            var thanhtoan = await _context.Thanhtoans.FindAsync(id);

            if (thanhtoan == null)
            {
                return NotFound();
            }

            return thanhtoan;
        }

        // PUT: api/Thanhtoans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThanhtoan(string id, Thanhtoan thanhtoan)
        {
            if (id != thanhtoan.IdThanhtoan)
            {
                return BadRequest();
            }

            _context.Entry(thanhtoan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThanhtoanExists(id))
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

        // POST: api/Thanhtoans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Thanhtoan>> PostThanhtoan(Thanhtoan thanhtoan)
        {
            _context.Thanhtoans.Add(thanhtoan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ThanhtoanExists(thanhtoan.IdThanhtoan))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetThanhtoan", new { id = thanhtoan.IdThanhtoan }, thanhtoan);
        }

        // DELETE: api/Thanhtoans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThanhtoan(string id)
        {
            var thanhtoan = await _context.Thanhtoans.FindAsync(id);
            if (thanhtoan == null)
            {
                return NotFound();
            }

            _context.Thanhtoans.Remove(thanhtoan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThanhtoanExists(string id)
        {
            return _context.Thanhtoans.Any(e => e.IdThanhtoan == id);
        }
    }
}
