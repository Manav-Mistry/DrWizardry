using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DrWizardry.Models;

namespace DrWizardry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SynonymsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public SynonymsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Synonyms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Synonym>>> GetSynonym()
        {
            return await _context.Synonym.ToListAsync();
        }

        // GET: api/Synonyms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Synonym>> GetSynonym(int id)
        {
            var synonym = await _context.Synonym.FindAsync(id);

            if (synonym == null)
            {
                return NotFound();
            }

            return synonym;
        }

        // PUT: api/Synonyms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSynonym(int id, Synonym synonym)
        {
            if (id != synonym.SynonymId)
            {
                return BadRequest();
            }

            _context.Entry(synonym).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SynonymExists(id))
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

        // POST: api/Synonyms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Synonym>> PostSynonym(Synonym synonym)
        {
            _context.Synonym.Add(synonym);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSynonym", new { id = synonym.SynonymId }, synonym);
        }

        // DELETE: api/Synonyms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSynonym(int id)
        {
            var synonym = await _context.Synonym.FindAsync(id);
            if (synonym == null)
            {
                return NotFound();
            }

            _context.Synonym.Remove(synonym);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SynonymExists(int id)
        {
            return _context.Synonym.Any(e => e.SynonymId == id);
        }
    }
}
