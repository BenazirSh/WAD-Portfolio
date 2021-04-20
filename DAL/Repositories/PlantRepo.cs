using CW7924.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PlantRepo : BaseRepo<Plant>, IRepo<Plant>
    {
        public PlantRepo(FlowerShopDbContext context) : base(context)
        {

        }
        public async Task<List<Plant>> GetAll()
        {
            return await _context.Plants.ToListAsync();
        }

        public async Task<Plant> GetById(int id)
        {
            return await _context.Plants.FirstOrDefaultAsync(m => m.Id == id);
        }

      
     

        public async Task DeleteAsync(int id)
        {
            var plant = await _context.Plants.FindAsync(id);
            _context.Plants.Remove(plant);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Plants.Any(m => m.Id == id);
        }

     

        

     
    }
}