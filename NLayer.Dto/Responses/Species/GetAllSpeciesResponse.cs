using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Responses.Species;

public class GetAllSpeciesResponse : IGetResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Name { get; set; }
}
