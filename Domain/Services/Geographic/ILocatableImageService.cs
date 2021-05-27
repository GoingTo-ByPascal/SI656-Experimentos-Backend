using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services
{
    public interface ILocatableImageService
    {
        Task<IEnumerable<LocatableImage>> ListAsync();
        Task<IEnumerable<LocatableImage>> ListByLocatableIdAsync(int locatableId);
        Task<LocatableImageResponse> SaveAsync(LocatableImage locatableImage);
        Task<LocatableImageResponse> UpdateAsync(int id, LocatableImage locatableImage);
        Task<LocatableImageResponse> DeleteAsync(int id); 
        Task<LocatableImageResponse> GetByIdAsync(int id);

    }
}
