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
    public class VaitroController : ControllerBase
    {
        private readonly dbtrangsucContext _context;

        public VaitroController(dbtrangsucContext context)
        {
            _context = context;
        }

        // GET: api/Vaitroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vaitro>>> GetVaitros()
        {
            return await _context.Vaitros.ToListAsync();
        }

        // GET: api/Vaitroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vaitro>> GetVaitro(string id)
        {
            var vaitro = await _context.Vaitros.FindAsync(id);

            if (vaitro == null)
            {
                return NotFound();
            }

            return vaitro;
        }

        // PUT: api/Vaitroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVaitro(string id, Vaitro vaitro)
        {
            if (id != vaitro.IdVaitro)
            {
                return BadRequest();
            }

            _context.Entry(vaitro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VaitroExists(id))
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

        // POST: api/Vaitroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vaitro>> PostVaitro(Vaitro vaitro)
        {
            _context.Vaitros.Add(vaitro);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VaitroExists(vaitro.IdVaitro))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVaitro", new { id = vaitro.IdVaitro }, vaitro);
        }

        // DELETE: api/Vaitroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaitro(string id)
        {
            var vaitro = await _context.Vaitros.FindAsync(id);
            if (vaitro == null)
            {
                return NotFound();
            }

            _context.Vaitros.Remove(vaitro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VaitroExists(string id)
        {
            return _context.Vaitros.Any(e => e.IdVaitro == id);
        }
    }
}
