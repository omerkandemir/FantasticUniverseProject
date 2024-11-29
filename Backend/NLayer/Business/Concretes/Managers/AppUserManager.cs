using Microsoft.AspNetCore.Identity;
using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AppUserValidation.Create;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AppUserValidation.Update;
using NLayer.Core.Aspect.Autofac.Validation;
using NLayer.Core.Authentication.Abstracts;
using NLayer.Core.Entities.Authentication;
using NLayer.Core.Exceptions;
using NLayer.Core.Security.Jwt;
using NLayer.Core.Utilities.Infos;
using NLayer.Core.Utilities.MailOperations.MailKit;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;
using NLayer.Mapper.Requests.AppUser;
using NLayer.Mapper.Responses.Concrete.AppUser;
using LoginRequest = NLayer.Mapper.Requests.AppUser.LoginRequest;

namespace NLayer.Business.Concretes.Managers;

public class AppUserManager : BaseManagerAsync<AppUser, IAppUserDal>, IAppUserService<AppUser>
{
    private readonly IUserService<AppUser> _userService;
    private readonly ISignInService<AppUser> _signInService;
    private readonly IUniverseImageService _universeImageService;
    private readonly ITokenService _tokenService;
    private readonly IUserImageService _userImageService;
    public AppUserManager(IAppUserDal tdal, IUserService<AppUser> userService, IUniverseImageService universeImageService, ISignInService<AppUser> signInService, ITokenService tokenService, IUserImageService userImageService) : base(tdal)
    {
        _userService = userService;
        _signInService = signInService;
        _universeImageService = universeImageService;
        _tokenService = tokenService;
        _userImageService = userImageService;
    }

    [ValidationAspect(typeof(CreateAppUserValidator), Priority = 1)]
    public async Task<IReturnType> AddAsyncWithIdentityUser(AppUser user, string password)
    {
        try
        {
            var result = await _userService.CreateAsync(user, password);

            if (result.Succeeded)
            {
                return new ReturnType(GetDatasInfo.Added, CrudOperation.Add);
            }
            else
            {
                return new ReturnType(GetDatasInfo.AddedFailed, CrudOperation.Add, false);
            }
        }
        catch (Exception ex)
        {
            return new ReturnType(GetDatasInfo.AddedFailed, CrudOperation.Add, ex);
        }
    }

    [ValidationAspect(typeof(CreateAppUserValidator), Priority = 1)]
    public async Task<IReturnType> Register(AppUser user, string password, bool isPersistent)
    {
        try
        {
            var result = await _userService.CreateAsync(user, password);
            await _userImageService.AddUserFirstImages();
            user.ConfirmCode = SendMail.GenerateConfirmCode();
            SendMail.SendConfirmCodeMail(user.ConfirmCode, user);
            await _signInService.SignInAsync(user, isPersistent);
            if (result.Succeeded)
            {
                return new ReturnType(GetDatasInfo.Added, CrudOperation.Add);
            }
            else
            {
                return new ReturnType(GetDatasInfo.AddedFailed, CrudOperation.Add, false);
            }
        }
        catch (Exception ex)
        {
            return new ReturnType(GetDatasInfo.AddedFailed, CrudOperation.Add, ex);
        }
    }

    [ValidationAspect(typeof(UpdateAppUserInfoValidator), Priority = 1)]
    public async Task<IReturnType> UpdateAsyncWithIdentityUser(AppUser user)
    {
        try
        {
            AppUser existingUser = await _userService.FindByIdAsync(user.Id.ToString());

            existingUser.Name = user.Name;
            existingUser.Surname = user.Surname;
            existingUser.UserName = user.UserName;
            existingUser.City = user.City;
            existingUser.District = user.District;

            var result = await _userService.UpdateAsync(existingUser);
            if (result.Succeeded)
            {
                return new ReturnType(GetDatasInfo.Updated, CrudOperation.Update);

            }
            else
            {
                var errorMessages = result.Errors.Select(e => e.Description).ToList();
                var errorString = string.Join("; ", errorMessages);
                return new ReturnType(errorString, CrudOperation.Update, false);
            }
        }
        catch (Exception ex)
        {
            return new ReturnType(GetDatasInfo.UpdatedFailed, CrudOperation.Update, ex);
        }
    }

