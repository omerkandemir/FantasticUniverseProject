namespace NLayer.Core.Entities.Abstract;

public interface IEntity
{
    public object Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsActive { get; set; }
    public DateTime? DeletedDate { get; set; }
}
