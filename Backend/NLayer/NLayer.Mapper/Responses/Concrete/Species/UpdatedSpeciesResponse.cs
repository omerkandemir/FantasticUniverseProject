﻿using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Concrete.Species;

public class UpdatedSpeciesResponse : IUpdatedResponse
{
    public int Id { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string Name { get; set; }
}
