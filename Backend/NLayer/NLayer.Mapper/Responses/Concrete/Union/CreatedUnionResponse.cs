﻿using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Concrete.Union;

public class CreatedUnionResponse : ICreatedResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Name { get; set; }
    public string Target { get; set; }
    public int? UnionLeaderId { get; set; }
    public int UniverseId { get; set; }

}
