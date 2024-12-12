using FluentValidation;
using NLayer.Mapper.Requests.UniverseImage;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UniverseImageValidation.Create;

public class CreateUniverseImageValidator : AbstractValidator<List<CreateUniverseImageRequest>>
{
    public CreateUniverseImageValidator()
    {
        RuleForEach(x => x)
            .ChildRules(child =>
            {
                child.RuleFor(y => y.UniverseId)
                    .GreaterThan(0)
                    .WithMessage("Evren ID'si geçerli olmalıdır.");

                child.RuleFor(y => y.ImageURL)
                    .NotEmpty()
                    .WithMessage("Görsel boş olamaz.")
                    .Must(image => image.Length > 0)
                    .WithMessage("Görsel içeriği boş olamaz.")
                    .IsValidImageExtension(new[] { ".jpg", ".jpeg", ".png" })
                    .IsValidImageSize(5 * 1024 * 1024)
                    .IsUniqueImage();
            });

        RuleFor(x => x)
    .Must(list => list.Where(i => i.ImageURL != null).Select(i => i.ImageURL).Distinct().Count() == list.Count)
    .WithMessage("Liste içinde aynı görsel birden fazla kez eklenemez.");
    }
}

