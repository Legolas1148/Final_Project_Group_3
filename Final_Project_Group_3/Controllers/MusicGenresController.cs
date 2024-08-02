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
    public class MusicGenresController : ControllerBase
    {
        private readonly TeamProjectContext _context;

        public MusicGenresController(TeamProjectContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MGenre>>> GetMusicGenres(int? id)
        {
            if (id == null || id == 0)
            {
                return await _context.MusicGenres.Take(5).ToListAsync();
            }

            var musicGenre = await _context.MusicGenres.FindAsync(id);

            if (musicGenre == null)
            {
                return NotFound();
            }

            return Ok(musicGenre);
        }

        [HttpPost]
        public async Task<ActionResult<MGenre>> PostMusicGenre(MGenre musicGenre)
        {
            _context.MusicGenres.Add(musicGenre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusicGenres", new { id = musicGenre.TeamMemberId }, musicGenre);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusicGenre(int id, MGenre musicGenre)
        {
            if (id != musicGenre.TeamMemberId)
            {
                return BadRequest();
            }

            _context.Entry(musicGenre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicGenreExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusicGenre(int id)
        {
            var musicGenre = await _context.MusicGenres.FindAsync(id);
            if (musicGenre == null)
            {
                return NotFound();
            }

            _context.MusicGenres.Remove(musicGenre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MusicGenreExists(int id)
        {
            return _context.MusicGenres.Any(e => e.TeamMemberId == id);
        }
    }
}
