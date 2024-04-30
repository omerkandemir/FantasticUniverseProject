namespace NLayer.Core.Dto.Abstracts;

public interface IDeleteRequest : IRequest
{
    public int Id { get; set; }
}
