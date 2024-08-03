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
    public class CollegeProgramsController : ControllerBase
    {
        private readonly TeamProjectContext _context;

        public CollegeProgramsController(TeamProjectContext context)
        {
            _context = context;
        }

        // GET: api/CollegePrograms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollegeProgram>>> GetCollegePrograms(int? id)
        {
            if (id == null || id == 0)
            {
                return await _context.CollegePrograms.Take(5).ToListAsync();
            }

            var collegeProgram = await _context.CollegePrograms.FindAsync(id);

            if (collegeProgram == null)
            {
                return NotFound();
            }

            return Ok(collegeProgram);
        }

        // POST: api/CollegePrograms
        [HttpPost]
        public async Task<ActionResult<CollegeProgram>> PostCollegeProgram(CollegeProgram collegeProgram)
        {
            _context.CollegePrograms.Add(collegeProgram);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCollegePrograms), new { id = collegeProgram.Id }, collegeProgram);
        }

        // PUT: api/CollegePrograms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollegeProgram(int id, CollegeProgram collegeProgram)
        {
            if (id != collegeProgram.Id)
            {
                return BadRequest();
            }

            _context.Entry(collegeProgram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollegeProgramExists(id))
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

        // DELETE: api/CollegePrograms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollegeProgram(int id)
        {
            var collegeProgram = await _context.CollegePrograms.FindAsync(id);
            if (collegeProgram == null)
            {
                return NotFound();
            }

            _context.CollegePrograms.Remove(collegeProgram);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CollegeProgramExists(int id)
        {
            return _context.CollegePrograms.Any(e => e.Id == id);
        }
    }
}
