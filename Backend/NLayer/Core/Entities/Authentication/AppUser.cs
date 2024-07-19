using Microsoft.AspNetCore.Identity;
using NLayer.Core.Entities.Abstract;

namespace NLayer.Core.Entities.Authentication;

public class AppUser : IdentityUser<int>, IEntity
{
    public string Name { get; set; }
    public int UniverseImageId { get; set; }
    public string Surname { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public int ConfirmCode { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsActive { get; set; }
    public DateTime? DeletedDate { get; set; }
    public int CreatedBy { get; set; }
    public int? ModifiedBy { get; set; }
    object IEntity.Id 
    {
        get { return this.Id; }
        set { this.Id = (int)value; }
    }
}
