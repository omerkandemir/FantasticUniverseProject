﻿using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Ability;

public class GetAllAbilityResponse : IGetResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
}
