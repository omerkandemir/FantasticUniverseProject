using AutoMapper;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.TimeLine;
using NLayer.Mapper.Responses.TimeLine;

namespace NLayer.Mapper.AutoMapper.Profiles;

public class TimeLineProfile : Profile
{
    public TimeLineProfile()
    {
        CreateMap<TimeLine, CreateTimeLineRequest>().ReverseMap();
        CreateMap<TimeLine, CreatedTimeLineResponse>().ReverseMap();
        CreateMap<TimeLine, UpdateTimeLineRequest>().ReverseMap();
        CreateMap<TimeLine, UpdatedTimeLineResponse>().ReverseMap();
        CreateMap<TimeLine, DeleteTimeLineRequest>().ReverseMap();
        CreateMap<TimeLine, DeletedTimeLineResponse>().ReverseMap();
        CreateMap<TimeLine, GetAllTimeLineResponse>().ReverseMap();
    }
}
