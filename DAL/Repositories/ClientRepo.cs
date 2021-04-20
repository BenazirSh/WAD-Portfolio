using CW7924.DAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ClientRepo : BaseRepo<Client>, IRepo<Client>
    {
         
        public ClientRepo(FlowerShopDbContext context) : base(context)
        {

        }
      

        public async Task DeleteAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Clients.Any(m => m.Id == id);
        }

        public async Task<List<Client>> GetAll()
        {
            return await _context.Clients.Include(p => p.Plant).ToListAsync();
        }
    

        public async Task<Client> GetById(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(m => m.Id == id);
        }

  
    }
}