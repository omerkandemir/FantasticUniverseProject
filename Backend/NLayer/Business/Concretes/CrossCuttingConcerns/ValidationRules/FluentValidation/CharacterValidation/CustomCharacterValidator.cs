using FluentValidation;
using NLayer.Business.Abstracts;
using NLayer.Business.DependencyResolvers.Ninject;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.CharacterValidation;

public static class CustomCharacterValidator
{
    /// <summary>
    /// Belirli bir karakter türü ID'sinin veritabanında var olup olmadığını doğrulamak için bir kural oluşturur.
    /// </summary>
    /// <typeparam name="T">Kuralların uygulandığı nesne türü.</typeparam>
    /// <typeparam name="TProperty">Karakter türü ID'si özelliğinin türü.</typeparam>
    /// <param name="ruleBuilder">Kural oluşturucu.</param>
    /// <param name="allowNull">Nullable olmayan türler için false, Nullable türler için true</param>
    /// <returns>Oluşturulan kural yapılandırması.</returns>
    public static IRuleBuilderOptions<T, TProperty> IsCharacterIdExists<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, bool allowNull)
    {
        var characterService = InstanceFactory.GetInstance<ICharacterService>();
        
        return ruleBuilder.MustAsync(async(rootObject, Id, context) =>
        {
            var characters = (await characterService.GetAllAsync()).Data;
            if (allowNull && EqualityComparer<TProperty>.Default.Equals(Id, default))
            {
                return true; // Null değer kabul edilir.
            }
            return characters.Any(e => e.Id == (int)(object)Id); 
        }).WithMessage("Böyle bir karakter kayıtlı değil.");
    }
}
