using AutoMapper;

namespace NLayer.Core.Utilities.MapperHelper.AutoMapper;


public static class AutoMapperHelper<TSource, TDestination>
{
    private static IMapper _mapper;
    static AutoMapperHelper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<TSource, TDestination>();
        });
        _mapper = config.CreateMapper();
    }
    public static TDestination Map<TSource, TDestination>(TSource source)
    {
        return _mapper.Map<TDestination>(source);
    }
    public static void Initialize(Action<IMapperConfigurationExpression> configAction)
    {
        var config = new MapperConfiguration(configAction);
        _mapper = config.CreateMapper();
    }
}