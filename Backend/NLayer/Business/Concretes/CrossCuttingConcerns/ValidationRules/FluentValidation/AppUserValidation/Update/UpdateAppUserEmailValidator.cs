using FluentValidation;
using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Mapper.Requests.AppUser;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AppUserValidation.Update;

public class UpdateAppUserEmailValidator : BaseUpdateValidator<UpdateAppUserEmailRequest>
{
    public UpdateAppUserEmailValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş geçilemez");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz");
    }
}