using FluentValidation;
using NLayer.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Business.Concretes.ValidationRules.FluentValidation
{
    public class AbilityValidator : AbstractValidator<Ability>
    {
        public AbilityValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Yetenek adı boş olamaz");
        }
    }
}
