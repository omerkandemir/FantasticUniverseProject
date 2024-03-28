﻿using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Responses.Universe;

public class GetAllUniverseResponse : IGetResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Name { get; set; }
}