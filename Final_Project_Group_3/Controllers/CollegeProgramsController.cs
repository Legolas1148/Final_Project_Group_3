using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Final_Project_Group_3.Models;
using Final_Project_Group_3.Data;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollegeProgram>>> GetCollegePrograms(int? id)
        {
            if (id == null || id == 0)
            {
                return await _context.CollegePrograms.Take(5).ToListAsync();
            }
            return await _context.CollegePrograms.Where(cp => cp.Id == id).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<CollegeProgram>> PostCollegeProgram(CollegeProgram collegeProgram)
        {
            _context.CollegePrograms.Add(collegeProgram);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCollegePrograms), new { id = collegeProgram.Id }, collegeProgram);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollegeProgram(int id, CollegeProgram collegeProgram)
        {
            if (id != collegeProgram.Id)
            {
                return BadRequest();
            }

            _context.Entry(collegeProgram).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

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
    }
}
