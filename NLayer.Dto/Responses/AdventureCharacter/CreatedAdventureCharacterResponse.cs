﻿using NLayer.Core.Dto.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Dto.Responses.AdventureCharacter
{
    public class CreatedAdventureCharacterResponse : ICreatedResponse
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AdventureId { get; set; }
        public int CharacterId { get; set; }
    }
}
