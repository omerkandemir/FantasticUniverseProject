using AutoMapper;
using NLayer.Dto.Requests.TimeLine;
using NLayer.Dto.Responses.TimeLine;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.AutoMapper.Profiles;

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
