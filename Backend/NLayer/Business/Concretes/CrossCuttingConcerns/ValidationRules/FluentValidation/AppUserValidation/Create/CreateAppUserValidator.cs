﻿using FluentValidation;
using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;

using NLayer.Mapper.Requests.AppUser;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AppUserValidation.Create;

public class CreateAppUserValidator : BaseCreateValidator<CreateAppUserRequest>
{
    public CreateAppUserValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");
        RuleFor(x => x.Name).MaximumLength(30).WithMessage("Lütfen Ad alanı için en fazla 30 karakter girişi yapın");
        RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lütfen Ad alanı için en az 2 karakter girişi yapın");
        RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez");
        RuleFor(x => x.Surname).MaximumLength(30).WithMessage("Lütfen Soyad alanı için en fazla 30 karakter girişi yapın");
        RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lütfen Soyad alanı için en az 2 karakter girişi yapın");
        RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez");
        RuleFor(x => x.UserName).MaximumLength(30).WithMessage("Lütfen Kullanıcı adı alanı için en fazla 30 karakter girişi yapın");
        RuleFor(x => x.UserName).MinimumLength(2).WithMessage("Lütfen Ad alanı için en az 2 karakter girişi yapın"); ;
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş geçilemez");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz");
        RuleFor(x => x.UniverseImageId).NotEmpty().WithMessage("Lütfen görsel seçiniz.");
        RuleFor(x => x.City).NotEmpty().WithMessage("Şehir alanı boş geçilemez.");
        RuleFor(x => x.District).NotEmpty().WithMessage("İlçe alanı boş geçilemez.");

    }
}
