﻿using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.AppUser;
using NLayer.Mapper.Responses.AppUser;

namespace NLayer.Dto.Managers.Abstract;

public interface IAppUserDto : IEntityRepositoryDto<
    CreateAppUserRequest,
    UpdateAppUserRequest,
    DeleteAppUserRequest,
    GetAllAppUserResponse>
{
    Task<IResponse> AddAsync(CreateAppUserRequest request);
    Task<IResponse> UpdateAsync(UpdateAppUserRequest request);
    Task<IResponse> UpdateEmailAsync(UpdateAppUserEmailRequest request);
    Task<IResponse> UpdatePasswordAsync(UpdateAppUserPasswordRequest request);
    Task<IResponse> UpdateProfilePhotoAsync(UpdateAppUserProfileImageRequest request);
    Task<IResponse> ConfirmMailAsync(ConfirmMailRequest request);
    Task<IResponse> GetUserByNameAsync(string name);
    Task<IResponse> GetUserByMailAsync(string email);
    Task<IResponse> GetUserAsync(System.Security.Claims.ClaimsPrincipal claimsPrincipal);
}
