namespace NLayer.Core.Dto.Abstracts;

public interface ICreatedResponse : IResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }

}
