namespace NLayer.Core.Entities.Concrete;

public class UserImage : BaseEntity<int>
{
    public int UserId { get; set; }
    public int UniverseImageId { get; set; }
}
