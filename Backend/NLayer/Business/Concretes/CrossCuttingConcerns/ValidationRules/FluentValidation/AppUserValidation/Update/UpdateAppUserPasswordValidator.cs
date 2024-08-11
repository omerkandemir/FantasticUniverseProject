using FluentValidation;
using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Mapper.Requests.AppUser;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AppUserValidation.Update;

public class UpdateAppUserPasswordValidator : BaseUpdateValidator<UpdateAppUserPasswordRequest>
{
    public UpdateAppUserPasswordValidator()
    {
        RuleFor(x => x.CurrentPassword).NotEmpty().WithMessage("Lütfen Mevcut Parolanızı Giriniz.");

        RuleFor(x => x.NewPassword).NotEmpty().WithMessage("Lütfen Yeni Parolanızı Giriniz.")
        .MaximumLength(30).WithMessage("Lütfen Parolanız için en fazla 30 karakter girişi yapın").
        MinimumLength(8).WithMessage("Yeni Parola en az 8 karakter olmalı.").
        Matches("[A-Z]").WithMessage("Yeni Parola en az bir büyük harf içermeli.").
        Matches("[a-z]").WithMessage("Yeni Parola en az bir küçük harf içermeli.").
        Matches("[0-9]").WithMessage("Yeni Parola en az bir rakam içermeli.").
        Matches("[^a-zA-Z0-9]").WithMessage("Yeni Parola en az bir sembol içermeli.");

        RuleFor(x => x.ConfirmNewPassword).NotEmpty().WithMessage("Parola onayı gerekli.").
        Equal(x => x.NewPassword).WithMessage("Parolalar eşleşmiyor.");
    }
}
