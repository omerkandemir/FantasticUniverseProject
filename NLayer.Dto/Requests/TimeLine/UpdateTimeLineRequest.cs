﻿using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Requests.TimeLine;

public class UpdateTimeLineRequest : IUpdateRequest
{
    public int Id { get; set; }
    public int StartingAdventureId { get; set; }
}
