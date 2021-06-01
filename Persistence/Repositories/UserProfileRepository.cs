using GoingTo_API.Domain.Models.Accounts;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories.Accounts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace GoingTo_API.Persistence.Repositories
{
    public class UserProfileRepository : BaseRepository, IUserProfileRepository
    {
        public UserProfileRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(UserProfile profile)
        {
            await _context.UserProfiles.AddAsync(profile);
        }

        public async Task<IEnumerable<UserProfile>> ListAsync()
        {
            return await _context.UserProfiles
                .Include(p => p.Country.Locatable.LocatableImages)
                .ToListAsync();
        }

        public async Task<UserProfile> FindById(int id)
        {
            return await _context.UserProfiles
                .Where(p => p.Id == id)
                .Include(p=>p.Country.Locatable.LocatableImages)
                .FirstAsync();
        }

        public void Update(UserProfile profile)
        {
            _context.UserProfiles.Update(profile);
        }

        public void Remove(UserProfile profile)
        {
            _context.UserProfiles.Remove(profile);
        }

        public async Task<UserProfile> FindByUserId(int userId)
        {
            return await _context.UserProfiles
                .Where(p => p.UserId == userId)
                .Include(p=> p.Country.Locatable.LocatableImages)
                .FirstAsync();
                
        }
    }
}