    [ValidationAspect(typeof(UpdateAppUserEmailValidator), Priority = 1)]
    public async Task<IReturnType> UpdateEmailAsyncWithIdentityUser(AppUser user, string password)
    {
        try
        {
            AppUser existUser = await _userService.FindByIdAsync(user.Id.ToString());
            if (user == null)
            {
                throw new UserException("Kullanıcı bulunamadı. Lütfen kullanıcı ID'sini kontrol edin ve tekrar deneyin.");
            }
            var passwordCheck = await _userService.CheckPasswordAsync(existUser, password);
            if (!passwordCheck)
            {
                throw new UserException("Eksik ya da Hatalı şifre girdiniz.");
            }
            else if (user.Email == existUser.Email)
            {
                throw new UserException("Değiştirmek istediğiniz mail adresi mevcut mail adresinizden farklı olmalı");
            }

            existUser.Email = user.Email;

            existUser.EmailConfirmed = false;
            GenerateCode(existUser);

            var result = await _userService.UpdateAsync(existUser);
            if (result.Succeeded)
            {
                return new ReturnType(GetDatasInfo.Updated, CrudOperation.Update);
            }
            else
            {
                return new ReturnType(GetDatasInfo.UpdatedFailed, CrudOperation.Update, false);
            }
        }
        catch (UserException ex)
        {
            return new ReturnType(GetDatasInfo.UpdatedFailed, CrudOperation.Update, ex);
        }
        catch (Exception ex)
        {
            return new ReturnType(GetDatasInfo.UpdatedFailed, CrudOperation.Update, ex);
        }
    }
    private void GenerateCodeFromUser(AppUser user)
    {
        GenerateCode(user);
        _userService.UpdateAsync(user);
    }

    private static void GenerateCode(AppUser user)
    {
        int code = SendMail.GenerateConfirmCode();
        SendMail.SendConfirmCodeMail(code, user);
        user.ConfirmCode = code;
    }

    [ValidationAspect(typeof(ConfirmEmailAppUserValidator), Priority = 1)]
    public async Task<IReturnType> ConfirmEmailAsyncWithIdentityUser(ConfirmMailRequest request)
    {
        try
        {
            var user = await _userService.FindByIdAsync(request.Id.ToString());
            if (user == null)
            {
                throw new UserException("Kullanıcı bulunamadı. Lütfen kullanıcı ID'sini kontrol edin ve tekrar deneyin.");
            }

            if (user.ConfirmCode != request.ConfirmCode)
            {
                throw new UserException("Doğrulama kodu yanlış!.");
            }

            user.EmailConfirmed = true;
            var result = await _userService.UpdateAsync(user);

            if (result.Succeeded)
            {
                return new ReturnType(GetDatasInfo.Updated, CrudOperation.Update);
            }
            else
            {
                return new ReturnType(GetDatasInfo.UpdatedFailed, CrudOperation.Update);
            }
        }
        catch (UserException ex)
        {
            return new ReturnType(GetDatasInfo.UpdatedFailed, CrudOperation.Update, ex);
        }
        catch (Exception ex)
        {
            return new ReturnType(GetDatasInfo.UpdatedFailed, CrudOperation.Update, ex);
        }
    }

