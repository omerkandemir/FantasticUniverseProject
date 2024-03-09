namespace NLayer.Core.Dto.Abstracts;

public interface IUpdatedResponse
{
    public int Id { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
