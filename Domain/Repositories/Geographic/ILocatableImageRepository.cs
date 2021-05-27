using GoingTo_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Repositories
    {
    public interface ILocatableImageRepository
    {
        Task<IEnumerable<LocatableImage>> ListAsync();
        Task<IEnumerable<LocatableImage>> ListByLocatableIdAsync(int locatableId);
        Task AddAsync(LocatableImage locatableImageId);
        Task<LocatableImage> FindById(int id);
        void Update(LocatableImage locatableImage);
        void Remove(LocatableImage locatableImage);
    }
}