    [ValidationAspect(typeof(UpdateAppUserPasswordValidator), Priority = 1)]
    public async Task<IReturnType> ChangePasswordAsyncWithIdentityUser(UpdateAppUserPasswordRequest updateAppUserPasswordRequest)
    {
        try
        {
            var user = await _userService.FindByIdAsync(updateAppUserPasswordRequest.Id.ToString());
            if (user == null)
            {
                throw new UserException("Kullanıcı bulunamadı. Lütfen kullanıcı ID'sini kontrol edin ve tekrar deneyin.");
            }
            if (!await _userService.CheckPasswordAsync(user, updateAppUserPasswordRequest.CurrentPassword))
            {
                throw new UserException("Mevcut şifreniz yanlış.");
            }
            else if (updateAppUserPasswordRequest.CurrentPassword == updateAppUserPasswordRequest.NewPassword)
            {
                throw new UserException("Yeni şifre, mevcut şifre ile aynı olamaz.");
            }
            else if (updateAppUserPasswordRequest.NewPassword != updateAppUserPasswordRequest.ConfirmNewPassword)
            {
                throw new UserException("Şifre ve şifre tekrarı farklı olamaz.");
            }

            var result = await _userService.ChangePasswordAsync(user, updateAppUserPasswordRequest.CurrentPassword, updateAppUserPasswordRequest.NewPassword);
            if (result.Succeeded)
            {
                return new ReturnType(GetDatasInfo.Updated, CrudOperation.Update);
            }
            else
            {
                return new ReturnType(GetDatasInfo.UpdatedFailed, CrudOperation.Update);
            }
        }
        catch (UserException ex)
        {
            return new ReturnType(GetDatasInfo.UpdatedFailed, CrudOperation.Update, ex);
        }
        catch (Exception ex)
        {
            return new ReturnType(GetDatasInfo.UpdatedFailed, CrudOperation.Update, ex);
        }
    }

    [ValidationAspect(typeof(UpdateAppUserProfileImageValidator), Priority = 1)]
    public async Task<IReturnType> ChangeProfileImageAsyncWithIdentityUser(UpdateAppUserProfileImageRequest request)
    {
        try
        {
            var user = await _userService.FindByIdAsync(request.Id.ToString());
            if (user == null)
            {
                throw new UserException("Kullanıcı bulunamadı. Lütfen kullanıcı ID'sini kontrol edin ve tekrar deneyin.");
            }
            if (user.UniverseImageId == request.SelectedImageId)
            {
                throw new UserException("Seçtiğiniz profil resmi zaten mevcut profil resminizle aynı!");
            }
            user.UniverseImageId = request.SelectedImageId;
            var result = await _userService.UpdateAsync(user);
            if (result.Succeeded)
            {
                await _signInService.RefreshSignInAsync(user);
                return new ReturnType(GetDatasInfo.Updated, CrudOperation.Update);
            }
            else
            {
                return new ReturnType(GetDatasInfo.UpdatedFailed, CrudOperation.Update, false);
            }
        }
        catch (UserException ex)
        {
            return new ReturnType(GetDatasInfo.UpdatedFailed, CrudOperation.Update, ex);
        }
        catch (Exception ex)
        {
            return new ReturnType(GetDatasInfo.UpdatedFailed, CrudOperation.Update, ex);
        }
    }

