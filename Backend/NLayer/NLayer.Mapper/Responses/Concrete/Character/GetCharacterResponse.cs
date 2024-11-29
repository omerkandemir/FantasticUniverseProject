﻿using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.Character;

public class GetCharacterResponse : IGetCharacterResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int? SpeciesId { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime? DeathDate { get; set; }
    public int? MasterCharacterId { get; set; }
    public int? ApprenticeId { get; set; }
}