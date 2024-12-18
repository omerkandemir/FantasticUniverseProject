﻿using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Entities.Authorization;
using NLayer.Mapper.Requests.AppUser;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.AppUser;
using System.Security.Claims;

namespace NLayer.Dto.Managers.Abstract;

public interface IAppUserDto : IEntityRepositoryAsyncDto<
    IGetAppUserResponse,
    CreateAppUserRequest,
    UpdateAppUserRequest,
    DeleteAppUserRequest,
    GetAppUserResponse,
    GetAllAppUserResponse>
{
    Task<IResponse> UpdateEmailAsync(UpdateAppUserEmailRequest request);
    Task<IResponse> UpdatePasswordAsync(UpdateAppUserPasswordRequest request);
    Task<IResponse> UpdateProfilePhotoAsync(UpdateAppUserProfileImageRequest request);
    Task<IResponse> ConfirmMailAsync(ConfirmMailRequest request);
    Task<IResponse> GetUserByNameAsync(string name);
    Task<IResponse> GetUserByMailAsync(string email);
    Task<IResponse> GetUserAsync(ClaimsPrincipal claimsPrincipal);
    Task<List<string>> GetUserRolesAsync(string username);
    Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
    Task<LoginResponse> AdminLoginAsync(LoginRequest loginRequest);
    Task<IResponse> SignOutAsync();
    Task<IResponse> Register(CreateAppUserRequest request);
    Task<IResponse> AssignRoleAsync(List<AssignRole> assignRole);
}
