﻿using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.UnionCharacter;

public class CreateUnionCharacterRequest : ICreateRequest
{
    public int UnionId { get; set; }
    public int CharacterId { get; set; }

}
