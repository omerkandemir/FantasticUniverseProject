using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Abstract;

public interface IGetAppRoleResponse : IGetResponse
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
