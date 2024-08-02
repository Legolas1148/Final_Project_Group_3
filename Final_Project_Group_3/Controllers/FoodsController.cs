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
    public class FoodsController : ControllerBase
    {
        private readonly TeamProjectContext _context;

        public FoodsController(TeamProjectContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Foods>>> GetFoods(int? id)
        {
            if (id == null || id == 0)
            {
                return await _context.FavoriteFoods.Take(5).ToListAsync();
            }

            var food = await _context.FavoriteFoods.FindAsync(id);

            if (food == null)
            {
                return NotFound();
            }

            return Ok(food);
        }

        [HttpPost]
        public async Task<ActionResult<Foods>> PostFood(Foods food)
        {
            _context.FavoriteFoods.Add(food);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoods", new { id = food.TeamMemberId }, food);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFood(int id, Foods food)
        {
            if (id != food.TeamMemberId)
            {
                return BadRequest();
            }

            _context.Entry(food).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(id))
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
        public async Task<IActionResult> DeleteFood(int id)
        {
            var food = await _context.FavoriteFoods.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }

            _context.FavoriteFoods.Remove(food);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodExists(int id)
        {
            return _context.FavoriteFoods.Any(e => e.TeamMemberId == id);
        }
    }
}
