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
    public class LocatableImageRepository : BaseRepository, ILocatableImageRepository
    {
        public LocatableImageRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(LocatableImage locatableImageId)
        {
            await _context.LocatableImages.AddAsync(locatableImageId);
        }

        public async Task<LocatableImage> FindById(int id)
        {
            return await _context.LocatableImages.FindAsync(id);
        }

        public async Task<IEnumerable<LocatableImage>> ListAsync()
        {
            return await _context.LocatableImages.ToListAsync();
        }

        public async Task<IEnumerable<LocatableImage>> ListByLocatableIdAsync(int locatableId)
        {
            return await _context.LocatableImages
                .Where(p => p.LocatableId == locatableId)
                .Include(p => p.Locatable)
                .ToListAsync();
        }

        public void Remove(LocatableImage locatableImage)
        {
            _context.Remove(locatableImage);
        }

        public void Update(LocatableImage locatableImage)
        {
            _context.LocatableImages.Update(locatableImage);
        }
    }
}
