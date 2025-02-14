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
    public class KhuyenmaiController : ControllerBase
    {
        private readonly dbtrangsucContext _context;

        public KhuyenmaiController(dbtrangsucContext context)
        {
            _context = context;
        }

        // GET: api/Khuyenmais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Khuyenmai>>> GetKhuyenmais()
        {
            return await _context.Khuyenmais.ToListAsync();
        }

        // GET: api/Khuyenmais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Khuyenmai>> GetKhuyenmai(string id)
        {
            var khuyenmai = await _context.Khuyenmais.FindAsync(id);

            if (khuyenmai == null)
            {
                return NotFound();
            }

            return khuyenmai;
        }

        // PUT: api/Khuyenmais/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhuyenmai(string id, Khuyenmai khuyenmai)
        {
            if (id != khuyenmai.IdKhuyenmai)
            {
                return BadRequest();
            }

            _context.Entry(khuyenmai).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhuyenmaiExists(id))
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

        // POST: api/Khuyenmais
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Khuyenmai>> PostKhuyenmai(Khuyenmai khuyenmai)
        {
            _context.Khuyenmais.Add(khuyenmai);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KhuyenmaiExists(khuyenmai.IdKhuyenmai))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKhuyenmai", new { id = khuyenmai.IdKhuyenmai }, khuyenmai);
        }

        // DELETE: api/Khuyenmais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhuyenmai(string id)
        {
            var khuyenmai = await _context.Khuyenmais.FindAsync(id);
            if (khuyenmai == null)
            {
                return NotFound();
            }

            _context.Khuyenmais.Remove(khuyenmai);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KhuyenmaiExists(string id)
        {
            return _context.Khuyenmais.Any(e => e.IdKhuyenmai == id);
        }
    }
}
