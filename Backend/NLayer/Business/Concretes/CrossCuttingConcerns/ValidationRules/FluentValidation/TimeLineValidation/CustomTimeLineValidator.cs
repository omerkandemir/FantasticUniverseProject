using FluentValidation;
using NLayer.Business.Abstracts;
using NLayer.Business.DependencyResolvers.Ninject;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.TimeLineValidation;

public static class CustomTimeLineValidator
{
    public static IRuleBuilderOptions<T, TProperty> IsTimeLineIdExists<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, bool allowNull)
    {
        var timeLineService = InstanceFactory.GetInstance<ITimeLineService>();
        var timeLines = timeLineService.GetAll().Data;
        return ruleBuilder.Must((rootObject, Id, context) =>
        {
            if (allowNull && EqualityComparer<TProperty>.Default.Equals(Id, default))
            {
                return true; // Null değer kabul edilir.
            }
            return timeLines.Any(e => e.Id == (int)(object)Id); 
        }).WithMessage("Böyle bir zaman çizgisi kayıtlı değil.");
    }

    public static IRuleBuilderOptions<T, object> DoesUniverseAdventurePairExist<T>(this IRuleBuilder<T, object> ruleBuilder)
    {
        return ruleBuilder.Must((rootObject, context) =>
        {
            var pair = (dynamic)rootObject;
            var timeLineService = InstanceFactory.GetInstance<ITimeLineService>();
            var pairExist = timeLineService.GetAll().Data.Any(p => p.UniverseId == pair.UniverseId && p.StartingAdventureId == pair.StartingAdventureId);
            return !pairExist;
        }).WithMessage("Belirtilen Evren ve Başlangıç Macerası çifti mevcut.");
    }
}
