using GoingTo_API.Domain.Models.Accounts;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Repositories.Accounts;
using GoingTo_API.Domain.Services.Accounts;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoingTo_API.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public readonly IUnitOfWork _unitOfWork;

        public UserProfileService(IUserProfileRepository userProfileRepository, IUnitOfWork unitOfWork)
        {
            _userProfileRepository = userProfileRepository;
            _unitOfWork = unitOfWork;

        }
        public async Task<IEnumerable<UserProfile>> ListAsync()
        {
            return await _userProfileRepository.ListAsync();
        }

        public async Task<ProfileResponse> SaveAsync(UserProfile profile)
        {
            try
            {
                await _userProfileRepository.AddAsync(profile);
                await _unitOfWork.CompleteAsync();

                return new ProfileResponse(profile);
            }
            catch (Exception ex)
            {
                return new ProfileResponse($"An error ocurred while saving the profile: {ex.Message}");
            }
        }

        public async Task<ProfileResponse> UpdateAsync(int id, UserProfile profile)
        {
            var existingProfile = await _userProfileRepository.FindById(id);

            if (existingProfile == null)
                return new ProfileResponse("Profile not found");

            existingProfile.Name = profile.Name;
            existingProfile.Surname = profile.Surname;
            existingProfile.BirthDate = profile.BirthDate;
            existingProfile.Gender = profile.Gender;
            existingProfile.CreatedAt = DateTime.Now.ToString("yyyy-MM-dd");
            existingProfile.CountryId = profile.CountryId;

            try
            {
                _userProfileRepository.Update(existingProfile);
                await _unitOfWork.CompleteAsync();

                return new ProfileResponse(existingProfile);
            }

            catch (Exception ex)
            {
                return new ProfileResponse($"An error ocurred while updating profile : {ex.Message}");
            }
        }

        public async Task<ProfileResponse> DeleteAsync(int id)
        {
            var existingProfile = await _userProfileRepository.FindById(id);

            if (existingProfile == null)
                return new ProfileResponse("Profile not found");

            try
            {
                _userProfileRepository.Remove(existingProfile);
                await _unitOfWork.CompleteAsync();
                return new ProfileResponse(existingProfile);
            }

            catch (Exception ex)
            {
                return new ProfileResponse($"An error ocurred while deleting profile : {ex.Message}");
            }
        }

        public async Task<ProfileResponse> FindById(int userProfileId)
        {
            var existingUserProfile = await _userProfileRepository.FindById(userProfileId);
            if (existingUserProfile == null)
                return new ProfileResponse("Profile not found");
            return new ProfileResponse(existingUserProfile);
        }

        public async Task<ProfileResponse> FindByUserId(int userId)
        {
            var existingUserProfile = await _userProfileRepository.FindByUserId(userId);
            if (existingUserProfile == null)
                return new ProfileResponse(String.Format("Profile with userId {0} not found",userId));
            return new ProfileResponse(existingUserProfile);
        }
    }
}
