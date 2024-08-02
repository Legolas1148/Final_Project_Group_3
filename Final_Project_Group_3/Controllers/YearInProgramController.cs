using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Final_Project_Group_3.Models;
using Final_Project_Group_3.Data;


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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<YearInProgram>>> GetYearsInProgram(int? id)
        {
            if (id == null || id == 0)
            {
                return await _context.YearsInProgram.Take(5).ToListAsync();
            }
            return await _context.YearsInProgram.Where(yp => yp.Id == id).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<YearInProgram>> PostYearInProgram(YearInProgram yearInProgram)
        {
            _context.YearsInProgram.Add(yearInProgram);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetYearsInProgram), new { id = yearInProgram.Id }, yearInProgram);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutYearInProgram(int id, YearInProgram yearInProgram)
        {
            if (id != yearInProgram.Id)
            {
                return BadRequest();
            }

            _context.Entry(yearInProgram).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

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
    }
}
