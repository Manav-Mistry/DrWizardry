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
    public class VocabsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public VocabsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Vocabs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vocab>>> GetVocabs()
        {
            return await _context.Vocabs.ToListAsync();
        }

        // GET: api/Vocabs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vocab>> GetVocab(int id)
        {
            var vocab = await _context.Vocabs.FindAsync(id);

            if (vocab == null)
            {
                return NotFound();
            }

            return vocab;
        }

        // PUT: api/Vocabs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVocab(int id, Vocab vocab)
        {
            if (id != vocab.VocabId)
            {
                return BadRequest();
            }

            _context.Entry(vocab).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VocabExists(id))
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

        // POST: api/Vocabs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vocab>> PostVocab(Vocab vocab)
        {
            vocab.UserID = 1;

            _context.Vocabs.Add(vocab);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVocab", new { id = vocab.VocabId }, vocab);
        }

        // DELETE: api/Vocabs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVocab(int id)
        {
            var vocab = await _context.Vocabs.FindAsync(id);
            if (vocab == null)
            {
                return NotFound();
            }

            _context.Vocabs.Remove(vocab);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VocabExists(int id)
        {
            return _context.Vocabs.Any(e => e.VocabId == id);
        }
    }
}
