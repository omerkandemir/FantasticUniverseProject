using FluentValidation;
using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Mapper.Requests.AppUser;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AppUserValidation.Update;

public class ConfirmEmailAppUserValidator : BaseUpdateValidator<ConfirmMailRequest>
{
    public ConfirmEmailAppUserValidator()
    {
        RuleFor(x => x.ConfirmCode).NotEmpty().WithName("Lütfen Onay Kodunu Giriniz.");
    }
}
