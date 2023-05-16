using CrossplatformHW.Shared.Dtos;
using CrossplatformHW.Shared.Models;

namespace CrossplatformHW.Client.Services.ProfileService;

public interface IProfileService
{
    Task<UserDto?> GetAuthUser();
    Task<ProfileDto> GetUserProfile();
    Task UpdateUserProfile(ProfileDto newProfileDto);
    Task ChangeEmail(EmailChangeDto emailChangeDto);
    Task ChangePassword(PasswordChangeDto passwordChangeDto);
    Task CreateDeleteProfileLink();
    Task DeleteProfile(ConfirmationParameters parameters);
}