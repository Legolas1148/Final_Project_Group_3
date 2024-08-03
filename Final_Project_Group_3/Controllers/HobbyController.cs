using Final_Project_Group_3.Data;
using Final_Project_Group_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Final_Project_Group_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HobbyController : ControllerBase
    {
        private readonly TeamProjectContext _context;

        public HobbyController(TeamProjectContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hobby>>> GetHobby(int? id)
        {
            if(id == null || id == 0)
            {
                return await _context.Hobbies.Take(5).ToListAsync();
            }

            var hobby = await _context.Hobbies.FindAsync(id);

            if(hobby == null)
            {
                return NotFound();
            }

            return Ok(hobby);
        }

        [HttpPost]
        public async Task<ActionResult<Hobby>> PostHobby(Hobby hobby)
        {
            _context.Hobbies.Add(hobby);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHobby", new { id = hobby.TeamMemberId}, hobby);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHobby(int id, Hobby hobby)
        {
            if(id != hobby.TeamMemberId)
            {
                return BadRequest();
            }

            _context.Entry(hobby).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!HobbyExists(id))
                {
                    return BadRequest();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();   
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHooby(int id)
        {
            var hobby = await _context.Hobbies.FindAsync(id);

            if(hobby == null)
            {
                return NotFound();
            }

            _context.Hobbies.Remove(hobby);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HobbyExists(int id)
        {
            return _context.Hobbies.Any(e => e.TeamMemberId == id);
        }
    }
}
