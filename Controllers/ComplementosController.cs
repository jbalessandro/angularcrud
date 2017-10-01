using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using angularapp.Models;

namespace angularapp.Controllers
{
    [Produces("application/json")]
    [Route("api/Complementos")]
    public class ComplementosController : Controller
    {
        private readonly CHAMONIXContext _context;

        public ComplementosController(CHAMONIXContext context)
        {
            _context = context;
        }

        // GET: api/Complementos
        [HttpGet]
        public IEnumerable<Complemento> GetComplemento()
        {
            return _context.Complemento;
        }

        // GET: api/Complementos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComplemento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var complemento = await _context.Complemento.SingleOrDefaultAsync(m => m.ComplementoId == id);

            if (complemento == null)
            {
                return NotFound();
            }

            return Ok(complemento);
        }

        // PUT: api/Complementos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComplemento([FromRoute] int id, [FromBody] Complemento complemento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != complemento.ComplementoId)
            {
                return BadRequest();
            }

            _context.Entry(complemento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComplementoExists(id))
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

        // POST: api/Complementos
        [HttpPost]
        public async Task<IActionResult> PostComplemento([FromBody] Complemento complemento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Complemento.Add(complemento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComplemento", new { id = complemento.ComplementoId }, complemento);
        }

        // DELETE: api/Complementos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComplemento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var complemento = await _context.Complemento.SingleOrDefaultAsync(m => m.ComplementoId == id);
            if (complemento == null)
            {
                return NotFound();
            }

            _context.Complemento.Remove(complemento);
            await _context.SaveChangesAsync();

            return Ok(complemento);
        }

        private bool ComplementoExists(int id)
        {
            return _context.Complemento.Any(e => e.ComplementoId == id);
        }
    }
}