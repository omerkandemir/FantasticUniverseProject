using NLayer.Core.Entities.Abstract;

namespace NLayer.Core.Entities.Concrete;

public class BaseEntity<TId> : IEntity
{
    public TId Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsActive { get; set; }
    public DateTime? DeletedDate { get; set; }
}
