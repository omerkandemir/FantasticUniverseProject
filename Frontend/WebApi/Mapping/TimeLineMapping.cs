using AutoMapper;
using NLayer.Dto.Requests.TimeLine;
using NLayer.Dto.Responses.TimeLine;
using NLayer.Entities.Concretes;

namespace WebApi.Mapping;

public class TimeLineMapping : Profile
{
    public TimeLineMapping()
    {
        CreateMap<TimeLine, CreateTimeLineRequest>().ReverseMap();
        CreateMap<CreatedTimeLineResponse, TimeLine>().ReverseMap();
        CreateMap<TimeLine, UpdateTimeLineRequest>().ReverseMap();
        CreateMap<UpdatedTimeLineResponse, TimeLine>().ReverseMap();
        CreateMap<TimeLine, DeleteTimeLineRequest>().ReverseMap();
        CreateMap<DeletedTimeLineResponse, TimeLine>().ReverseMap();
        CreateMap<TimeLine, GetAllTimeLineResponse>().ReverseMap();
    }
}
