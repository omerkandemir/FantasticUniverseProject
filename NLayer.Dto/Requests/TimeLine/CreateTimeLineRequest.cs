﻿using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Requests.TimeLine;

public class CreateTimeLineRequest : ICreateRequest
{
    public int UniverseId { get; set; }
    public int StartingAdventureId { get; set; }
}
