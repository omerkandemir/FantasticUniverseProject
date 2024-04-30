namespace NLayer.Core.Dto.Abstracts;

public interface IGetResponse : IResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
}
