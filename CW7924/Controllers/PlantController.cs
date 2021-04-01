using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CW7924.DAL;
using DAL.DTO;
using System.Web.Http.Description;

namespace CW7924.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        private readonly FlowerShopDbContext _context;

        public PlantController(FlowerShopDbContext context)
        {
            _context = context;
        }

        // GET: api/Plant
        [HttpGet]
        public async Task<ActionResult<List<PlantDTO>>> GetPlants()
        {

            var plants = from b in _context.Plants
                        select new PlantDTO()
                        {
                            Id = b.Id,
                            PlantName = b.PlantName,
                            PlantCategory = b.PlantType.ToString()
                        };

            return await plants.ToListAsync();
          //  return await _context.Plants.ToListAsync();
        }

        // GET: api/Plant/5
        [HttpGet("{id}")]
        [ResponseType(typeof(PlantDTO))]
        public async Task<ActionResult<PlantDTO>> GetPlant(int id)
        {
          //  var plant = await _context.Plants.FindAsync(id);

         var plant = await _context.Plants.Include(b => b.PlantType).Select(b =>
     new PlantDTO()
     {
         Id = b.Id,
         PlantCategory = b.PlantType.ToString()


     }).SingleOrDefaultAsync(b => b.Id == id);


            if (plant == null)
            {
                return NotFound();
            }

            return Ok(plant);
        }

   

        // PUT: api/Plant/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlant(int id, Plant plant)
        {
            if (id != plant.Id)
            {
                return BadRequest();
            }

            _context.Entry(plant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantExists(id))
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

        // POST: api/Plant
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Plant>> PostPlant(Plant plant)
        {
            _context.Plants.Add(plant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlant", new { id = plant.Id }, plant);
        }

        // DELETE: api/Plant/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlant(int id)
        {
            var plant = await _context.Plants.FindAsync(id);
            if (plant == null)
            {
                return NotFound();
            }

            _context.Plants.Remove(plant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlantExists(int id)
        {
            return _context.Plants.Any(e => e.Id == id);
        }
    }
}
