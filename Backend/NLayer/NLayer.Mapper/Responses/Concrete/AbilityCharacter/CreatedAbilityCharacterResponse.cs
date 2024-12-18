﻿using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Concrete.AbilityCharacter;

public class CreatedAbilityCharacterResponse : ICreatedResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int AbilityId { get; set; }
    public int CharacterId { get; set; }
}
