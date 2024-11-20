using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Core.Entities.Authentication;
using NLayer.Core.Utilities.MailOperations.MailKit;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.AppUser;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Ability;
using NLayer.Mapper.Responses.Concrete.AppUser;

namespace NLayer.Dto.Managers.Concrete;

public class AppUserDto : IAppUserDto
{
    private readonly IAppUserService<AppUser> _appUserService;
    private readonly IMapper _mapper;
    private readonly ISignInService<AppUser> _signInService;
    private readonly IUniverseImageService _universeImageService;

    public AppUserDto(IAppUserService<AppUser> appUserService, IMapper mapper, ISignInService<AppUser> signInService, IUniverseImageService universeImageService)
    {
        _appUserService = appUserService;
        _mapper = mapper;
        _signInService = signInService;
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
    public async Task<IResponse> LoginAsync(LoginRequest loginRequest)
    {
        // Kullanıcı adı ve şifre doğrulama
        var signInResult = await _signInService.PasswordSignInAsync(loginRequest.Username, loginRequest.Password, true, true);
        if (!signInResult.Succeeded)
        {
            return ResponseFactory.CreateErrorResponse("Kullanıcı adı veya şifre hatalı.");
        }

        // Kullanıcı bilgilerini alma
        var userResult = await _appUserService.GetUserByNameAsyncWithIdentityUser(loginRequest.Username);
        if (!userResult.Success)
        {
            return ResponseFactory.CreateErrorResponse(userResult, "Kullanıcı bulunamadı.");
        }

        var user = (userResult as SuccessResponse<AppUser>)?.Entity;
        if (user == null)
        {
            return ResponseFactory.CreateErrorResponse(userResult, "Kullanıcı bilgisi getirilemedi.");
        }
        // E-posta doğrulama kontrolü
        if (!user.EmailConfirmed)
        {
            // Kullanıcının doğrulama kodunu üret
            _appUserService.GenerateCodeFromUser(user);

            // Yanıt olarak doğrulama işlemi gerektiğini belirt
            return ResponseFactory.CreateErrorResponse(userResult.Exception, new
            {
                RedirectUrl = "/ConfirmMail/Index",
                Email = user.Email
            }, "E-posta doğrulaması gerekiyor.");
        }

        var universeImage = await _universeImageService.GetAsync(user.UniverseImageId);
        var ImageUrl = universeImage.Data.ImageURL;
        // Kullanıcı doğrulandı, başarılı giriş
        return ResponseFactory.CreateSuccessResponse(new
        {
            RedirectUrl = "/MainPage/Index",
            UserName = user.UserName,
            ImageUrl = ImageUrl
        });
    }
}