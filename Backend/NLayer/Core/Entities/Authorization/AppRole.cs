using NLayer.Core.Entities.Abstract;

namespace NLayer.Core.Entities.Authorization;

public class AppRole : BaseAppRole , IEntity<int>
{
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsActive { get; set; }
    public DateTime? DeletedDate { get; set; }
    public int CreatedBy { get; set; }
    public int? ModifiedBy { get; set; }
}
