using CrossplatformHW.Shared.Dtos;
using CrossplatformHW.Shared.Models;

namespace CrossplatformHW.Server.Facades.ProfileFacade;

public interface IProfileFacade
{
    Task<ProfileDto> GetUserProfileAsync(Guid userId);
    Task<TokenDto> UpdateUserProfileAsync(Guid userId, ProfileDto newProfileDto);
    Task<TokenDto> ChangeEmailAsync(Guid userId, EmailChangeDto emailChangeDto);
    Task ChangePasswordAsync(Guid userId, PasswordChangeDto passwordChangeDto);
    Task GetDeleteProfileLinkAsync(Guid userId);
    Task DeleteProfileAsync(ConfirmationParameters parameters);
}