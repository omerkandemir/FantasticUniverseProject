namespace NLayer.Core.Entities.Abstract;

public interface IEntity
{
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsActive { get; set; }
    public DateTime? DeletedDate { get; set; }
    public int CreatedBy { get; set; }
    public int? ModifiedBy { get; set; }
}
public interface IEntity<TId> : IEntity 
{
    public TId Id { get; set; }
}
