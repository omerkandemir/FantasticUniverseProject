using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.Star;

public class GetStarResponse : IGetStarResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int GalaxyId { get; set; }
    public string Name { get; set; }
}
