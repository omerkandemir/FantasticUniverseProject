﻿using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Responses.AdventureCharacter;

public class CreatedAdventureCharacterResponse : ICreatedResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int AdventureId { get; set; }
    public int CharacterId { get; set; }
}
