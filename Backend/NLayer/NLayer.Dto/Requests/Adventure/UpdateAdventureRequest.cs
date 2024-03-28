﻿using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Requests.Adventure;

public class UpdateAdventureRequest : IUpdateRequest
{
    public int Id { get; set; }
    public int PlanetId { get; set; }
    public string AdventureName { get; set; }
    public string Occurrence { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
}