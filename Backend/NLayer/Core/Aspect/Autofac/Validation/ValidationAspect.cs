using AutoMapper;
using Castle.DynamicProxy;
using FluentValidation;
using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Core.Utilities.Interceptors;
using NLayer.Core.Utilities.Messages;

namespace NLayer.Core.Aspect.Autofac.Validation;

[Serializable]
public class ValidationAspect : MethodInterception
{
    private Type _validatorType;
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
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap(invocation.Arguments[0].GetType(), _validatorType.BaseType.GetGenericArguments()[0]);
        });

        var mapper = config.CreateMapper();
        var validator = (IValidator)Activator.CreateInstance(_validatorType);

        foreach (var argument in invocation.Arguments)
        {
            var entity = mapper.Map(argument, argument.GetType(), _validatorType.BaseType.GetGenericArguments()[0]);
            ValidationTool.Validate(validator, entity);
        }
    }
}
