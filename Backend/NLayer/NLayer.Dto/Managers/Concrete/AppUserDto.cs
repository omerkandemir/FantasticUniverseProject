using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Core.Entities.Authentication;
using NLayer.Core.Utilities.MailOperations.MailKit;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.AppUser;
using NLayer.Mapper.Responses.AppUser;

namespace NLayer.Dto.Managers.Concrete;

public class AppUserDto : IAppUserDto
{
    private readonly IAppUserService _appUserService;
    private readonly IMapper _mapper;
    public AppUserDto(IAppUserService appUserService, IMapper mapper)
    {
        _appUserService = appUserService;
        _mapper = mapper;
    }
    public async Task<IResponse> AddAsync(CreateAppUserRequest request)
    {
        AppUser user = _mapper.Map<AppUser>(request);
        user.ConfirmCode = SendMail.GenerateConfirmCode();
        var result = await _appUserService.AddAsyncWithIdentityUser(user, request.Password);
        var response = _mapper.Map<CreatedAppUserResponse>(user);
        if (result.Success)
        {
            SendMail.SendConfirmCodeMail(user.ConfirmCode, user);
            return ResponseFactory.CreateSuccessResponse<AppUser>(response, user);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public async Task<IResponse> UpdateAsync(UpdateAppUserRequest request)
    {
        AppUser user = _mapper.Map<AppUser>(request);
        var response = _mapper.Map<UpdatedAppUserResponse>(user);
        var result = await _appUserService.UpdateAsyncWithIdentityUser(user);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<AppUser>(response, user);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> ConfirmMailAsync(ConfirmMailRequest request)
    {
        AppUser user = _mapper.Map<AppUser>(request);
        var result = await _appUserService.ConfirmEmailAsyncWithIdentityUser(request);
        if(result.Success)
        {
            var response = _mapper.Map<UpdatedAppUserResponse>(user);
            return ResponseFactory.CreateSuccessResponse<AppUser>(response, user);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> UpdateEmailAsync(UpdateAppUserEmailRequest request)
    {
        AppUser user = _mapper.Map<AppUser>(request);
        var response = _mapper.Map<UpdatedAppUserResponse>(user);
        var result = await _appUserService.UpdateEmailAsyncWithIdentityUser(user, request.Password);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<AppUser>(response, user);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public async Task<IResponse> UpdatePasswordAsync(UpdateAppUserPasswordRequest request)
    {
        AppUser user = _mapper.Map<AppUser>(request);
        var response = _mapper.Map<UpdatedAppUserResponse>(user);
        var result = await _appUserService.ChangePasswordAsyncWithIdentityUser(request);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<AppUser>(response, user);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> UpdateProfilePhotoAsync(UpdateAppUserProfileImageRequest request)
    {
        AppUser user = _mapper.Map<AppUser>(request);
        var response = _mapper.Map<UpdatedAppUserResponse>(user);
        var result = await _appUserService.ChangeProfileImageAsyncWithIdentityUser(request);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<AppUser>(response, user);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> GetUserByNameAsync(string name)
    {
        var result = await _appUserService.GetUserByNameAsyncWithIdentityUser(name);
        if (result.Success)
        {
            var response = _mapper.Map<GetAllAppUserResponse>(result.Data);
            return ResponseFactory.CreateSuccessResponse<AppUser>(response, result.Data);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> GetUserByMailAsync(string email)
    {
        var result = await _appUserService.GetUserByMailAsyncWithIdentityUser(email);
        if (result.Success)
        {
            var response = _mapper.Map<GetAllAppUserResponse>(result.Data);
            return ResponseFactory.CreateSuccessResponse<AppUser>(response, result.Data);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> GetUserAsync(System.Security.Claims.ClaimsPrincipal claimsPrincipal)
    {
        var result = await _appUserService.GetUserAsyncWithIdentityUser(claimsPrincipal);
        if (result.Success)
        {
            var response = _mapper.Map<GetAllAppUserResponse>(result.Data);
            return ResponseFactory.CreateSuccessResponse<AppUser>(response, result.Data);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public Task<IResponse> DeleteAsync(DeleteAppUserRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<IGetResponse> GetAsync(object id)
    {
        throw new NotImplementedException();
    }

    public Task<List<GetAllAppUserResponse>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}