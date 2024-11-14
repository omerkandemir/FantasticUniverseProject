using FluentValidation;
using NLayer.Business.Abstracts;
using NLayer.Business.DependencyResolvers.Ninject;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.TimeLineValidation;

public static class CustomTimeLineValidator
{
    public static IRuleBuilderOptions<T, TProperty> IsTimeLineIdExists<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, bool allowNull)
    {
        var timeLineService = InstanceFactory.GetInstance<ITimeLineService>();
        return ruleBuilder.MustAsync(async (rootObject, Id, context) =>
        {
            var timeLines = (await timeLineService.GetAllAsync()).Data;
            if (allowNull && EqualityComparer<TProperty>.Default.Equals(Id, default))
            {
                return true; // Null değer kabul edilir.
            }
            return timeLines.Any(e => e.Id == (int)(object)Id); 
        }).WithMessage("Böyle bir zaman çizgisi kayıtlı değil.");
    }
}
