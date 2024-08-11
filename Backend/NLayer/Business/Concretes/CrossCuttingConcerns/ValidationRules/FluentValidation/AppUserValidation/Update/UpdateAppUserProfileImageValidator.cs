using FluentValidation;
using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Mapper.Requests.AppUser;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AppUserValidation.Update;

public class UpdateAppUserProfileImageValidator : BaseUpdateValidator<UpdateAppUserProfileImageRequest>
{
    public UpdateAppUserProfileImageValidator()
    {
        RuleFor(x => x.SelectedImageId).NotEmpty().WithMessage("Lütfen Görsel Seçiniz.");
            
    }
}
