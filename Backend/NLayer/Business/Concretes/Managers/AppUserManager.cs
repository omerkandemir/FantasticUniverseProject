using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AppUserValidation.Create;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AppUserValidation.Update;
using NLayer.Core.Aspect.Autofac.Validation;
using NLayer.Core.Entities.Authentication;
using NLayer.Core.Exceptions;
using NLayer.Core.Utilities.Infos;
using NLayer.Core.Utilities.MailOperations.MailKit;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;
using NLayer.Mapper.Requests.AppUser;

namespace NLayer.Business.Concretes.Managers;

public class AppUserManager : BaseManagerAsync<AppUser, IAppUserDal>, IAppUserService<AppUser>
{
    private readonly IUserService<AppUser> _userService;
    public AppUserManager(IAppUserDal tdal, IUserService<AppUser> userService) : base(tdal)
    {
        _userService = userService;
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
                return new ReturnType(GetDatasInfo.AddedFailed, CrudOperation.Add);
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
                return new ReturnType(GetDatasInfo.UpdatedFailed, CrudOperation.Update);
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
    public void GenerateCodeFromUser(AppUser user)
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
            user.UniverseImageId = request.SelectedImageId;
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
}

