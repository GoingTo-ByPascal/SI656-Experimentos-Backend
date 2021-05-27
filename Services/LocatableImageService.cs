using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Services;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Services
{
    public class LocatableImageService : ILocatableImageService
    {
        private readonly ILocatableImageRepository _locatableImageRepository;
        public readonly IUnitOfWork _unitOfWork;

        public LocatableImageService(ILocatableImageRepository locatableImageRepository,IUnitOfWork unitOfWork)
        {
            _locatableImageRepository = locatableImageRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<LocatableImage>> ListAsync()
        {
            return await _locatableImageRepository.ListAsync();
        }

        public async Task<IEnumerable<LocatableImage>> ListByLocatableIdAsync(int locatableId)
        {
            var locatableImages = await _locatableImageRepository.ListByLocatableIdAsync(locatableId);
            return locatableImages;
        }

        public async Task<LocatableImageResponse> SaveAsync(LocatableImage locatableImage)
        {
            try
            {
                await _locatableImageRepository.AddAsync(locatableImage);
                await _unitOfWork.CompleteAsync();
                return new LocatableImageResponse(locatableImage);
            }
            catch(Exception ex)
            {
                return new LocatableImageResponse($"An error ocurred while saving the locatable image: {ex.Message}");
            }
        }

        public async Task<LocatableImageResponse> UpdateAsync(int id, LocatableImage locatableImage)
        {
            var existingLocatableImage = await _locatableImageRepository.FindById(id);
            if (existingLocatableImage == null)
                return new LocatableImageResponse("Locatable Image not found");
            existingLocatableImage.Id = locatableImage.Id;
            try
            {
                _locatableImageRepository.Update(existingLocatableImage);
                await _unitOfWork.CompleteAsync();

                return new LocatableImageResponse(existingLocatableImage);
            }
            catch(Exception ex)
            {
                return new LocatableImageResponse($"An error ocurred while updating locatable image: {ex.Message}");
            }
        }

        public async Task<LocatableImageResponse> DeleteAsync(int id)
        {
            var existingLocatableImage = await _locatableImageRepository.FindById(id);
            if (existingLocatableImage == null)
                return new LocatableImageResponse("Locatable image not found");
            try
            {
                _locatableImageRepository.Remove(existingLocatableImage);
                await _unitOfWork.CompleteAsync();
                return new LocatableImageResponse(existingLocatableImage);
            }
            catch(Exception ex)
            {
                return new LocatableImageResponse($"An error ocurred while removing locatable image: {ex.Message}");
            }
        }

        public async Task<LocatableImageResponse> GetByIdAsync(int id)
        {
            var existingLocatableResponse = await _locatableImageRepository.FindById(id);
            if (existingLocatableResponse == null)
                return new LocatableImageResponse("Locatable image not found");
            return new LocatableImageResponse(existingLocatableResponse);
        }
    }
}
