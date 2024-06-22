using FluentValidation;
using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;

using NLayer.Mapper.Requests.AppUser;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AppUserValidation.Create;

public class CreateAppUserValidator : BaseCreateValidator<CreateAppUserRequest>
{
    public CreateAppUserValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");
        RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez");
        RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş geçilemez");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez");
        RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre tekrar alanı boş geçilemez");
        RuleFor(x => x.Name).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter girişi yapın");
        RuleFor(x => x.Name).MaximumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın");
        RuleFor(x => x.Password).Equal(y=>y.ConfirmPassword).WithMessage("Parolanız eşleşmiyor");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz");
        RuleFor(x => x.UniverseImageId).NotEmpty().WithMessage("Lütfen görsel seçiniz.");
    }
}
