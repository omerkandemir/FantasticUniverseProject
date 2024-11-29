using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Core.Entities.Authentication;
using NLayer.Core.Utilities.MailOperations.MailKit;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.AppUser;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.AppUser;

namespace NLayer.Dto.Managers.Concrete;

public class AppUserDto : IAppUserDto
{
    private readonly IAppUserService<AppUser> _appUserService;
    private readonly IMapper _mapper;
    private readonly IUniverseImageService _universeImageService;

    public AppUserDto(IAppUserService<AppUser> appUserService, IMapper mapper, IUniverseImageService universeImageService)
    {
        _appUserService = appUserService;
        _mapper = mapper;
        _universeImageService = universeImageService;
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
            return ResponseFactory.CreateSuccessResponse<AppUser>(user, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> Register(CreateAppUserRequest request)
    {
        if (request.Password != request.ConfirmPassword)
            return ResponseFactory.CreateErrorResponse("Parolalar eşleşmiyor.");


        AppUser user = _mapper.Map<AppUser>(request);
        var result = await _appUserService.Register(user, request.Password, true);
        var response = _mapper.Map<CreatedAppUserResponse>(user);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<AppUser>(user, response);
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
            return ResponseFactory.CreateSuccessResponse<AppUser>(user, response);
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
        if (result.Success)
        {
            var response = _mapper.Map<UpdatedAppUserResponse>(user);
            return ResponseFactory.CreateSuccessResponse<AppUser>(user, response);
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
            return ResponseFactory.CreateSuccessResponse<AppUser>(user, response);
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
            return ResponseFactory.CreateSuccessResponse<AppUser>(user, response);
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
            return ResponseFactory.CreateSuccessResponse<AppUser>(user, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> GetUserRolesAsync(AppUser user)
    {
        try
        {
            var result = await _appUserService.GetUserRolesAsync(user);
            if (result.Success)
            {
                return ResponseFactory.CreateSuccessResponse(result);
            }
            else
            {
                return ResponseFactory.CreateErrorResponse(result, result.Message);
            }
        }
        catch (Exception ex)
        {
            return ResponseFactory.CreateErrorResponse(ex);
        }
    }
    public async Task<IResponse> GetUserByNameAsync(string name)
    {
        var result = await _appUserService.GetUserByNameAsyncWithIdentityUser(name);
        if (result.Success)
        {
            var response = _mapper.Map<GetAllAppUserResponse>(result.Data);
            return ResponseFactory.CreateSuccessResponse<AppUser>(result.Data, response);
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
            return ResponseFactory.CreateSuccessResponse<AppUser>(result.Data, response);
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
            return ResponseFactory.CreateSuccessResponse<AppUser>(result.Data, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
    {
        return await _appUserService.LoginProcessAsync(loginRequest);
    }
    public async Task<IResponse> SignOutAsync()
    {
        var result = await _appUserService.SignOutAsync();
        return result.Success
            ? ResponseFactory.CreateSuccessResponse(result.Message)
            : ResponseFactory.CreateErrorResponse(result.Message);
    }

    public Task<IResponse> DeleteAsync(DeleteAppUserRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<IGetResponse> GetAsync(object id)
    {
        throw new NotImplementedException();
    }
    public Task<IGetAllResponse<IGetAppUserResponse>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}