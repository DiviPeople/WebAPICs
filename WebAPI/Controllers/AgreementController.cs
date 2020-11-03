using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgreementController : ControllerBase
    {
        private readonly WebAPIContext _context;

        public AgreementController(WebAPIContext context)
        {
            _context = context;
        }

        // GET: api/Agreement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agreement>>> GetAgreement()
        {
            return await _context.Agreement.ToListAsync();
        }

        // GET: api/Agreement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agreement>> GetAgreement(int id)
        {
            var agreement = await _context.Agreement.FindAsync(id);

            if (agreement == null)
            {
                return NotFound();
            }

            return agreement;
        }

        // PUT: api/Agreement/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgreement(int id, Agreement agreement)
        {
            if (id != agreement.Id)
            {
                return BadRequest();
            }

            _context.Entry(agreement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgreementExists(id))
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

        // POST: api/Agreement
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Agreement>> PostAgreement(Agreement agreement)
        {
            _context.Agreement.Add(agreement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgreement", new { id = agreement.Id }, agreement);
        }

        // DELETE: api/Agreement/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Agreement>> DeleteAgreement(int id)
        {
            var agreement = await _context.Agreement.FindAsync(id);
            if (agreement == null)
            {
                return NotFound();
            }

            _context.Agreement.Remove(agreement);
            await _context.SaveChangesAsync();

            return agreement;
        }

        private bool AgreementExists(int id)
        {
            return _context.Agreement.Any(e => e.Id == id);
        }
    }
}