    public async Task<IDataReturnType<AppUser>> GetUserByNameAsyncWithIdentityUser(string userName)
    {
        try
        {
            var user = await _userService.FindByNameAsync(userName);
            if (user == null)
            {
                throw new UserException("Kullanıcı bulunamadı. Lütfen kullanıcı ID'sini kontrol edin ve tekrar deneyin.");
            }

            return new DataReturnType<AppUser>(user, GetDatasInfo.SuccessGetData, CrudOperation.Get);
        }
        catch (UserException ex)
        {
            return new DataReturnType<AppUser>(GetDatasInfo.FailedGetData, CrudOperation.Get, ex);
        }
        catch (Exception ex)
        {
            return new DataReturnType<AppUser>(GetDatasInfo.FailedGetData, CrudOperation.Get, ex);
        }
    }
    public async Task<IDataReturnType<AppUser>> GetUserByMailAsyncWithIdentityUser(string email)
    {
        try
        {
            AppUser user = await _userService.FindByEmailAsync(email);
            if (user == null)
            {
                throw new UserException("Kullanıcı bulunamadı. Lütfen kullanıcı ID'sini kontrol edin ve tekrar deneyin.");
            }
            return new DataReturnType<AppUser>(user, GetDatasInfo.SuccessGetData, CrudOperation.Get);
        }
        catch (UserException ex)
        {
            return new DataReturnType<AppUser>(GetDatasInfo.FailedGetData, CrudOperation.Get, ex);
        }
        catch (Exception ex)
        {
            return new DataReturnType<AppUser>(GetDatasInfo.FailedGetData, CrudOperation.Get, ex);
        }
    }
    public async Task<IDataReturnType<AppUser>> GetUserAsyncWithIdentityUser(System.Security.Claims.ClaimsPrincipal claimsPrincipal)
    {
        try
        {
            AppUser user = await _userService.GetUserAsync(claimsPrincipal);
            if (user == null)
            {
                throw new UserException("Kullanıcı bulunamadı. Lütfen kullanıcı ID'sini kontrol edin ve tekrar deneyin.");
            }

            return new DataReturnType<AppUser>(user, GetDatasInfo.SuccessGetData, CrudOperation.Get);
        }
        catch (UserException ex)
        {
            return new DataReturnType<AppUser>(GetDatasInfo.FailedGetData, CrudOperation.Get, ex);
        }
        catch (Exception ex)
        {
            return new DataReturnType<AppUser>(GetDatasInfo.FailedGetData, CrudOperation.Get, ex);
        }
    }

    public async Task<SignInResult> LoginAsync(LoginRequest loginRequest)
    {
        return await _signInService.LoginAsync(loginRequest.Username, loginRequest.Password, loginRequest.IsPersistence, loginRequest.LockoutOnFailure);
    }
    public async Task<IReturnType> SignOutAsync()
    {
        try
        {
            await _signInService.SignOutAsync();
            return new ReturnType("Çıkış işlemi başarıyla tamamlandı.", true);
        }
        catch (Exception)
        {
            return new ReturnType("Çıkış yapılamadı!", false);
        }
    }

    public async Task<LoginResponse> LoginProcessAsync(LoginRequest loginRequest)
    {
        var result = await _signInService.LoginAsync(loginRequest.Username, loginRequest.Password, loginRequest.IsPersistence, loginRequest.LockoutOnFailure);
        if (!result.Succeeded)
        {
            throw new UserException("Kullanıcı adı veya şifre hatalı.");
        }

        var userResult = await _userService.FindByNameAsync(loginRequest.Username);

        // JWT Token oluştur
        var roles = await _userService.GetUserRolesAsync(userResult);
        var token = _tokenService.GenerateAccessToken(userResult, roles);

        if (!userResult.EmailConfirmed)
        {
            // E-posta onaylanmamış
            GenerateCodeFromUser(userResult);
            return new LoginResponse
            {
                Id = userResult.Id,
                RedirectTo = "/ConfirmMail/Index",
                Email = userResult.Email,
                IsEmailConfirmed = false,
                Message = "Lütfen E-posta Adresinizi onaylayın",
                Success = true
            };
        }

        var universeImage = await _universeImageService.GetAsync(userResult.UniverseImageId);
        if (universeImage == null)
        {
            throw new UserException("Kullanıcının evren resmi bulunamadı.");
        }


        return new LoginResponse
        {
            Id = userResult.Id,
            RedirectTo = "/MainPage/Index",
            UserName = userResult.UserName,
            ImageURL = universeImage.Data.ImageURL,
            IsEmailConfirmed = true,
            Token = token,
            Message = "Giriş başarılı!",
            Success = true

        };
    }

    public async Task<IDataReturnType<ICollection<string>>> GetUserRolesAsync(AppUser user)
    {
        try
        {
            var userRoleList = await _userService.GetUserRolesAsync(user);

            return new DataReturnType<ICollection<string>>(userRoleList, GetDatasInfo.SuccessListData, CrudOperation.List);
        }
        catch (Exception ex)
        {
            return new DataReturnType<ICollection<string>>(GetDatasInfo.FailedListData, CrudOperation.List, ex);
        }
    }
}


