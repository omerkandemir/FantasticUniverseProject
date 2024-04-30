namespace NLayer.Core.Dto.Abstracts;

public interface IUpdateRequest : IRequest
{
    public int Id { get; set; }
}
