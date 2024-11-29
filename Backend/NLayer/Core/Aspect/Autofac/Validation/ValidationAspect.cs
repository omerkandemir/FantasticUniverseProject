using Castle.DynamicProxy;
using FluentValidation;
using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Core.Utilities.Interceptors;
using NLayer.Core.Utilities.Messages;

namespace NLayer.Core.Aspect.Autofac.Validation;

[Serializable]
public class ValidationAspect : MethodInterception
{
    private readonly Type _validatorType;

    public ValidationAspect(Type validatorType)
    {
        if (!typeof(IValidator).IsAssignableFrom(validatorType))
        {
            throw new System.Exception(AspectMessages.WrongValidationType);
        }
        _validatorType = validatorType;
    }
    protected override void OnBefore(IInvocation invocation)
    {
        var validator = (IValidator)Activator.CreateInstance(_validatorType);
        var entityType = _validatorType.BaseType.GetGenericArguments()[0];
        var combinedArguments = Activator.CreateInstance(entityType);

        foreach (var argument in invocation.Arguments)
        {

            // Argument'in türü ile hedef türün eşleşip eşleşmediğinin kontrolü
            if (argument != null && entityType.IsAssignableFrom(argument.GetType()))
            {
                combinedArguments = argument; // Tür aynıysa 
                break;
            }


            var argumentType = argument.GetType();

            foreach (var property in argumentType.GetProperties())
            {
                var targetProperty = entityType.GetProperties()
                    .FirstOrDefault(p => p.Name.Equals(property.Name, StringComparison.OrdinalIgnoreCase));
                if (targetProperty != null)
                {
                    targetProperty.SetValue(combinedArguments, property.GetValue(argument));
                }
            }
        }

        ValidationTool.Validate(validator, combinedArguments);
    }
}
