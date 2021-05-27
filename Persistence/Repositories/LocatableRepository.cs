using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Persistence
{
    public class LocatableRepository : BaseRepository, ILocatableRepository
    {
        public LocatableRepository(AppDbContext context) : base(context) { }
        public async Task AddAsync(Locatable locatable)
        {
            await _context.Locatables.AddAsync(locatable);
        }
        public async Task<Locatable> FindById(int id)
        {
            return await _context.Locatables
                .Where(p => p.Id == id)
                .Include(p => p.LocatableImages)
                .FirstAsync();
        }

        public async Task<IEnumerable<Locatable>> ListAsync()
        {
            return await _context.Locatables.Include(p=>p.LocatableImages).ToListAsync();
        }

        public void Remove(Locatable locatable)
        {
            _context.Locatables.Remove(locatable);
        }

        public void Update(Locatable locatable)
        {
            _context.Locatables.Update(locatable);
        }
    }
}
