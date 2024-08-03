using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Final_Project_Group_3.Models;
using Final_Project_Group_3.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project_Group_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YearsInProgramController : ControllerBase
    {
        private readonly TeamProjectContext _context;

        public YearsInProgramController(TeamProjectContext context)
        {
            _context = context;
        }

        // GET: api/YearsInProgram
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YearInProgram>>> GetYearsInProgram(int? id)
        {
            if (id == null || id == 0)
            {
                return await _context.YearsInProgram.Take(5).ToListAsync();
            }

            var yearInProgram = await _context.YearsInProgram.FindAsync(id);

            if (yearInProgram == null)
            {
                return NotFound();
            }

            return Ok(yearInProgram);
        }

        // POST: api/YearsInProgram
        [HttpPost]
        public async Task<ActionResult<YearInProgram>> PostYearInProgram(YearInProgram yearInProgram)
        {
            _context.YearsInProgram.Add(yearInProgram);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetYearsInProgram), new { id = yearInProgram.Id }, yearInProgram);
        }

        // PUT: api/YearsInProgram/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYearInProgram(int id, YearInProgram yearInProgram)
        {
            if (id != yearInProgram.Id)
            {
                return BadRequest();
            }

            _context.Entry(yearInProgram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YearInProgramExists(id))
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

        // DELETE: api/YearsInProgram/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYearInProgram(int id)
        {
            var yearInProgram = await _context.YearsInProgram.FindAsync(id);
            if (yearInProgram == null)
            {
                return NotFound();
            }

            _context.YearsInProgram.Remove(yearInProgram);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool YearInProgramExists(int id)
        {
            return _context.YearsInProgram.Any(e => e.Id == id);
        }
    }
}

