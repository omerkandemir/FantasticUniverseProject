namespace NLayer.Core.Dto.Abstracts;

public interface IUpdatedResponse : IResponse
{
    public int Id { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
